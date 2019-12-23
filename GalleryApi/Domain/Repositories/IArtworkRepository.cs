using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GalleryApi.Domain.Models;

namespace GalleryApi.Domain.Repositories
{
    public interface IArtworkRepository
    {
        public Task<IEnumerable<Artwork>> CommunityArtworkListAsync();
        public Task<IEnumerable<Artwork>> MyArtListAsync(string userId);

    }
}
