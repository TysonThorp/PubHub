<template>
  <div id="beers">
     <h1>Beers</h1>
     <beer-list :showAll="true"/>
  </div>
</template>

<script>

import BeerList from "../components/BeerList.vue"

export default {
    components:{
        BeerList
    }

}
</script>

<style>
</style>