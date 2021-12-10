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
        components: {ReviewDetail},
        data() {
            return {
                reviews: []
            }
        },
        created(){
            ReviewService.getAllReviews().then(response => {
                    this.reviews = response.data;
            });
        }
    }   