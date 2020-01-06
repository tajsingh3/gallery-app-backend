using System;
using System.Threading.Tasks;
using GalleryApi.Domain.Models;
using GalleryApi.Domain.Services;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using GalleryApi.Helpers;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace GalleryApi.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly AppSettings appSettings;

        public AuthenticationService(UserManager<ApplicationUser> userManager, IOptions<AppSettings> appSettingsAccessor)
        {
            this.userManager = userManager;
            this.appSettings = appSettingsAccessor.Value;
        }

        public async Task<String> Authenticate(string email, string password)
        {
            var user = await userManager.FindByNameAsync(email);
            if (user == null) return null;

            bool isUserValid = await userManager.CheckPasswordAsync(user, password);
            if (!isUserValid) return null;

            //cresat token now and change method return type
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var signedToken = tokenHandler.WriteToken(token);

            return signedToken;

        }

        public async Task<IdentityResult> CreateUser(string email, string password)
        {
            ApplicationUser user = new ApplicationUser { UserName = email };
            IdentityResult result = await userManager.CreateAsync(user, password);

            return result;

        }
    }
}
