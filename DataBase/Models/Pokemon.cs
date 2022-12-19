using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class Pokemon
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string URLImage { get; set; }

        public int RegionId { get; set; }

        public int TypeOfPokemonId { get; set; }

        public int? SecondTypeOfPokemonId { get; set; }

        //Navegation Property
        public Region Region { get; set; }

        public TypeOfPokemon TypeOfPokemon { get; set; }
    }
}
