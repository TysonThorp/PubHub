<template>
  
  <v-form v-on:submit.prevent>
      <h3>
          Add Brewery:
      </h3>
      <v-text-field label="Brewery Name" v-model="brewery.breweryName"></v-text-field>
      <v-text-field label="Brewery Owner ID" v-model="brewery.breweryOwnerId"></v-text-field>
      <v-text-field label="Email" v-model="brewery.emailAddress"></v-text-field>
      <v-text-field label="Phone" v-model="brewery.phoneNumber"></v-text-field>
      <v-text-field label="Website" v-model="brewery.website"></v-text-field>
      <v-textarea label="Description" v-model="brewery.description"></v-textarea>
      <v-text-field label="Hours of Operation" v-model="brewery.hoursOfOperation"></v-text-field>
      <v-text-field label="Address" v-model="brewery.address"></v-text-field>

      <v-btn type="submit" v-on:click="createBrewery">Submit</v-btn>
  </v-form>
</template>

<script>
import BreweryService from '../services/BreweryService'

export default {
    name: 'brewery-form',
    data() {
        return {
            brewery: {
                breweryName: 'test',
                breweryOwnerId: this.breweryOwnerId,
                emailAddress: 'test',
                phoneNumber: 'test',
                website: 'test',
                description: 'test',
                hoursOfOperation: 'test',
                address: 'test',
                image: 'ListermannExterior.JPG',
                imageTwo: 'ListermannInterior.JPG', 
                imageThree: 'ListermannTaproom.JPG',
                isActive: true
            }
        }
    },
    methods: {
        createBrewery() {
            // const newBrewery = {
            //     breweryName: this.brewery.breweryName,
            //     breweryOwnerId: this.brewery.breweryOwnerId,
            //     emailAddress: this.brewery.emailAddress,
            //     phoneNumber: this.brewery.phoneNumber,
            //     website: this.brewery.website,
            //     description: this.brewery.description,
            //     hoursOfOperation: this.brewery.hoursOfOperation,
            //     address: this.brewery.address,
            //     isActive: this.brewery.isActive
            // }
            BreweryService.addBrewery(this.brewery).then((response) => {
                if (response.status == 200) {
                    this.brewery = this.response.data;
                }
                               
            })
        }
    },
}
</script>

<style>
    
</style>