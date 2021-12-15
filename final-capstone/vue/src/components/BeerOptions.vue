<template>
    <v-btn v-on:click.prevent='DeleteBeer'>Remove</v-btn>
</template>

<script>
import BeerService from '../services/BeerService';
export default {
    name: 'beer-options',
    components: {
    },
    props: {
        beer: Object
    },
    methods: {
      DeleteBeer(){
           BeerService.deleteBeer(this.beer.beerId).then((response) => {
            if (response.status == 200) {
            this.$router.go();
            }
        });
      }
    }
}
</script>