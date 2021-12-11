<template>
    <div>
        <brewery-detail :breweryId="this.$route.params.breweryId" :showFull="true"/>
        <h2>Beers:</h2>
        <beer-list :breweryId="this.$route.params.breweryId"/>
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