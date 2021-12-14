<template>
  <div>

  </div>
</template>

<script>
import BreweryService from '../services/BreweryService'

export default {
    name: 'brewery-form',
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
    created() {
        
    },
    methods: {
        createBrewery() {
            BreweryService.addBrewery(this.brewery).then((response) => {
                
            })
        }
    }
}
</script>

<style>

</style>