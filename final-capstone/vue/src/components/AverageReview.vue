<template>
  <div>
      <h3>
          Average Review: {{ averageRating }}
      </h3>  
  </div>
</template>

<script>
import ReviewService from '../services/ReviewService.js';


export default {
    name: 'average-review',
    props: {
        beerId: Number,
        showAll: Boolean,
        rating: Number
    },
    data() {
        return {
            reviews: []
        }
    },
    computed: {
        averageRating() {
            const sum = this.reviews.reduce(
                (currentSum, review) => {
                    return currentSum + review.rating
                },0
            )
            return sum / this.reviews.length;
        }
    },
    created() {
        ReviewService.getAllReviews().then(response => {
            this.reviews = response.data.filter(beer => beer.beerId == this.beerId);
        })
    }
}
</script>

<style>

</style>