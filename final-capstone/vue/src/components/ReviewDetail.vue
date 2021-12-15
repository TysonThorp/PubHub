<template>
    <v-card class="breweryItem">
        <v-card-title>
            <h3>User {{review.userId}} says:</h3>
        </v-card-title>
        <v-card-subtitle>
            <v-rating
            background-color="#eee"
            color="warning"
            length="5"
            readonly
            size="20"
            dense
            :value="parseInt(review.rating)"
            ></v-rating>
        </v-card-subtitle>
        <v-card-text>
            {{ review.reviewText }}
            <router-link :to="this.link">Go to beer</router-link>
        </v-card-text>
    </v-card>
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
                reviewId: '',
                beerId: '',
                userId: '',
                rating: '',
                reviewText: '',
            }
        }
    },
    computed: {
        link() {
            return "/beers/" + this.review.beerId
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

    .breweryItem{
        margin-bottom: 1em;
    }

</style>