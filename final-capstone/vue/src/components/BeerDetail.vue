<template>
    <table>
 
    <tbody>
      
        <td>{{beer.BeerName}}</td>
        <td>{{beer.BeerType}}</td>
        <td>{{beer.description}}</td>
        <td>{{beer.image}}</td>
        <td>{{beer.abv}}</td>
      
         
     
    </tbody>
  </table>
</template>

<script>
import BeerService from '../services/BeerService.js'

export default {
    name: 'beer-detail',
    props: {
        beerId: Number
    },
    data() {
        return {
            beer: {
                beerName: '',
                beerType: '',
                description: '',
                image: '',
                abv: ''
            }
        }
    },
    created() {
        
        BeerService.getBeerById(this.beerId).then((response) => {
            this.beer = response.data;
        });
    }
}
</script>

<style>

</style>