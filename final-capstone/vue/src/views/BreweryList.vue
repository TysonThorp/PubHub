<template>
  <v-container>
    <brewery-list />
  </v-container>  
</template>

<script>
import BreweryList from "../components/BreweryList.vue"

export default {
  name: "Breweries",
  components: { 
      BreweryList 
  }
};
</script>

<style>
</style>
