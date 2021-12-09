<template>
  <div>
    <ul id="brewery-list">
        <li v-for="brewery in breweries" :key="brewery.breweryId">
            <div>
                <h2 id="breweryName">{{ brewery.breweryName }}</h2>
                <p id="breweryInfo">
                    <a :href= brewery.website target="_blank">Website</a> |
                    {{ brewery.phoneNumber }} |
                    {{ brewery.address }}
                </p>
                <p id="breweryDesc">{{ brewery.description }}</p>
            </div>
            
        </li>
    </ul>
  </div>
</template>

<script>
    import BreweryService from '../services/BreweryService';

    export default {
        name: 'Breweries',
        components: {},
        data() {
            return {
                breweries: []
            }
        },
        created(){
            BreweryService.getAllBreweries().then(response => {
                    this.breweries = response.data;
            });
        }
    }   
</script>
