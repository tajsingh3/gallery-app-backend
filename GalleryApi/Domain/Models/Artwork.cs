using System;
using System.Collections.Generic;

namespace GalleryApi.Domain.Models
{
    public class Artwork
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }

        public ICollection<Vote> Votes { get; set; }
    }
}
