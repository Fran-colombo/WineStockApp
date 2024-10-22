using Common.Models;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class WineRepository
    {
        private readonly ApplicationContext _context;
        public WineRepository(ApplicationContext context)
        {
            _context = context;
        }


        public ICollection<Wine> GetAllWines() {
            return _context.Wines.ToList();
        }
        public ICollection<Wine>? GetStockedWines()
        {
          return _context.Wines.Where(w => w.Stock >0).ToList();
        }


        public ICollection<Wine>? GetWineByVariety(string variety)
        {
          return _context.Wines.Where(w => w.Variety == variety).ToList();
        }
        public Wine? GetWineById(int Id)
        {
          return _context.Wines.FirstOrDefault(w => w.Id == Id);
        }


    public int AddWine(Wine wine)
        {
          _context.Wines.Add(wine);
          _context.SaveChanges();
          return wine.Id;
        }

        public void UpdateStockById( int Id, int Stock)
        {

          var wineToUpdate = _context.Wines.SingleOrDefault(u => u.Id == Id);
          if (wineToUpdate == null)
          {
            throw new Exception("Wine not found");
          }
          wineToUpdate.Stock = Stock;
          _context.SaveChanges();
        }


    }
}
