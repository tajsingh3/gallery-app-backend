using System;
using GalleryApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GalleryApi.Extensions
{
    public static class DatabaseSeed
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser { Id = "1", UserName = "Taj" }, new ApplicationUser { Id = "2", UserName = "Rani" }, new ApplicationUser { Id = "3", UserName = "markingram" });
            builder.Entity<Artwork>().HasData(new Artwork { Id = 1, Name = "Superman", Description = "My superman portrait", ImageUrl = "images/super.jpg", ApplicationUserId = "1" }, new Artwork { Id = 2, Name = "Batman", Description = "My Batman portrait", ImageUrl = "images/batman.jpg", ApplicationUserId = "2" });
        }
    }
}
