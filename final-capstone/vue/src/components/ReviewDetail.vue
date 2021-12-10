<template>
    <table>
 
    <tbody>
      
        <td>{{reivew.reviewText}}</td>
        <td>{{review.Rating}}</td>  
         
     
    </tbody>
  </table>
</template>

<script>
import ReviewService from '../services/ReviewService.js'

export default {
    name: 'review-detail',
    props: {
        reviewId: Number
    },
    data() {
        return {
            review: {
                reviewText: '',
                Rating: '',
            }
        }
    },
    created() {
        
        ReviewService.getReviewById(this.reviewId).then((response) => {
            this.review = response.data;
        });
    }
}
</script>

<style>

</style>