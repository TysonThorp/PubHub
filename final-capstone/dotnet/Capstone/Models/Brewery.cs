using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Brewery
    {
        public int BreweryId { get; set; }
        public int BreweryOwnerId { get; set; }
        public string BreweryName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string ImageTwo { get; set; }
        public string ImageThree { get; set; }
        public string Website { get; set; }
        public string Address { get; set; }
        public string HoursOfOperation { get; set; }
        public bool IsActive { get; set; }

    }
}
