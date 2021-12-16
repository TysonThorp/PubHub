<template>
  <div>
    <v-btn v-on:click="showForm = !showForm">Add Brewery</v-btn>
    <v-form v-if="showForm == true">
      <v-text-field
        label="Brewery Name"
        v-model="brewery.breweryName"
      ></v-text-field>
      <v-text-field
        label="Brewery Owner ID"
        v-model.number="brewery.breweryOwnerId"
      ></v-text-field>
      <v-text-field label="Email" v-model="brewery.emailAddress"></v-text-field>
      <v-text-field label="Phone" v-model="brewery.phoneNumber"></v-text-field>
      <v-text-field label="Website" v-model="brewery.website"></v-text-field>
      <v-textarea
        label="Description"
        v-model="brewery.description"
      ></v-textarea>
      <v-text-field
        label="Hours of Operation"
        v-model="brewery.hoursOfOperation"
      ></v-text-field>
      <v-text-field label="Address" v-model="brewery.address"></v-text-field>

      <v-btn type="submit" v-on:click="createBrewery">Submit</v-btn>
    </v-form>
  </div>
</template>

<script>
import BreweryService from "../services/BreweryService";

export default {
  name: "brewery-form",
  data() {
    return {
      brewery: {
        breweryName: "Joe's Great Brews",
        breweryOwnerId: 3,
        emailAddress: "example@test.com",
        phoneNumber: "555-555-5555",
        website: "pubhub.com",
        description: "The best brews this side of Cinci! Come on down for a taste of our famous 'C# Stout'!",
        hoursOfOperation: "All day, everyday",
        address: "TE Cincinnati",
        image: "ListermannExterior.JPG",
        imageTwo: "ListermannInterior.JPG",
        imageThree: "ListermannTaproom.JPG",
        isActive: true,
      },
      showForm: false,
    };
  },
  methods: {
    createBrewery() {
      BreweryService.addBrewery(this.brewery).then((response) => {
        if (response.status == 200) {
          this.$router.go();
        }
      });
    },
  },
};
</script>

<style>
</style>