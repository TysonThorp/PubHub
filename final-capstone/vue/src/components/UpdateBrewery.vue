<template>
    <div>
        <v-btn v-on:click="showForm = !showForm">Update Brewery</v-btn>
        <v-form v-if="showForm == true">
            <v-text-field label="Brewery Name" v-model="brewery.breweryName"></v-text-field>
            <v-text-field label="Brewery Owner ID" v-model.number="brewery.breweryOwnerId"></v-text-field>
            <v-text-field label="Email" v-model="brewery.emailAddress"></v-text-field>
            <v-text-field label="Phone" v-model="brewery.phoneNumber"></v-text-field>
            <v-text-field label="Website" v-model="brewery.website"></v-text-field>
            <v-textarea label="Description" v-model="brewery.description"></v-textarea>
            <v-text-field label="Hours of Operation" v-model="brewery.hoursOfOperation"></v-text-field>
            <v-text-field label="Address" v-model="brewery.address"></v-text-field>
            <v-text-field label="Image 1" v-model="brewery.image"></v-text-field>
            <v-text-field label="Image 2" v-model="brewery.imageTwo"></v-text-field>
            <v-text-field label="Image 3" v-model="brewery.imageThree"></v-text-field>
            <v-text-field label="Active Brewery?" v-model="brewery.isActive"></v-text-field>  

            <v-btn type="submit" v-on:click="updateBreweryDetails">Submit</v-btn> 
        </v-form>
    </div>
</template>

<script>
import BreweryService from "../services/BreweryService";

export default {
    name: "update-brewery",
    data() {
        return {
            brewery: {
                breweryName: "",
                breweryOwnerId: 0,
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