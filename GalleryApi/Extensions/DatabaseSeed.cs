using System;
using GalleryApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GalleryApi.Extensions
{
    public static class DatabaseSeed
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser { Id = "1", UserName = "Taj" });
            builder.Entity<Artwork>().HasData(new Artwork { Id = 1, Name = "Superman", Description = "My superman portrait", ApplicationUserId = "1" });
        }
    }
}
