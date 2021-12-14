<template>
    <div>
        <div v-if="context === 'brewery-individual'" class="breweryItem">
            <div>
                <h1 style="font-size: 1.8em">{{ brewery.breweryName }}</h1>
                <p>{{ brewery.address }}</p>
                <p>{{ brewery.description }}</p>
                <ul>
                    <li>Phone: {{ brewery.phoneNumber }}</li>
                    <li>Email: {{ brewery.emailAddress }}</li>
                    <li>Website: {{ brewery.website }}</li>
                    <li>Hours: {{ brewery.hoursOfOperation }}</li>
                </ul>
                <img v-bind:src='"/img/"+ brewery.image' >
                <img v-bind:src='"/img/"+ brewery.imageTwo' >
                <img v-bind:src='"/img/"+ brewery.imageThree' >
            </div>
        </div>

        <v-card v-else class="breweryItem" :to="link">
            <div>
                <v-card-title
                    ><h3>{{ brewery.breweryName }}</h3></v-card-title
                >
                <v-card-subtitle>{{ brewery.address }}</v-card-subtitle>
                <img v-bind:src='"/img/"+ brewery.image' >
                <img v-bind:src='"/img/"+ brewery.imageTwo' >
                <img v-bind:src='"/img/"+ brewery.imageThree' >
            </div>
        </v-card>
    </div>
</template>

<script>
import BreweryService from '../services/BreweryService';

export default {
    name: 'brewery-detail',
    props: {
        breweryId: Number,
        context: String
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
      img{
        max-width: 25%;  
        height: auto;  
    }

</style>