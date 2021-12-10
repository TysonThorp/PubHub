<template>
  <ul id="brewery-list" class="pa-0">
    <div v-for="brewery in breweries" :key="brewery.breweryId">
      <brewery-detail :breweryId="brewery.breweryId" :showFull="false" />
    </div>
  </ul>
</template>

<script>
import BreweryDetail from "../components/BreweryDetail.vue";
import BreweryService from "../services/BreweryService";

export default {
  name: "brewery-list",
  components: { 
    BreweryDetail 
  },
  data() {
    return {
      breweries: [],
    };
  },
  created() {
    BreweryService.getAllBreweries().then((response) => {
      this.breweries = response.data;
    });
  },
};
</script>

<style>
</style>