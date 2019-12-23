using System.Collections.Generic;
using System.Threading.Tasks;
using GalleryApi.Domain.Models;

namespace GalleryApi.Domain.Services
{
    public interface IArtworkService
    {
        public Task<IEnumerable<Artwork>> CommunityArtworkListAsync();
        public Task<IEnumerable<Artwork>> MyArtworkListAsync(string userId);

    }
}
