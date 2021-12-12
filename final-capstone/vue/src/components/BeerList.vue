<template>
  <ul id="beer-list" class="pa-0">
    <li v-for="beer in beers" :key="beer.beerId">
      <beer-detail :beerId="beer.beerId"/>
    </li>
    <div v-if="this.beers.length === 0">
            <v-card id="missing-beer" elevation="0" color="fade">
                <v-icon>mdi-alert</v-icon>
            <p>This brewery has no beers. Kind of weird?</p>
            </v-card>
        </div>
  </ul>
</template>

<script>
 import BeerService from '../services/BeerService.js';
import BeerDetail from '../components/BeerDetail.vue';

    export default {
        name: 'beer-list',
        components: {BeerDetail},
        props: {
          breweryId: Number,
          showAll: Boolean
        },
        data() {
            return {
                beers: []
            }
        },
        created(){
          
          if (this.showAll) {
            BeerService.getAllBeers().then(response => { 
              this.beers = response.data;
            })
          }

          // otherwise, if a breweryId prop was passed as a prop into this component, get beers for a specific brewery
          else if (this.breweryId != 0) {
            BeerService.getBreweryBeers(this.breweryId).then(response => { 
              this.beers = response.data;
            })
          }
          
        }
    }   

</script>

<style scoped>
  #beer-list {
    list-style-type: none;
  }

    #missing-beer{
        margin-bottom: 1em;
        padding: 0.5em;
        font-size: 0.9em;
        text-align: center;
    }

    #missing-beer p {
        margin-bottom: 0.5em;
    }
</style>