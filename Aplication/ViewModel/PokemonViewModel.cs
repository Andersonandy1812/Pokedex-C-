using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.ViewModel
{
    public class PokemonViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string URLImage { get; set; }
        public int TypeOfPokemonId { get; set; }

        public int RegionId { get; set; }
        public int? SecondTypeOfPokemonId { get; set; }

    }
}
