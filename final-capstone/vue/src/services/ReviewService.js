import axios from 'axios';

export default {

  getAllReviews() {
    return axios.get('/review')
  },

  getReviewById(reviewId) {
      return axios.get(`/review/${reviewId}`)
  },

  addReview(review) {
      return axios.post('/review', review)
  },

  // NOTE: Controller takes reviewId and review as parameters.  
  updateReview(review) {
      return axios.put(`/review/${review.reviewId}`, review)
  }, 

  deleteReview(reviewId) {
      return axios.delete(`/review/${reviewId}`)
  }
}