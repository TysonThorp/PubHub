<template>
    <div>
        <div v-if="context === 'beer-individual'" class="beerItem">
            <div>
                <h1 style="font-size: 1.8em">{{beer.beerName}}</h1>
                <p>{{ beer.beerType }} | ABV: {{beer.abv }}</p>
                <p>{{ beer.description }}</p>
            </div>
            <div style="margin-left: auto; display: flex; align-items: center;">
                <img :src='"/img/"+ beer.image' class="beer-image">
            </div>
        </div>

        <v-card v-else class="beerItem" :to="link">
            <div>
                <v-card-title><h3>{{beer.beerName}}</h3></v-card-title>
                <v-card-subtitle>{{ beer.beerType }}</v-card-subtitle>
                <v-card-text>
                {{ beer.description }} ABV: {{beer.abv }} 
                </v-card-text>
            </div>
            <div style="margin-left: auto; display: flex; align-items: center;">
                <img :src='"/img/"+ beer.image' class="beer-image">
            </div>
        </v-card>

        
    </div>
</template>

<script>
import BeerService from '../services/BeerService.js'

export default {
    name: 'beer-detail',
    props: {
        beerId: Number,
        context: String
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
            },
                      
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

<style scoped>

    .beerItem{
        margin-bottom: 1em;
        display: flex;
    }

    h2{
        font-size: 1em;
    }

    .beer-image{
       object-fit: cover;
        width:120px;
        height:120px;
    }

</style>