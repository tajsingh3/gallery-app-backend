using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace GalleryApi.Resources
{
    public class SaveArtworkResource
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        //[Required]
        //public string ImageUrl { get; set; }

        [Required]
        public IFormFile ImageFile { get; set; }

    }
}
