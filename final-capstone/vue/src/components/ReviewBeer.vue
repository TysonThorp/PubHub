<template>
    <v-form v-on:submit.prevent='postReview'>
        <v-rating
            color="warning"
            length="5"
            size="20"
            dense v-model="review.rating"
            ></v-rating>
        <v-text-field label="Description" v-model="review.reviewText"></v-text-field>
        
        <v-btn type="submit">Submit</v-btn>
    </v-form>
</template>

<script>
import ReviewService from '../services/ReviewService.js';

export default {
    name: 'review-beer',
    props: ['beerId'],
    data() {
    return {
      review: {
          userId: this.$store.state.user.userId,
          beerId: this.beerId,
          rating: 0,
          reviewText: ''
      },
    };
  },
  methods: {
      postReview(){
           ReviewService.addReview(this.review).then((response) => {
            if (response.status == 200) {

            this.$router.go();
          }
        });
      }
        
       
    }
}
</script>

<style>

</style>