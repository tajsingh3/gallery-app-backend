using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace GalleryApi.Resources
{
    public class UpdateArtworkResource
    {

        public int Id { get; set; }

        public string Name { get; set; } = null;

        public string Description { get; set; } = null;

        //[Required]
        public string ImageUrl { get; set; } = null;

        public IFormFile ImageFile { get; set; } = null;
    }
}
