<template>
    <brewery-detail v-bind:breweryId="this.$route.params.breweryId" :showFull="true"/>
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