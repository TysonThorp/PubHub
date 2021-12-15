<template>
  <v-app>
    <v-app-bar app id="app-bar">
      <v-app-bar-nav-icon @click="toggleDrawer"></v-app-bar-nav-icon>
      
      <app-logo></app-logo>
      <v-spacer></v-spacer>
    
      
      <div v-if="loggedIn">
          <router-link to="/profile">
              <v-icon color="primary">mdi-account-circle</v-icon>
              {{this.$store.state.user.username}}
            </router-link>
      </div>

      <div v-else>
         <v-btn to="/login" color=primary>Log in</v-btn>
      </div>
      
    </v-app-bar>
    <v-navigation-drawer v-model="drawer" app>
       
      <v-list-item>
        <v-list-item-content>
          <v-list-item-title class="text-h6">
            <app-logo/> 
          </v-list-item-title>
        </v-list-item-content>
      </v-list-item>
     

      <v-divider></v-divider>

      <v-list
        dense
        nav
      >
        <v-list-item
          v-for="item in items"
          :key="item.title"
          :to="item.link"
        >
          <v-list-item-icon>
            <v-icon>{{ item.icon }}</v-icon>
          </v-list-item-icon>

          <v-list-item-content>
            <v-list-item-title>{{ item.title }}</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        
        <v-list-item>
        <v-switch reverse v-model="$vuetify.theme.dark" :label="$vuetify.theme.dark ? '🌙' : '☀️'"
      ></v-switch>
      </v-list-item>

      </v-list>
     </v-navigation-drawer>

    <v-main id="mainsection">
      <v-container style="max-width: 700px">
        <router-view />
      </v-container>
       <div class="hero-image"></div>
    </v-main>
  </v-app>

</template>


<script>

import AppLogo from './components/AppLogo.vue';
  export default {
    components: { 
      AppLogo,
      
  },
    data: () => ({ 
      drawer: false,
      items: [
        {title: 'Breweries' , icon: 'mdi-home', link: '/breweries'},
        {title: 'Beers' , icon: 'mdi-glass-mug-variant', link: '/beers'},
        {title: 'Reviews' , icon: 'mdi-star', link: '/reviews'},
      ],
    }),
    methods:{
      toggleDrawer(){
        this.drawer = !this.drawer;
        console.log(this.drawer);
      }},
    computed: {
      loggedIn(){
        return this.$store.state.user.role != null
      }
    }  
  }
</script>

<style lang="css">

.logo{
  font-weight: bold;
  font-size: 20px;
  color: #fff;
  background-color: #000;
  border-radius: 5px;
  padding: 10px;
}

.logo2{
  color: #ff4424;
  border-radius: 5px;
  padding: 10px;
  font-weight: bold;
  font-size: 20px;
  display: flex;
  align-items: center;

}

.hub{
  border-radius:1.75px;
  background-color: orange;
  color: #000;
}

.v-navigation-drawer{
  position: absolute;
}

#app-bar a {
  text-decoration: none;
}

#app-bar .v-input__slot {
  margin-bottom: 0;
}

#app-bar .v-messages{
  display: none;
}
#mainsection {
 
  background-attachment:fixed;
  background-position: center; /* Center the image */
  background-repeat: no-repeat; /* Do not repeat the image */
  background-size: cover; /* Resize the background image to cover the entire container */
}

</style>