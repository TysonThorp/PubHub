<template>
      <div>
        <h2>This text appears only on the homepage.</h2>
        <brewery-list/>
      </div>
</template>

<script>
  export default {
    data: () => ({ drawer: null }),
  }
</script>
  

<script>
  import BreweryList from './BreweryList.vue'

  export default {
    name: 'home',

    components: {
        BreweryList,
    },
  }
</script>

<style>
 
</style>
