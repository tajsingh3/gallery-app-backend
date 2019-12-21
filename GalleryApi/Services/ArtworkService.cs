using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GalleryApi.Domain.Models;
using GalleryApi.Domain.Repositories;
using GalleryApi.Domain.Services;

namespace GalleryApi.Services
{
    public class ArtworkService : IArtworkService
    {
        private readonly IArtworkRepository artworkRepository;

        public ArtworkService(IArtworkRepository artworkRepository)
        {
            this.artworkRepository = artworkRepository;
        }

        public async Task<IEnumerable<Artwork>> CommunityArtworkListAsync()
        {
            return await artworkRepository.CommunityArtListAsync();
        }
    }
}
