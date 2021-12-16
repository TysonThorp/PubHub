<template>
  <div class="reviews">
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