using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GalleryApi.Domain.Models;
using GalleryApi.Domain.Services;
using GalleryApi.Domain.Services.Communication;
using GalleryApi.Resources;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GalleryApi.Controllers
{
    [Route("api/[controller]")]
    public class ArtworkController : Controller
    {
        private readonly IArtworkService artworkService;
        private readonly IMapper mapper;

        public ArtworkController(IArtworkService artworkService, IMapper mapper)
        {
            this.artworkService = artworkService;
            this.mapper = mapper;
        }

        [HttpGet("community")]
        public async Task<IEnumerable<ArtworkResource>> GetCommunityArt()
        {
            var artworkList = await artworkService.CommunityArtworkListAsync();
            var artworkResourceList = mapper.Map<IEnumerable<Artwork>, IEnumerable<ArtworkResource>>(artworkList);

            return artworkResourceList;
        }


        [HttpGet("{userId}")]
        public async Task<IEnumerable<ArtworkResource>> GetMyArt(string userId)
        {
            var artworkList = await artworkService.MyArtworkListAsync(userId);
            var artworkResourceList = mapper.Map<IEnumerable<Artwork>, IEnumerable<ArtworkResource>>(artworkList);

            return artworkResourceList;
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> PostAsync(string userId, [FromBody]SaveArtworkResource saveArtworkResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("invalid post request data was sent");
            }

            Artwork artwork = mapper.Map<SaveArtworkResource, Artwork>(saveArtworkResource);
            artwork.ApplicationUserId = userId;
            ArtworkResponse artworkResponse = await artworkService.SaveArtworkAsync(artwork);

            if (!artworkResponse.Success)
            {
                return BadRequest(artworkResponse.Message);
            }

            ArtworkResource artworkResource = mapper.Map<Artwork, ArtworkResource>(artworkResponse.Resource);
            return Ok(artworkResource);

        }

        // PUT api/values/5
        [HttpPut("{artworkId}")]
        public async Task<IActionResult> PutAsync(int artworkId, [FromBody]UpdateArtworkResource updateArtworkResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("invalid update request data was sent");
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
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
