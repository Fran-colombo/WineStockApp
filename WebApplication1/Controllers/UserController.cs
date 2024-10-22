using Common.Models;
using Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Implementation;
using Service.Interface;

namespace Winery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        // Un solo constructor que recibe ambas dependencias
        public UserController( UserService userServices)
        {

            _userService = userServices;
        }
      [HttpPost]
      public IActionResult Add([FromBody] UserForCreationDto userDto)
      {

        _userService.AddUser(userDto);
        return Ok("The user has been created");

      }
  }
    
}
