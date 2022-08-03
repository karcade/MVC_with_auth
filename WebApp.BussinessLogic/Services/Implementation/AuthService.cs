using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.BussinessLogic.Services.Interfaces;
using AutoMapper;
using WebApp.Model;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using WebApp.Common.ViewModels.Auth;
using WebApp.Model.DatabaseModels;
using WebApp.Common.ViewModels;

namespace WebApp.BussinessLogic.Services.Implementation
{
    public class AuthService:IAuthService
    {
        private readonly IMapper _mapper;
        private readonly SymmetricSecurityKey _key;

        public AuthService(IConfiguration config) =>
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));

        public string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId,user.Username)
            };
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public TokenModel GetToken(User user)
        {
            var token = GenerateToken(user);
            var tokenHandler = new JwtSecurityTokenHandler();
            var mappedUser = _mapper.Map<User, UserModel>(user);
            return new TokenModel
            {
                Token =token,
                UserId = user.Id,
                User = mappedUser,
            };
        }
    }
}
