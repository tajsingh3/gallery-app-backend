using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace GalleryApi.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Artwork> Artworks { get; set; }
        public ICollection<Vote> Votes { get; set; }

    }
}
