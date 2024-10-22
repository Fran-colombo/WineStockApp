using Common.Models;
using Data.Entities;

namespace Service.Interface
{
  public interface IWineService
  {
    int AddWine(WineForCreationDto wineDTO);
    IEnumerable<Wine> GetAllWines();
    IEnumerable<Wine>? GetStockedWines();
    Wine? GetWineById(int Id);
    Wine? GetWineByVarirety(string variety);
    void UpdateWineById(UpdateStockByIdDto updateDto);
  }
}