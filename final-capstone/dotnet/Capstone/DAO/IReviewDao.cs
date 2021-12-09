using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IReviewDao
    {
        Review AddReview(Review review);
        Review GetReview(int breweryId);
        List<Review> GetAllReviews();
        Review UpdateReview(Review review);
        void DeleteReview(int reviewId);
    }
}
