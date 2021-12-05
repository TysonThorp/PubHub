using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IBeerDao
    {
        Beer AddBeer(Beer beer);
        void DeleteBeer(int beerId);
        List<Beer> GetAllBeers();
    }
}