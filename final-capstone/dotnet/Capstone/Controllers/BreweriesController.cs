using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BreweriesController : ControllerBase
    {
        private readonly IBreweryDao breweryDao;

        public BreweriesController(IBreweryDao _breweryDao)
        {
            breweryDao = _breweryDao;
        }

        [HttpGet]
        public IActionResult GetAllBreweries()
        {
            List<Brewery> listOfBreweries = breweryDao.GetAllBreweries();
            if (listOfBreweries != null)
            {
                return Ok(listOfBreweries);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{breweryId}")]
        public IActionResult GetBreweryById(int breweryId)
        {
            Brewery brewery = breweryDao.GetBrewery(breweryId);
            if (brewery != null)
            {
                return Ok(brewery);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult AddBrewery(Brewery brewery)
        {
            //Todo: Logic for checking request validity before we actually interact with the database
            Brewery result = breweryDao.AddBrewery(brewery);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{breweryId}")]
        public IActionResult UpdateBrewery(int breweryId, Brewery brewery)
        {
            //Todo: Logic for checking request validity before we actually interact with the database
            Brewery breweryToUpdate = breweryDao.GetBrewery(breweryId);
            if (breweryToUpdate != null)
            {
                breweryDao.UpdateBrewery(breweryId, brewery);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{breweryId}")]
        public IActionResult DeleteBrewery(int breweryId)
        {
            Brewery breweryToDelete = breweryDao.GetBrewery(breweryId);
            if (breweryToDelete != null)
            {
                breweryDao.DeleteBrewery(breweryId);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        
    }
}