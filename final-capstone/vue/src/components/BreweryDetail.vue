<template>
    <v-card class="breweryItem" :to="link">
        <v-card-title><h3>{{brewery.breweryName}}</h3></v-card-title>
        <v-card-subtitle>{{ brewery.address }}</v-card-subtitle>
        <v-card-text v-if="showFull">
            {{ brewery.description }}
            <ul>
                <li>Phone: {{ brewery.phoneNumber }}</li>
                <li>Email: {{brewery.emailAddress }}</li>
                <li>Website: {{brewery.website }}</li>
                <li>Hours: {{ brewery.hoursOfOperation }}</li>
            </ul>
        </v-card-text>
    </v-card>
</template>

<script>
import BreweryService from '../services/BreweryService';

export default {
    name: 'brewery-detail',
    props: {
        breweryId: Number,
        showFull: Boolean
    },
    data() {
        return {
            brewery: {
                breweryName: '',
                emailAddress: '',
                phoneNumber: '',
                website: '',
                description: '',
                hoursOfOperation: '',
                address: ''
            }
        }
    },
    computed: {
        link() {
            return "/breweries/" + this.breweryId
        } 
    },
    created() {
        //const breweryId = this.$route.params.breweryId;

        BreweryService.getBreweryById(this.breweryId).then((response) => {
            this.brewery = response.data;
        });
    }
}
</script>

<style scoped>

    h2{
        font-size: 1em;
    }
    .breweryItem{
        margin-bottom: 1em;
    }

</style>