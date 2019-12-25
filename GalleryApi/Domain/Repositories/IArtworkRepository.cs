using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GalleryApi.Domain.Models;
using GalleryApi.Domain.Models.Queries;

namespace GalleryApi.Domain.Repositories
{
    public interface IArtworkRepository
    {
        //public Task<IEnumerable<Artwork>> CommunityArtworkListAsync();
        public Task<QueryResult<Artwork>> CommunityArtworkListAsync(Query query);

        public Task<IEnumerable<Artwork>> MyArtworkListAsync(string userId);
        public Task AddAsync(Artwork artwork);
        public Task<Artwork> FindByIdAsync(int id);
        public void Update(Artwork artwork);
        public void Delete(Artwork artwork);
    }
}
