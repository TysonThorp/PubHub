<template>
    <div>
        <div v-if="context === 'brewery-individual'" class="breweryItem">
            <div>
                <h1 style="font-size: 1.8em">{{ brewery.breweryName }}</h1>
                
                <p v-if="this.$store.state.user.userId === brewery.breweryOwnerId">
                    (<v-icon>mdi-heart</v-icon> You own this brewery.)
                </p> 
                <p>{{ brewery.address }}</p>
                <p>{{ brewery.description }}</p>
                <ul>
                    <li>Phone: {{ brewery.phoneNumber }}</li>
                    <li>Email: {{ brewery.emailAddress }}</li>
                    <li>Website: {{ brewery.website }}</li>
                    <li><p>Hours: {{ brewery.hoursOfOperation }}</p></li>
                </ul>
                <img v-bind:src='"/img/"+ brewery.image' >
                <img v-bind:src='"/img/"+ brewery.imageTwo' >
                <img v-bind:src='"/img/"+ brewery.imageThree' >
            </div>
            <div v-if="this.$store.state.user.userId == brewery.breweryOwnerId">
                <h2>Add a beer:</h2>
            </div> 
        </div>

        <v-card v-else class="breweryItem" :to="link">
            <div>
                <v-card-title>
                    <h3>{{ brewery.breweryName }}</h3>
                </v-card-title>
                <v-card-subtitle><span v-if="this.$store.state.user.userId === brewery.breweryOwnerId">
                    (<v-icon>mdi-heart</v-icon> You own this brewery.)
                </span> {{ brewery.address }}</v-card-subtitle>
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
                breweryOwnerId: '',
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

        BreweryService.getBreweryById(this.breweryId).then((response) => {
            this.brewery = response.data;
        });
    }
}
</script>

<style scoped>
    .breweryItem{
        margin-bottom: 1em;
    }
      img{
        max-width: 25%;  
        height: auto;  
    }

</style>