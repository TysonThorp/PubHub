<template>
    <div id="breweries">
      <div v-if="this.$store.state.user.role === 'brewer'">
      <h1>My Breweries</h1>
        <brewery-list :userId="this.$store.state.user.userId"/>
      </div>
        <h1>Breweries</h1>
      <brewery-list :showAll="true"/>
    </div>
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