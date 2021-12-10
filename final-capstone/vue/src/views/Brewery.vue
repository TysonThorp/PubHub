<template>
    <div>
        <brewery-detail v-bind:breweryId="this.$route.params.breweryId" :showFull="true"/>
        <v-card>
            <v-card-title>
                This Brewery's Beers:
            </v-card-title>
        </v-card>
    </div>
</template>

<script>
import BreweryDetail from '../components/BreweryDetail.vue'

export default {
    components: { 
        BreweryDetail 
    },
}
</script>
    

<style>

</style>