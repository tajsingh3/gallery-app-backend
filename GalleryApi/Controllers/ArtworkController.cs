using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GalleryApi.Domain.Models;
using GalleryApi.Domain.Services;
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

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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

        // GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
