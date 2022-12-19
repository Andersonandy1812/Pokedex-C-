using DataBase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.ViewModel
{
    public class PokemonEditCreateViewModel
    {
        //[Required(ErrorMessage = "Debe de colocar Id")]
        public int Id { get; set; }
        //[Required(ErrorMessage = "Debe de colocar el nombre")]
        public string Name { get; set; }
        //[Required(ErrorMessage = "Debe de colocar una imagen")]
        public string URLImage { get; set; }
        //[Required(ErrorMessage = "Debe de colocar un tipo")]
        public int TypeOfPokemonId { get; set; }
        //[Required(ErrorMessage = "Debe de colocar una region")]
        public int RegionId { get; set; }

        public int? SecondTypeOfPokemonId { get; set; }

        public TypeOfPokemon TypeOfPokemon { get; set; }
    }
}
