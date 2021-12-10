<template>
  <div class="beers">
     <h1>Beers</h1>
     <products-list />
  </div>
</template>

<script>

import BeerList from "../components/BeerList.vue"

export default {
    name: 'beer-view',
    components:{
        BeerList
    }

}
</script>

<style>

</style>