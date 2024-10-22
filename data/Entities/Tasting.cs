using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Tasting

    {
    // fecha, nombre, vinos y lista de invitados (Lista de strings)
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? Name { get; set; }
        public List <Wine> Wines { get; set; } = new List <Wine>();
        public List<string>? Guests { get; set; }
    }

}
