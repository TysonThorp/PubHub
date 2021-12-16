<template>
    <div>
        <v-btn block v-on:click="showForm = !showForm">Update Brewery</v-btn>
        <v-form v-on:submit.prevent v-if="showForm == true">
            <v-text-field label="Brewery Name" v-model="brewery.breweryName"></v-text-field>
            <v-text-field label="Email" v-model="brewery.emailAddress"></v-text-field>
            <v-text-field label="Phone" v-model="brewery.phoneNumber"></v-text-field>
            <v-text-field label="Website" v-model="brewery.website"></v-text-field>
            <v-textarea label="Description" v-model="brewery.description"></v-textarea>
            <v-text-field label="Hours of Operation" v-model="brewery.hoursOfOperation"></v-text-field>
            <v-text-field label="Address" v-model="brewery.address"></v-text-field>
            <v-text-field label="Image 1" v-model="brewery.image"></v-text-field>
            <v-text-field label="Image 2" v-model="brewery.imageTwo"></v-text-field>
            <v-text-field label="Image 3" v-model="brewery.imageThree"></v-text-field>

            <v-btn type="submit" v-on:click="updateBreweryDetails">Submit</v-btn> 
        </v-form>
    </div>
</template>

<script>
import BreweryService from "../services/BreweryService";

export default {
    name: "update-brewery",
    props: [
        "breweryId"
    ],
    data() {
        return {
            brewery: {
                breweryId: this.breweryId,
                breweryName: '',
                breweryOwnerId: this.$store.state.user.userId,
                emailAddress: "",
                phoneNumber: "",
                website: "",
                description: "",
                hoursOfOperation: "",
                address: "",
                image: "",
                imageTwo: "",
                imageThree: "",
                isActive: true,
            },
            showForm: false,
        }
    },
    created() {
        BreweryService.getBreweryById(this.breweryId).then((response) => {
            this.brewery = response.data;
        });
    },
    methods: {
        updateBreweryDetails() {
            BreweryService.updateBrewery(this.brewery).then((response) => {
                if (response.status == 200) {
                    this.$router.go();
                }
            })
        }
    }
}
</script>


<style>

</style>