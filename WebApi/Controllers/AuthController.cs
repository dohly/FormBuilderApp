using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Gateways;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// Dummy users (just for demo)
        /// </summary>
        /// <returns></returns>
        [HttpGet("TestAccounts")]
        [ProducesResponseType(typeof(IEnumerable<User>), 200)]
        public IEnumerable<User> GetTestUsers()
        {
            return DummyGuard.TestUsers;
        }
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="credentials">Credentials</param>
        /// <returns>Access token</returns>
        /// <response code="200">Returns access token</response>
        /// <response code="401">Invalid credentials</response> 
        /// <response code="500">Something is wrong on server</response> 
        [HttpPost]
        [ProducesResponseType(typeof(TokenDto), 200)]
        public async Task<IActionResult> Post([FromBody]UserCredentials credentials,
            [FromServices]ISecurityService guard,
            [FromServices]IConfiguration config)
        {
            var user = await guard.GetUserByCredentials(credentials.Login, credentials.Password);
            if (user == null)
            {
                return Unauthorized();
            }
            return Ok(new TokenDto
            {
                Token = IssueJWT(user, config)
            });
        }
        private string IssueJWT(User user, IConfiguration config)
        {
            var tokenconfig = config.GetSection("Token");
            string secret = tokenconfig.GetSection("Secret").Value;
            string issuer = tokenconfig.GetSection("Issuer").Value;
            string audience = tokenconfig.GetSection("Audience").Value;
            var lifetime = int.Parse(tokenconfig.GetSection("Lifetime").Value);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(lifetime),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}