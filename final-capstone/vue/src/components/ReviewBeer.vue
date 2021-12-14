<template>
    <v-form v-on:submit.prevent='postReview'>
        <v-rating
            color="warning"
            half-increments
            length="5"
            size="20"
            dense v-model="review.rating"
            ></v-rating>
        <v-text-field label="Main input" v-model="review.reviewText"></v-text-field>
        
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
  created() {
      //this.review.userId = this.$store.state.user.userId
    },
  methods: {
      postReview(){
           ReviewService.addReview(this.review).then((response) => {
            if (response.status == 200) {
            //this.$store.commit("SET_AUTH_TOKEN", response.data.token);
            //this.$store.commit("SET_USER", response.data.user);
            this.$router.go();
            //this.$router.push("/");
          }
        });
      }
        
       
    }
}
</script>

<style>

</style>