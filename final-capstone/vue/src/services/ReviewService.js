import axios from 'axios';

export default {

  getAllReviews() {
    return axios.get('/reviews')
  },

  getReviewById(reviewId) {
      return axios.get(`/reviews/${reviewId}`)
  },

  addReview(review) {
      return axios.post('/reviews', review)
  },

  updateReview(review) {
      return axios.put(`/reviews/${review.reviewId}`, review)
  }, 

  deleteReview(reviewId) {
      return axios.delete(`/reviews/${reviewId}`)
  }
}