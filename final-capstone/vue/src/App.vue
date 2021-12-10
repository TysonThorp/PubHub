<template>
  <v-app>
    <v-app-bar id="app-bar"
      app
      color="#000"
      dark
    >
      <router-link to="/home">
      <div class="d-flex align-center">
        <div class="logo">
          <span class="pub">Pub</span>
          <span class="hub">Hub</span>
        </div>
      </div>
      </router-link>

    </v-app-bar>

    <v-main>
      <router-view/>
    </v-main>
  </v-app>
</template>

<script>

export default {
  name: 'App',

  data: () => ({
    //
  }),
};
</script>

<style lang="css" scoped>
.logo{
  /* background: #f09; */
  padding: 10px;
  font-size: 24px;
  font-weight: bold;
}

.pub{
  color:darkorange;
}

#app-bar a {
  color: white!important;
  text-decoration: none;
}

</style>
