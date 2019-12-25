using System.Collections.Generic;
using System.Threading.Tasks;
using GalleryApi.Domain.Models;
using GalleryApi.Domain.Models.Queries;
using GalleryApi.Domain.Services.Communication;

namespace GalleryApi.Domain.Services
{
    public interface IArtworkService
    {
        //public Task<IEnumerable<Artwork>> CommunityArtworkListAsync();
        public Task<QueryResult<Artwork>> CommunityArtworkListAsync(Query query);

        //public Task<IEnumerable<Artwork>> MyArtworkListAsync(string userId);
        public Task<QueryResult<Artwork>> MyArtworkListAsync(string userId, Query query);

        public Task<Artwork> FindArtworkByIdAsync(int artworkId);

        public Task<ArtworkResponse> SaveArtworkAsync(Artwork artwork);
        public Task<ArtworkResponse> UpdateArtworkAsync(int id, Artwork artwork);
        public Task<ArtworkResponse> DeleteArtworkAsync(int id);
    }
}
