<template>
<ul id="beer-list" class="pa-0">
            <div v-for="beer in beers" :key="beer.beerId">
                <beer-detail :beerId="beer.beerId"/>
            </div>
        </ul>
</template>

<script>
 import BeerService from '../services/BeerService.js';
import BeerDetail from '../components/BeerDetail.vue';

    export default {
        name: 'beer-list',
        components: {BeerDetail},
        data() {
            return {
                beers: []
            }
        },
        created(){
            BeerService.getAllBeers().then(response => {
                    this.beers = response.data;
            });
        }
    }   

</script>

<style>

</style>