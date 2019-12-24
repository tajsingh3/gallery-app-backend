using System.Collections.Generic;
using System.Threading.Tasks;
using GalleryApi.Domain.Models;
using GalleryApi.Domain.Services.Communication;

namespace GalleryApi.Domain.Services
{
    public interface IArtworkService
    {
        public Task<IEnumerable<Artwork>> CommunityArtworkListAsync();
        public Task<IEnumerable<Artwork>> MyArtworkListAsync(string userId);
        public Task<ArtworkResponse> SaveArtworkAsync(Artwork artwork);
        public Task<ArtworkResponse> UpdateArtworkAsync(int id, Artwork artwork);
    }
}
