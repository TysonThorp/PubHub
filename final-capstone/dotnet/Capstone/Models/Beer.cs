using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Beer
    {
        public int BeerId { get; set; }
        public string BeerName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal ABV { get; set; }
        public string BeerType { get; set; }
        public int BreweryId { get; set; }
    }
}
