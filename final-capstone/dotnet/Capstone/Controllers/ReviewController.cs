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
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewDao reviewDao;

        public ReviewsController(IReviewDao _reviewDao)
        {
            reviewDao = _reviewDao;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAllReviews()
        {
            List<Review> listofReviews = reviewDao.GetAllReviews();
            if (listofReviews != null)
            {
                return Ok(listofReviews);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{reviewId}")]
        [AllowAnonymous]
        public IActionResult GetReviewById(int reviewId)
        {
            Review review = reviewDao.GetReview(reviewId);
            if (review != null)
            {
                return Ok(review);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Authorize(Roles = "user, brewer, admin")]
        public IActionResult AddReview(Review review)
        {
            //Todo: Logic for checking request validity before we actually interact with the database
            // Optionally, brewers shouldn't be able to review their own beers?


            Review result = reviewDao.AddReview(review);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{reviewId}")]
        [Authorize(Roles = "user, brewer, admin")]
        public IActionResult UpdateReview(int reviewId, Review review)
        {
            //Todo: Logic for checking request validity before we actually interact with the database
            // Users should only be able to update their own reviews.
            Review reviewToUpdate = reviewDao.GetReview(reviewId);
            if (reviewToUpdate != null)
            {
                reviewDao.UpdateReview(reviewId, review);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{reviewId}")]
        [Authorize(Roles = "user, brewer, admin")]
        public IActionResult DeleteReview(int reviewId)
        {
            //Todo: Logic for checking request validity before we actually interact with the database
            // Users should only be able to delete their own reviews.
            Review reviewToDelete = reviewDao.GetReview(reviewId);
            if (reviewToDelete != null)
            {
                reviewDao.DeleteReview(reviewId);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        
    }
}