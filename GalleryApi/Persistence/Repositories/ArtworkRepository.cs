using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Artwork>> CommunityArtListAsync()
        {

            return await context.Artworks.ToListAsync<Artwork>();
        }
    }
}
