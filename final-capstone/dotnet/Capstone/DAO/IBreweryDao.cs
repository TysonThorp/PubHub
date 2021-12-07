using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IBreweryDao
    {
        Brewery AddBrewery(Brewery brewery);
        Brewery GetBrewery(int breweryId);
        List<Brewery> GetAllBreweries();
        Brewery UpdateBrewery(int breweryId, Brewery brewery);
        void DeleteBrewery(int breweryId);
    }
}
