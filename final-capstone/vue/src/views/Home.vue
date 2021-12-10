<template>
<<<<<<< HEAD
  <v-app id="inspire">
    <v-navigation-drawer
      v-model="drawer"
      app
    >
      <!--  -->
    </v-navigation-drawer>

    <v-app-bar app>
      <v-app-bar-nav-icon @click="drawer = !drawer"></v-app-bar-nav-icon>

      <v-toolbar-title>Application</v-toolbar-title>
    </v-app-bar>

    <v-main>
      <!--  -->
    </v-main>
  </v-app>
</template>

<script>
  export default {
    data: () => ({ drawer: null }),
  }
</script>
=======
  <brewery-list/>
</template>

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
>>>>>>> 8171bc0023309b770e210e17fd27d616385cd9c0
