<template>
    <div>
        <brewery-detail :breweryId="parseInt(this.$route.params.breweryId)" context="brewery-individual"/>
        <h2>Beers:</h2>
        <beer-list :breweryId="parseInt(this.$route.params.breweryId)"/>
    </div>
</template>

<script>
import BreweryDetail from '../components/BreweryDetail.vue';
import BeerList from '../components/BeerList.vue';

export default {
    components: { 
        BreweryDetail, BeerList
    },
    
}
</script>
    

<style>

</style>