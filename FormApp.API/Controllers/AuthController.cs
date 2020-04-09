using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FormApp.API.Data;
using FormApp.API.Dtos;
using FormApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FormApp.API.Controllers
{
    [Route("app/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            _config = config;
            _repo = repo;
        }

        /// <summary>
        /// Rejestracja użytkownika
        /// </summary>
        [HttpPost("rejestracja")]
        public async Task<IActionResult> Rejestracja(UserDlaRejestracjiDto userDlaRejestracjiDto)
        {
            userDlaRejestracjiDto.Username = userDlaRejestracjiDto.Username.ToLower();

            if (await _repo.UserExists(userDlaRejestracjiDto.Username))
                return BadRequest("Nazwa użytkownika istnieje!!!");

            var uzytkownikDoUtworzenia = new User
            {
                Username = userDlaRejestracjiDto.Username
            };

            var utworzUzytkownika = await _repo.Rejestracja(uzytkownikDoUtworzenia, userDlaRejestracjiDto.Password);

            return StatusCode(201);
        }

        /// <summary>
        /// Logowanie użytkownika
        /// </summary>
        [HttpPost("logowanie")]
        public async Task<IActionResult> Logowanie(UserDlaLogowaniaDto userDlaLogowaniaDto)
        {
            var userFromRepo = await _repo.Logowanie(userDlaLogowaniaDto.Username.ToLower(), userDlaLogowaniaDto.Password);

            if (userFromRepo == null)
                return Unauthorized("Błędne dane logowania!!!");

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();   

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new {
                token = tokenHandler.WriteToken(token)
            });
        }
    }
}