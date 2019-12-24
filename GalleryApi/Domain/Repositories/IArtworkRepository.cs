using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GalleryApi.Domain.Models;

namespace GalleryApi.Domain.Repositories
{
    public interface IArtworkRepository
    {
        public Task<IEnumerable<Artwork>> CommunityArtworkListAsync();
        public Task<IEnumerable<Artwork>> MyArtworkListAsync(string userId);
        public Task AddAsync(Artwork artwork);
        public Task<Artwork> FindByIdAsync(int id);
        public void Update(Artwork artwork);
    }
}
