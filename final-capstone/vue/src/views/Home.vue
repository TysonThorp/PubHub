<template>
      <div>
        <h1>HOME</h1>
        <brewery-list/>
      </div>
</template>

<script>
  export default {
    data: () => ({ drawer: null }),
  }
</script>
  

<script>
  import BreweryList from '../components/BreweryList.vue'

  export default {
    name: 'home',

    components: {
        BreweryList,
    },
  }
</script>

<style>
 
</style>
