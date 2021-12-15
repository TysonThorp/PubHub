<template>
    <div id="breweries">
      <div v-if="this.$store.state.user.role === 'brewer'">
      <h1>My Breweries</h1>
        <brewery-list :userId="this.$store.state.user.userId"/>
      </div>
        <h1>Breweries</h1>
      <brewery-list :showAll="true"/>
      <div v-if="this.$store.state.user.role === 'admin'">
        <brewery-form />
      </div>
    </div>
</template>

<script>
import BreweryList from "../components/BreweryList.vue"
import BreweryForm from "../components/BreweryForm.vue"

export default {
  name: "Breweries",
  components: { 
      BreweryList,
      BreweryForm 
  }
};
</script>

<style>
</style>