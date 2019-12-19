using System;
namespace GalleryApi.Domain.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public string VoteValue { get; set; } = string.Empty;

        public int ArtworkId { get; set; }
        public Artwork Artwork { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }

    }
}
