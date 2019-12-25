using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GalleryApi.Domain.Models;
using GalleryApi.Domain.Models.Queries;
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

        //public async Task<IEnumerable<Artwork>> CommunityArtworkListAsync()
        //{
        //    return await artworkRepository.CommunityArtworkListAsync();
        //}
        public async Task<QueryResult<Artwork>> CommunityArtworkListAsync(Query query)
        {
            return await artworkRepository.CommunityArtworkListAsync(query);
        }

        //public async Task<IEnumerable<Artwork>> MyArtworkListAsync(string userId)
        //{
        //    return await artworkRepository.MyArtworkListAsync(userId);
        //}
        public async Task<QueryResult<Artwork>> MyArtworkListAsync(string userId, Query query)
        {
            return await artworkRepository.MyArtworkListAsync(userId, query);
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

        public async Task<ArtworkResponse> UpdateArtworkAsync(int id, Artwork artwork)
        {
            Artwork existingArtwork = await artworkRepository.FindByIdAsync(id);

            if (existingArtwork == null)
            {
                return new ArtworkResponse("Artwork does not exist");
            }

            existingArtwork.Name = artwork.Name;
            existingArtwork.Description = artwork.Description;
            existingArtwork.ImageUrl = artwork.ImageUrl;

            try
            {
                artworkRepository.Update(existingArtwork);
                await unitOfWork.CompleteAsync();

                return new ArtworkResponse(existingArtwork);

            }
            catch (Exception ex)
            {
                return new ArtworkResponse($"An error occured while updating artwork {ex.Message}");
            }

        }

        public async Task<ArtworkResponse> DeleteArtworkAsync(int id)
        {
            Artwork existingArtwork = await artworkRepository.FindByIdAsync(id);

            if (existingArtwork == null)
            {
                return new ArtworkResponse("Artwork does not exist");
            }

            try
            {
                artworkRepository.Delete(existingArtwork);
                await unitOfWork.CompleteAsync();

                return new ArtworkResponse(existingArtwork);
            }
            catch (Exception ex)
            {
                return new ArtworkResponse($"An error occured while deleting artwork {ex.Message}");
            }
        }
    }
}
