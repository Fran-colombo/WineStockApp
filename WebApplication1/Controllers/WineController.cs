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
