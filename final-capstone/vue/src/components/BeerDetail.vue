<template>
    <v-card elevation="2" class="beerItem" :href="link">
        <v-card-title><h2>{{beer.beerName}}</h2></v-card-title>
        <v-card-subtitle>{{ beer.beerType }}</v-card-subtitle>
        <v-card-text>
            {{ beer.description }} ABV: {{beer.abv }}
        </v-card-text>
    </v-card>
</template>

<script>
import BeerService from '../services/BeerService.js'

export default {
    name: 'beer-detail',
    props: {
        beerId: Number
    },
    data() {
        return {
            beer: {
                beerName: '',
                beerType: '',
                description: '',
                image: '',
                abv: ''
            }
        }
    },
    created() {
        
        BeerService.getBeerById(this.beerId).then((response) => {
            this.beer = response.data;
        });
    }
}
</script>

<style>

    .beerItem{
        margin-bottom: 1em;
    }

    h2{
        font-size: 1em;
    }

</style>