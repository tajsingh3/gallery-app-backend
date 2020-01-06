using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GalleryApi.Domain.Models;
using GalleryApi.Domain.Models.Queries;
using GalleryApi.Domain.Services;
using GalleryApi.Domain.Services.Communication;
using GalleryApi.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using static GalleryApi.Helpers.ImageFileCreator;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GalleryApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ArtworkController : Controller
    {
        private readonly IArtworkService artworkService;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment env;

        public ArtworkController(IArtworkService artworkService, IMapper mapper, IWebHostEnvironment env)
        {
            this.artworkService = artworkService;
            this.mapper = mapper;
            this.env = env;
        }

        [AllowAnonymous]
        [HttpGet("community")]
        public async Task<QueryResultResource<ArtworkResource>> GetCommunityArt([FromQuery]QueryResource query)
        {
            var artworkQuery = mapper.Map<QueryResource, Query>(query);
            var queryResult = await artworkService.CommunityArtworkListAsync(artworkQuery);

            var artworkResource = mapper.Map<QueryResult<Artwork>, QueryResultResource<ArtworkResource>>(queryResult);

            return artworkResource;
        }

        [HttpGet("{userId}")]
        public async Task<QueryResultResource<ArtworkResource>> GetMyArt(string userId, [FromQuery]QueryResource query)
        {
            var artworkQuery = mapper.Map<QueryResource, Query>(query);
            var queryResult = await artworkService.MyArtworkListAsync(userId, artworkQuery);

            var artworkResource = mapper.Map<QueryResult<Artwork>, QueryResultResource<ArtworkResource>>(queryResult);

            return artworkResource;
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> PostAsync(string userId, [FromForm]SaveArtworkResource saveArtworkResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("invalid post request data was sent");
            }

            string webRootPath = env.WebRootPath;
            string imagesFolderPath = Path.Combine(webRootPath, "images");
            string filePath = await CreateImageFile(saveArtworkResource.ImageFile, imagesFolderPath);

            if (filePath == null)
            {
                return BadRequest("Image file could not be saved");
            }

            Artwork artwork = mapper.Map<SaveArtworkResource, Artwork>(saveArtworkResource);
            artwork.ApplicationUserId = userId;
            artwork.ImageUrl = filePath;

            ArtworkResponse artworkResponse = await artworkService.SaveArtworkAsync(artwork);

            if (!artworkResponse.Success)
            {
                return BadRequest(artworkResponse.Message);
            }

            ArtworkResource artworkResource = mapper.Map<Artwork, ArtworkResource>(artworkResponse.Resource);
            return Ok(artworkResource);

        }

        [HttpPut("update/{artworkId}")]
        public async Task<IActionResult> PutAsync(int artworkId, [FromForm]UpdateArtworkResource updateArtworkResource)
        {
            Artwork existingArtwork = await artworkService.FindArtworkByIdAsync(artworkId);

            if (existingArtwork == null)
            {
                BadRequest("Artwork does not exist");
            }

            updateArtworkResource.Name ??= existingArtwork.Name;
            updateArtworkResource.Description ??= existingArtwork.Description;

            if (updateArtworkResource.ImageFile == null)
            {
                updateArtworkResource.ImageUrl = existingArtwork.ImageUrl;
            }
            else
            {
                try
                {
                    string webRootPath = env.WebRootPath;
                    string imagesFolderPath = Path.Combine(webRootPath, "images");
                    string filePath = await CreateImageFile(updateArtworkResource.ImageFile, imagesFolderPath);

                    if (filePath == null)
                    {
                        return BadRequest("Image file could not be saved");
                    }

                    updateArtworkResource.ImageUrl = filePath;

                    string oldImageFilePath = Path.Combine(webRootPath, existingArtwork.ImageUrl);
                    System.IO.File.Delete(oldImageFilePath);
                }
                catch (Exception ex)
                {
                    BadRequest(ex.Message);
                }
            }

            Artwork artwork = mapper.Map<UpdateArtworkResource, Artwork>(updateArtworkResource);
            ArtworkResponse artworkResponse = await artworkService.UpdateArtworkAsync(artworkId, artwork);

            if (!artworkResponse.Success)
            {
                return BadRequest(artworkResponse.Message);
            }

            ArtworkResource artworkResource = mapper.Map<Artwork, ArtworkResource>(artworkResponse.Resource);
            return Ok(artworkResource);
        }

        // DELETE api/values/5
        [HttpDelete("delete/{artworkId}")]
        public async Task<IActionResult> DeleteAsync(int artworkId)
        {
            ArtworkResponse artworkResponse = await artworkService.DeleteArtworkAsync(artworkId);

            if (!artworkResponse.Success)
            {
                return BadRequest(artworkResponse.Message);
            }

            ArtworkResource artworkResource = mapper.Map<Artwork, ArtworkResource>(artworkResponse.Resource);

            return Ok(artworkResource);
        }
    }
}
