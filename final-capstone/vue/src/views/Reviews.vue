<template>
  <div class="reviews">
      <div v-if="this.$store.state.user.role != null">
      <h1>My Reviews</h1>
        <review-list :userId="this.$store.state.user.userId"/>
      </div>
     <h1>Top-Rated Brews</h1>
     <review-list :showAll="true"/>
  </div>
</template>

<script>

import ReviewList from "../components/ReviewList.vue"

export default {
    components:{
        ReviewList
    }

}
</script>

<style>

</style>