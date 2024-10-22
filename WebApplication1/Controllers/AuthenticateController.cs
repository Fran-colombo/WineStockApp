using Common.Models;
using Data.Entities;
using Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Service.Implementation;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Winery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
    private readonly IConfiguration _config;
    private readonly UserService _userService; 
    public AuthenticateController(UserService userService, IConfiguration config)
    {
      _userService = userService;
      _config = config;
    }
    [HttpPost] 
    public IActionResult Authenticate([FromBody] CredentialsToAuthenticateDto credentials)
    {
      User? userAuthenticated = _userService.AuthenticateUser(credentials.Username, credentials.Password);
      if (userAuthenticated is not null)
      {


        
        var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Authentication:SecretForKey"])); 

        SigningCredentials signature = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

        
        var claimsForToken = new List<Claim>();
        claimsForToken.Add(new Claim("sub", userAuthenticated.Id.ToString())); 
        claimsForToken.Add(new Claim("given_name", userAuthenticated.Username)); 


        var jwtSecurityToken = new JwtSecurityToken( 
          _config["Authentication:Issuer"],
          _config["Authentication:Audience"],
          claimsForToken,
          DateTime.UtcNow,
          DateTime.UtcNow.AddHours(1),
          signature);

        var tokenToReturn = new JwtSecurityTokenHandler() 
        .WriteToken(jwtSecurityToken);

        return Ok(tokenToReturn);
      }
      return Unauthorized();
    }
  }
}
