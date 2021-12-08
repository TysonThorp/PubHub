using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewDao reviewDao;

        public ReviewsController(IReviewDao _reviewDao)
        {
            reviewDao = _reviewDao;
        }

        [HttpGet]
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
        public IActionResult AddReview(Review review)
        {
            //Todo: Logic for checking request validity before we actually interact with the database
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
        public IActionResult UpdateReview(int reviewId, Review review)
        {
            //Todo: Logic for checking request validity before we actually interact with the database
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
        public IActionResult DeleteReview(int reviewId)
        {
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