using System;
using System.Threading.Tasks;
using GalleryApi.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace GalleryApi.Domain.Services
{
    public interface IAuthenticationService
    {
        public Task<IdentityResult> CreateUser(string email, string password);
        public Task<String> Authenticate(string email, string password);
    }
}
