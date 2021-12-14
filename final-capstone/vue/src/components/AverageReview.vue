<template>
  <div>
    <div v-if="reviews.length !== 0">
        <p>
            Average Rating: {{ averageRating }}
        </p>  
    </div>
    <div v-else>
        <p>
            Average Rating: Not Enough Reviews
        </p>
    </div>
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
            
            const average = (sum / this.reviews.length).toFixed(2);
            return average;
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