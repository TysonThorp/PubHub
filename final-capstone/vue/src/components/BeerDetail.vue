<template>
    <v-card elevation="2" class="beerItem" :to="link">
        <v-card-title><h3>{{beer.beerName}}</h3></v-card-title>
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
                beerId: '',
                beerName: '',
                beerType: '',
                description: '',
                image: '',
                abv: ''
            }
        }
    },
    computed: {
        link() {
            return "/beers/" + this.beerId;
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

    .beerItem h3{
        font-size: 1em;
    }

</style>