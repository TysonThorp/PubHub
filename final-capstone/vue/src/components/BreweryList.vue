<template>
  <ul id="brewery-list" class="pa-0">
    <li v-for="brewery in breweries" :key="brewery.breweryId">
      <brewery-detail :breweryId="parseInt(brewery.breweryId)" :showFull="false" />
    </li>
    <div v-if="this.breweries.length === 0">
      <v-card id="missing-brewery" elevation="0" color="fade">
          <v-icon>mdi-alert</v-icon>
      <p>You don't have any breweries. Time to start one?</p>
      </v-card>
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
  props: {
      userId: Number,
      showAll: Boolean,
    },
  data() {
    return {
      breweries: [],
    };
  },
  created(){ 
    if (this.showAll) {
      BreweryService.getAllBreweries().then(response => { 
        this.breweries = response.data;
      })
    }

    // otherwise, if a userId was passed into this component as a prop, get breweries owned by a specific user
    else if (this.userId != undefined) {
      BreweryService.getAllBreweries().then(response => { 
        this.breweries = response.data.filter(brewery => brewery.breweryOwnerId == this.userId);
      })
    }
    
  },
};
</script>

<style scoped>
  #brewery-list {
    list-style-type: none;
  }

    #missing-brewery{
        margin-bottom: 1em;
        padding: 0.5em;
        font-size: 0.9em;
        text-align: center;
    }

    #missing-brewery p {
        margin-bottom: 0.5em;
    }
</style>