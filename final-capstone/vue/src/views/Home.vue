<template>
      <div>
        <div v-if="this.$store.state.user.role != null">
          <h1>Welcome, {{this.$store.state.user.username}}!</h1>
      </div>
      <div v-else>
        <h1>Home</h1>
      </div>
        <v-container>
          <v-layout row wrap>
            <v-flex xs12 md6>
              <v-btn outline block class="primary">HELLO</v-btn>
            </v-flex>
            <v-flex xs4 md>
              <v-btn outline block class="primary">HI</v-btn>
            </v-flex>  
            <v-flex xs4 md>
              <v-btn outline block class="primary">HI</v-btn>
            </v-flex>
            <v-flex xs4 md>
              <v-btn outline block class="primary">HI</v-btn>
            </v-flex>
            <v-flex xs4 md>
              <v-btn outline block class="primary">HI</v-btn>
            </v-flex>
          
          <v-layout row wrap justify-center>
            <v-flex xs12>
              <v-btn outline block class="secondary">testing</v-btn>
            </v-flex>  
          </v-layout>
        <brewery-list :showAll="true"/>
        </v-layout>
        </v-container>
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
