using Common.Models;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Service.Implementation;
using System.Security.Claims;

namespace Winery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WineController : ControllerBase
    {
        private readonly WineService _wineServices;

        // Un solo constructor que recibe ambas dependencias
        public WineController(WineService wineServices)
        {
            _wineServices = wineServices;
        }


      [HttpGet]
      public IActionResult GetWines([FromQuery] bool includeDeleted = false)
      {
        if (includeDeleted == true)
        {
          return Ok(_wineServices.GetAllWines());
        }
        else
        {
          return Ok(_wineServices.GetStockedWines());
        }
      }


    [HttpGet("{Variety}")]
    public IActionResult GetByVariety([FromRoute] string variety)
    {
      return Ok(_wineServices.GetWineByVarirety(variety));

    }


    //[HttpPost]
    //    public IActionResult AddWine([FromBody] WineForCreationDto wineDTO, WineService wineServices)
    //    {
    //        if (wineDTO == null)
    //        {
    //            return BadRequest("Faltan datos");
    //        }


    //        var result = _wineServices.AddWine(wineDTO);

    //        if (result == null)
    //        {
    //            return Conflict("El vino ya existe.");
    //        }
      

    //    //.Wines.Add(result);
    //        return Ok();
    //    }
    [HttpPost]
    public IActionResult Add([FromBody] WineForCreationDto wineDto)
    {

      _wineServices.AddWine(wineDto);
      return Ok("The wine has been created");

    }


    [HttpPut("{idExperince}")]
    public IActionResult UpdateExperience([FromRoute] int idWine, [FromBody] UpdateStockByIdDto updateDTO)
    {
      int? wine = _wineServices.GetWineById(idWine).Id;
      if (wine.HasValue )
      {
        UpdateStockByIdDto newStockWine = new()
        {
          Stock = updateDTO.Stock

        };

        _wineServices.UpdateWineById(newStockWine);
        return Ok(wine);
      }
      else
      {
        return NotFound("We couldn´t find the wine you are looking for, try with another Id. ");
      }
    }
  }
}
