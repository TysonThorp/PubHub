<template>
    <ul id="review-list" class="pa-0">
        <div v-for="review in reviews" :key="review.reviewId">
            <review-detail :reviewId="review.reviewId"/>
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