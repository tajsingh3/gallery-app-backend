using System;
using System.Collections.Generic;

namespace GalleryApi.Domain.Models
{
    public class ApplicationUser
    {
        public ICollection<Artwork> Artworks { get; set; }
        public ICollection<Vote> Votes { get; set; }
    }
}
