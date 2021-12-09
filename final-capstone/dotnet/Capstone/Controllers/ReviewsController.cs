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
        private readonly IUserDao userDao;
        private readonly IBeerDao beerDao;
        private User CurrentUser
        {
            get {
                int currentUserId = int.Parse(User.FindFirst("sub")?.Value);
                return userDao.GetUser(currentUserId);
            }
        }

        public ReviewsController(IReviewDao _reviewDao, IUserDao _userDao, IBeerDao _beerDao)
        {
            reviewDao = _reviewDao;
            userDao = _userDao;
            beerDao = _beerDao;
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
            // LOGIC
            //You may only review a beer that exists
            if (beerDao.GetBeerById(review.BeerId) == null) return BadRequest();

            //You may not create a review with someone else's userId
            if (review.UserId != CurrentUser.UserId) return Unauthorized();
 
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
        public IActionResult UpdateReview(Review review)
        {
            Review reviewToUpdate = reviewDao.GetReview(review.ReviewId);

            // LOGIC
            //You may only review a beer that exists
            if (beerDao.GetBeerById(review.BeerId) == null) return BadRequest();

            //You may only update a review you created yourself
            if (reviewToUpdate.UserId != CurrentUser.UserId || review.ReviewId != CurrentUser.UserId) return Unauthorized();
            
            if (reviewToUpdate != null)
            {
                reviewDao.UpdateReview(review);
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
            Review reviewToDelete = reviewDao.GetReview(reviewId);

            //LOGIC
            //You may only delete a review if you created it or if you are an administrator
            if (!(reviewToDelete.UserId == CurrentUser.UserId || CurrentUser.Role == "admin")) {
                return Unauthorized();
              }
            
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