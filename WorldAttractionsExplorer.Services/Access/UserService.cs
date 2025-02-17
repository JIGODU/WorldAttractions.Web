using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WorldAttractionsExplorer.Common.Enums;
using WorldAttractionsExplorer.DataAccess.DTOs;
using WorldAttractionsExplorer.DataAccess.Models;
using WorldAttractionsExplorer.Services.Contracts;

namespace WorldAttractionsExplorer.Services.Access
{
    public class UserService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration) : IUserContract
    {

        public async Task<bool> RegisterUserAsync(RegisterModel model)
        {
            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email
            };

            var result = await userManager.CreateAsync(user, model.Password);
            return result.Succeeded;
        }

        public async Task<string?> LoginUserAsync(LoginModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null) return null;

            var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

            if (!result.Succeeded) return null;

            var roles = await userManager.GetRolesAsync(user);
            var token = GenerateJwtToken(user, roles);
            return token;
        }

        public async Task<bool> AddRoleToUserAsync(AssignModel assignModel)
        {
            var user = await userManager.FindByIdAsync(assignModel.UserId);
            if (user == null) return false;

            if (!await roleManager.RoleExistsAsync(assignModel.Role)) return false;

            var result = await userManager.AddToRoleAsync(user, assignModel.Role);
            return result.Succeeded;
        }


        private string GenerateJwtToken(IdentityUser user, IList<string> roles)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id),
                new(ClaimTypes.Email, user.Email)
            };
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddHours(int.Parse(configuration["Jwt:ExpirationHours"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
