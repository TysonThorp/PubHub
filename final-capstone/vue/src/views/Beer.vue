<template>
  <div>
    <beer-detail :beerId="this.$route.params.beerId"/>
    <v-card>
      <v-card-title>
          This Beer's Reviews:
      </v-card-title>
    </v-card>
  </div>
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