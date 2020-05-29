using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TouristWebAPI.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TouristWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class AcountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AcountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<ActionResult<JwtTokenResult>> Token([FromQuery] Login login)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(login.Email);
                var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);

                var roleClaims = (await _userManager.GetRolesAsync(user)).Select(role => new Claim(ClaimTypes.Role, role));

                var claims = new[]
                             {
                                 new Claim(JwtRegisteredClaimNames.Sub, login.Email),
                                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                                 new Claim(JwtRegisteredClaimNames.UniqueName, login.Email),
                                 //new Claim(BuyerClaim.BuyerId, user.BuyerId.ToString()),
                             };

                claims = claims.Concat(roleClaims).ToArray();

                if (result.Succeeded)
                {
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtInfo.Key));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(JwtInfo.Issuer, JwtInfo.Audience, claims, expires: DateTime.Now.AddHours(1), signingCredentials: creds);

                    var tokenResult = new JwtTokenResult
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(token)
                    };

                    return tokenResult;
                }

                return BadRequest();
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error occured during creating token. Exception: {exception.Message}");
                return BadRequest();
            }
        }
    }
}