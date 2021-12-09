using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class BreweriesController : ControllerBase
    {
        private readonly IBreweryDao breweryDao;

        public BreweriesController(IBreweryDao _breweryDao)
        {
            breweryDao = _breweryDao;
        }

        [HttpGet]
        [AllowAnonymous]
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
        [AllowAnonymous]
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
        [Authorize(Roles = "brewer, admin")]
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
        [Authorize(Roles = "brewer, admin")]
        public IActionResult UpdateBrewery(int breweryId, Brewery brewery)
        {
            //Todo: Logic for checking request validity before we actually interact with the database
            // Brewers should only be able to update their own brewery. Admins can update any brewery.
            Brewery breweryToUpdate = breweryDao.GetBrewery(breweryId);
            if (breweryToUpdate != null)
            {
                breweryDao.UpdateBrewery(brewery);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{breweryId}")]
        [Authorize(Roles = "brewer, admin")]
        public IActionResult DeleteBrewery(int breweryId)
        {
            //Todo: Logic for checking request validity before we actually interact with the database
            // Brewers should only be able to delete their own brewery. Admins can update any brewery.
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