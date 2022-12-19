using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Navegation Property
        public ICollection<Pokemon> Pokemons { get; set; }
    }
}
