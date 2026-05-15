using BookingSystem.Application.DTOS.AuthDTOS;
using BookingSystem.Application.InterfaceService;
using BookingSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.ImplementationService
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _config;
        private readonly UserManager<User> _usermanger;

        public AuthService(UserManager<User> userManager , IConfiguration configuration) {
        
            _config = configuration;
            _usermanger = userManager;

        }
        public async Task<string> Login(LoginDto loginDto)
        {
            var user = await _usermanger.FindByEmailAsync(loginDto.Email);
            if (user == null)
                throw new Exception("Invalid email or password");
            var vaild = await _usermanger.CheckPasswordAsync(user, loginDto.Password);
            if (!vaild)
                throw new Exception("Invalid email or password");
            var clamis = new[] {
            
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Email,user.Email)
            
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token=new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                clamis,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
