<template>
    <div>
        <h1>
            {{ beer.beerName }}
        </h1>
        <ul>
            <li>{{ beer.description }}</li>
            <li>{{ beer.beerType }}</li>
        </ul>
    </div>
</template>

<script>
import BeerService from '../services/BeerService.js'

export default {
    name: 'beer-detail',
    data() {
        return {
            beer: {
                beerName: '',
                beerType: '',
                description: '',
                image: ''
            }
        }
    },
    created() {
        const beerId = this.$route.params.breweryId;

        BeerService.getBeerById(beerId).then((response) => {
            this.beer = response.data;
        });
    }
}
</script>

<style>

</style>