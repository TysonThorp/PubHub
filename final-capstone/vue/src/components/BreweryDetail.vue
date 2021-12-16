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
                    <li>Email: <a :href="'mailto:' + brewery.emailAddress">{{brewery.emailAddress}}</a></li>
                    <li>Website: <a target="blank" :href="brewery.website">{{brewery.website}}</a></li>
                    <li><p>Hours: <span v-html="brewery.hoursOfOperation"></span></p></li>
                </ul>
                <div class="grid-container">
                    <div>
                        <img v-bind:src="'/img/' + brewery.image" />
                    </div>
                    <div>
                        <img v-bind:src="'/img/' + brewery.imageTwo" />
                    </div>
                    <div>
                        <img v-bind:src="'/img/' + brewery.imageThree" />
                    </div>
                </div>
            </div>
            <div v-if="this.$store.state.user.userId == brewery.breweryOwnerId">
                <h2>Update Brewery:</h2>
                <update-brewery :breweryId="breweryId"/>
                <h2>Add a beer:</h2>
                <create-beer :breweryId="breweryId"/>
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
            </div>
            <div class="grid-container-2">
                    <div>
                        <img v-bind:src="'/img/' + brewery.image" />
                    </div>
                    <div>
                        <img v-bind:src="'/img/' + brewery.imageTwo" />
                    </div>
                    <div>
                        <img v-bind:src="'/img/' + brewery.imageThree" />
                    </div>
                </div>
        </v-card>
    </div>
</template>

<script>
import BreweryService from '../services/BreweryService';
import CreateBeer from './CreateBeer.vue';
import UpdateBrewery from './UpdateBrewery.vue';

export default {
    name: 'brewery-detail',
        props: {
        breweryId: Number,
        context: String
    },
    components: {CreateBeer, UpdateBrewery},
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
.breweryItem {
    margin-bottom: 1em;
}
.grid-container img {
    width: 100%;
    height: 100%;
    max-height: 200px;
    object-fit: cover;
    display: block;
}
.grid-container {
    display: grid;
    grid-auto-flow: column;
    grid-auto-columns: 1fr;
    border-radius: 0px 0px 4px 4px;
    overflow: hidden;
    margin-bottom: 1em;
}

.grid-container-2 img {
    width: 100%;
    height: 100%;
    max-height: 80px;
    object-fit: cover;
    display: block;
}

.grid-container-2 {
    display: grid;
    grid-auto-flow: column;
    border-radius: 0px 0px 4px 4px;
    grid-auto-columns: 1fr;
    overflow: hidden;
}
</style>