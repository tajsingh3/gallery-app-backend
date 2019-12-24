using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GalleryApi.Domain.Models;
using GalleryApi.Domain.Repositories;
using GalleryApi.Domain.Services;
using GalleryApi.Domain.Services.Communication;

namespace GalleryApi.Services
{
    public class ArtworkService : IArtworkService
    {
        private readonly IArtworkRepository artworkRepository;
        private readonly IUnitOfWork unitOfWork;

        public ArtworkService(IArtworkRepository artworkRepository, IUnitOfWork unitOfWork)
        {
            this.artworkRepository = artworkRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Artwork>> CommunityArtworkListAsync()
        {
            return await artworkRepository.CommunityArtworkListAsync();
        }

        public async Task<IEnumerable<Artwork>> MyArtworkListAsync(string userId)
        {
            return await artworkRepository.MyArtworkListAsync(userId);
        }

        public async Task<ArtworkResponse> SaveArtworkAsync(Artwork artwork)
        {
            try
            {
                await artworkRepository.AddAsync(artwork);
                await unitOfWork.CompleteAsync();

                return new ArtworkResponse(artwork);
            }
            catch (Exception ex)
            {
                return new ArtworkResponse($"An error occured while saving artwork {ex.Message}");
            }
        }
    }
}
