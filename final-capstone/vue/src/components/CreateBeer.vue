<template>
    <v-form v-on:submit.prevent='postBeer'>
        <v-row>
        <v-col>
        <v-text-field
            type="text"
            label="Name"
            v-model="beer.beerName"
            required
        />
        
        <v-text-field
            type="text"
            label="Description"
            v-model="beer.description"
            required
        />
        </v-col>
        <v-col>
        <v-text-field
            type="text"
            label="Image"
            v-model="beer.image"
            required
        />
        <v-row>
        <v-col>

        <v-text-field
            type="text"
            label="Type"
            v-model="beer.beerType"
            required
        />
        </v-col>
        <v-col>
        <v-text-field
            type="number"
            label="% ABV"
            v-model.number="beer.abv"
            step="0.1"
            required
        />
        </v-col>
        </v-row>
        </v-col>
        </v-row>

        <v-btn type="submit">Submit</v-btn>
    </v-form>
</template>

<script>
import BeerService from '../services/BeerService.js';

export default {
    name: 'create-beer',
    props: ['breweryId'],
    data() {
    return {
      beer: {
        beerName: "",
        description: "",
        image: "",
        abv: 0,
        beerType: "",
        breweryId: this.breweryId}
    };
  },
  created() {
    },
  methods: {
      postBeer(){
           BeerService.addBeer(this.beer).then((response) => {
            if (response.status == 200) {
            this.$router.go();
          }
        });
      }
        
       
    }
}
</script>

<style>

</style>