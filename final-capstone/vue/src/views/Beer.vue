<template>
    <beer-detail :beerId="this.$route.params.beerId"/>
</template>

<script>
import BeerDetail from '../components/BeerDetail.vue'

export default {
  components: { 
      BeerDetail 
  },

}
</script>

<style>

</style>