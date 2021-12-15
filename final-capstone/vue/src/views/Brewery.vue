<template>
    <div v-if="isLoaded">
        <brewery-detail :breweryId="brewery.breweryId" context="brewery-individual"/>
        <update-brewery :breweryId="brewery.breweryId"/>
        <h2>Beers:</h2>
        <beer-list :breweryId="brewery.breweryId" :showDelete="isBrewer"/>
    </div>
</template>

<script>
import BreweryDetail from '../components/BreweryDetail.vue';
import BreweryService from '../services/BreweryService.js';
import BeerList from '../components/BeerList.vue';
import UpdateBrewery from '../components/UpdateBrewery.vue'


export default {
    components: { 
        BreweryDetail, 
        BeerList,
        UpdateBrewery
    },
    data() {
        return {
            brewery: {},
            isLoaded: false
        }
    },
    computed: {
        isBrewer(){
            return this.$store.state.user.userId === this.brewery.breweryOwnerId;
        }
    },
    created() {
        BreweryService.getBreweryById(parseInt(this.$route.params.breweryId)).then((response) => {
            this.brewery = response.data;
            this.isLoaded = true;
        });
    }
    
}
</script>
    

<style>

</style>