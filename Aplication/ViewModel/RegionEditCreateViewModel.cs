using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.ViewModel
{
    public class RegionEditCreateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public RegionViewModel Region { get; set; }
    }
}
