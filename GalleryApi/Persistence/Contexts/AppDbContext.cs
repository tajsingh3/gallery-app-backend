using System;
using GalleryApi.Domain.Models;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace GalleryApi.Persistence.Contexts
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Artwork> Artworks { get; set; }
        public DbSet<Vote> Votes { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser { Id = "1", UserName = "Taj" });

            builder.Entity<Artwork>().HasData(new Artwork { Id = 1, Name = "dick", Description = "dick", ApplicationUserId = "1" });
        }
    }
}
