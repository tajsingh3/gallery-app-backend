using System;
using System.ComponentModel.DataAnnotations;

namespace GalleryApi.Resources
{
    public class UpdateArtworkResource
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
