<template>
    <div>
        <h1>
            {{ brewery.breweryName }}
        </h1>
        <ul>
            <li>Description: {{ brewery.description }}</li>
            <li>Address: {{ brewery.address }}</li>
            <li>Phone: {{ brewery.phoneNumber }}</li>
            <li>Email: {{brewery.emailAddress }}</li>
            <li>Website: {{brewery.website }}</li>
            <li>Hours: {{ brewery.hoursOfOperation }}</li>
        </ul>
    </div>
</template>

<script>
import BreweryService from '../services/BreweryService';

export default {
    name: 'brewery-detail',
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
        const breweryId = this.$route.params.breweryId;

        BreweryService.getBreweryById(breweryId).then((response) => {
            this.brewery = response.data;
        });
    } 
}
</script>

<style>

</style>