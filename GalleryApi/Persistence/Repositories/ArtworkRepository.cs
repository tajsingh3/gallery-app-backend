using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalleryApi.Domain.Models;
using GalleryApi.Domain.Models.Queries;
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

        //public async Task<IEnumerable<Artwork>> CommunityArtworkListAsync()
        //{

        //    return await context.Artworks.ToListAsync<Artwork>();
        //}
        public async Task<QueryResult<Artwork>> CommunityArtworkListAsync(Query query)
        {
            var queryable = context.Artworks;

            int totalItems = await queryable.CountAsync();

            var artworks = await queryable.Skip<Artwork>((query.Page - 1) * query.ItemsPerPage)
                                          .Take<Artwork>(query.ItemsPerPage)
                                          .ToListAsync();

            return new QueryResult<Artwork> { Items = artworks, TotalItems = totalItems };
        }

        //public async Task<IEnumerable<Artwork>> MyArtworkListAsync(string userId)
        //{
        //    return await context.Artworks.Where(a => a.ApplicationUserId.Equals(userId)).ToListAsync<Artwork>();
        //}
        public async Task<QueryResult<Artwork>> MyArtworkListAsync(string userId, Query query)
        {
            var queryable = context.Artworks;

            int totalItems = await queryable.Where(a => a.ApplicationUserId.Equals(userId)).CountAsync();

            var artworks = await queryable.Where(a => a.ApplicationUserId.Equals(userId))
                                    .Skip<Artwork>((query.Page - 1) * query.ItemsPerPage)
                                    .Take<Artwork>(query.ItemsPerPage).ToListAsync();

            return new QueryResult<Artwork> { Items = artworks, TotalItems = totalItems };
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

        public void Delete(Artwork artwork)
        {
            context.Artworks.Remove(artwork);
        }
    }
}
