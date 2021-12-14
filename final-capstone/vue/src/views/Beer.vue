<template>
  <div>
    <beer-detail :beerId="this.$route.params.beerId" context="beer-individual"/>
   
      <h2>Reviews:</h2>
      <review-list :beerId="this.$route.params.beerId"/>

    <v-card>
      <v-card-title>
          Review this beer:
      </v-card-title>
    </v-card>
  </div>
</template>

<script>
import BeerDetail from '../components/BeerDetail.vue'
import ReviewList from '../components/ReviewList.vue'

export default {
  components: { 
      BeerDetail,
    ReviewList 
  },

}
</script>

<style>

</style>