<template>
  <v-app>
    <h1>testing the header from app.vue right hurr</h1>
    <v-app-bar
      app
      color="#000"
      dark
    >
      <div class="d-flex align-center">
        <div class="logo">
          <span class="pub">Pub</span>
          <span class="hub">Hub</span>
        </div>
      </div>

      <v-spacer></v-spacer>

      <v-btn
        href="https://github.com/vuetifyjs/vuetify/releases/latest"
        target="_blank"
        text
      >
        <span class="mr-2">Latest Release</span>
        <v-icon>mdi-open-in-new</v-icon>
      </v-btn>
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

</style>
