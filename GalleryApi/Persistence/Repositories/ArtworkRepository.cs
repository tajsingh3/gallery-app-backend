using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalleryApi.Domain.Models;
using GalleryApi.Domain.Repositories;
using GalleryApi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace GalleryApi.Persistence.Repositories
{
    public class ArtworkRepository : BaseRepository, IArtworkRepository
    {
        public ArtworkRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Artwork>> CommunityArtworkListAsync()
        {

            return await context.Artworks.ToListAsync<Artwork>();
        }

        public async Task<IEnumerable<Artwork>> MyArtworkListAsync(string userId)
        {
            return await context.Artworks.Where(a => a.ApplicationUserId.Equals(userId)).ToListAsync<Artwork>();
        }

        public async Task AddAsync(Artwork artwork)
        {
            await context.Artworks.AddAsync(artwork);
        }

        public async Task<Artwork> FindByIdAsync(int id)
        {
            return await context.Artworks.FindAsync(id);
        }

        public void Update(Artwork artwork)
        {
            context.Artworks.Update(artwork);
        }
    }
}
