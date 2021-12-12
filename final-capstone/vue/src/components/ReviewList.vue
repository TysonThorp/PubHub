<template>
    <ul id="review-list" class="pa-0">
        <div v-for="review in reviews" :key="review.reviewId">
            <review-detail :reviewId="review.reviewId"/>
        </div>

        <div v-if="this.reviews.length === 0">
            <v-card id="missing-review" elevation="0" color="fade">
                <v-icon>mdi-alert</v-icon>
            <p>No one has reviewed this beer yet. Be the first?</p>
            </v-card>
        </div>

    </ul>
</template>

<script>
    import ReviewService from '../services/ReviewService.js';
    import ReviewDetail from '../components/ReviewDetail.vue';

    export default {
        name: 'review-list',
        props: {
          beerId: Number,
          showAll: Boolean
        },
        components: {ReviewDetail},
        data() {
            return {
                reviews: []
            }
        },
        created(){
          
          if (this.showAll) {
            ReviewService.getAllReviews().then(response => { 
              this.reviews = response.data;
            })
          }

          // otherwise, if a beerId was passed into this component as a prop, get reviews for a specific beer
          else if (this.beerId != 0) {
            ReviewService.getAllReviews().then(response => { 
              this.reviews = response.data.filter(beer => beer.beerId == this.beerId);
            })
          }
          
        }
    }
</script>

<style scoped>
    #missing-review{
        margin-bottom: 1em;
        padding: 0.5em;
        font-size: 0.9em;
        text-align: center;
    }

    #missing-review p {
        margin-bottom: 0.5em;
    }
</style>