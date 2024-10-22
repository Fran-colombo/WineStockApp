using Common.Models;
using Data.Entities;
using Data.Repositories;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
  public class WineService : IWineService
  {
    private readonly WineRepository _repository;
    public WineService(WineRepository repository)
    {
      _repository = repository;
    }



    public int AddWine(WineForCreationDto wineDTO)
    {
      if (!_repository.GetAllWines().Any(e => e.Name == wineDTO.Name))
      {
         var newWine = _repository.AddWine(
         new Wine
         {
           Name = wineDTO.Name,
           Variety = wineDTO.Variety,
           Year = wineDTO.Year,
           Region = wineDTO.Region,
           Stock = wineDTO.Stock,
           CreatedAt = DateTime.UtcNow
         });
        return newWine;
      }
      else
      {
        throw new ArgumentException("The Wine already exists."); //que pingo va acá
      }

    }
    public void UpdateWineById(UpdateStockByIdDto updateDto)
    {
      _repository.UpdateStockById(updateDto.Id, updateDto.Stock);

    }

    public IEnumerable<Wine> GetAllWines()
    {
      return _repository.GetAllWines();
    }
    public IEnumerable<Wine>? GetStockedWines()
    {
      return _repository.GetStockedWines();
    }
    public IEnumerable<Wine>? GetWineByVarirety(string variety)
    {
      return _repository.GetWineByVariety(variety);
    }
    public Wine? GetWineById(int Id)
    {
      return _repository.GetWineById(Id);
    }


    Wine? IWineService.GetWineByVarirety(string variety) //eh?
    {
      throw new NotImplementedException();
    }
  }
}
