using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class UpdateStockByIdDto
    {
        public int Id { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "You can´t add a stock slower than 1")]

        public int Stock { get; set; }
    }
}
