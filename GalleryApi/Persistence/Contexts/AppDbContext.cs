﻿using System;
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

            //changing table name
            builder.Entity<ApplicationUser>().ToTable("Users");

            //creating relationships
            builder.Entity<ApplicationUser>().HasMany<Artwork>(user => user.Artworks).WithOne(a => a.User);
            builder.Entity<ApplicationUser>().HasMany<Vote>(user => user.Votes).WithOne(v => v.User);
            builder.Entity<Artwork>().HasMany<Vote>(a => a.Votes).WithOne(v => v.Artwork);

            //making foreign keys required
            builder.Entity<Artwork>().Property(a => a.ApplicationUserId).IsRequired();
            builder.Entity<Vote>().Property(v => v.ApplicationUserId).IsRequired();
            builder.Entity<Vote>().Property(v => v.ArtworkId).IsRequired();

            //seeding tables
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser { Id = "1", UserName = "Taj" });
            builder.Entity<Artwork>().HasData(new Artwork { Id = 1, Name = "Superman", Description = "My superman portrait", ApplicationUserId = "1" });
        }
    }
}
