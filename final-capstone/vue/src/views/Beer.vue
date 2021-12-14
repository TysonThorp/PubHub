<template>
  <div>
    <beer-detail :beerId="parseInt(this.$route.params.beerId)" context="beer-individual"/>
   
      <h2>Reviews:</h2>
      <review-list :beerId="parseInt(this.$route.params.beerId)"/>

      <h2>Review this beer:</h2>
      <review-beer :beerId="parseInt(this.$route.params.beerId)"/>
  </div>
</template>

<script>
import BeerDetail from '../components/BeerDetail.vue'
import ReviewBeer from '../components/ReviewBeer.vue';
import ReviewList from '../components/ReviewList.vue'


export default {
  components: { 
      BeerDetail,
      ReviewList,
      ReviewBeer 
  },

}
</script>

<style>

</style>