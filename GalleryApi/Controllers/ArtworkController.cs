﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalleryApi.Domain.Models;
using GalleryApi.Domain.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GalleryApi.Controllers
{
    [Route("api/[controller]")]
    public class ArtworkController : Controller
    {
        private readonly IArtworkService artworkService;

        public ArtworkController(IArtworkService artworkService)
        {
            this.artworkService = artworkService;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("communityart")]
        public async Task<IEnumerable<Artwork>> GetCommunityArt()
        {
            return await artworkService.CommunityArtworkListAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

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
