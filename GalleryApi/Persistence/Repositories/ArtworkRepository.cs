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

        public async Task<IEnumerable<Artwork>> MyArtListAsync(string userId)
        {
            return await context.Artworks.Where(a => a.ApplicationUserId.Equals(userId)).ToListAsync<Artwork>();
        }
    }
}
