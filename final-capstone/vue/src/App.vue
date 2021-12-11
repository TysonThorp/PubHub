<template>
  <v-app>
    <v-app-bar app id="app-bar">
      <v-app-bar-nav-icon @click="toggleDrawer"></v-app-bar-nav-icon>
      <router-link to="/">
        <div class="d-flex align-center">
          <div class="logo">
            Pub<span class="hub">Hub</span>
          </div>
        </div>
      </router-link>
    </v-app-bar>
     <v-navigation-drawer v-model="drawer" app>
       
      <v-list-item>
        <v-list-item-content>
          <v-list-item-title class="text-h6">
            PubHub
          </v-list-item-title>
          <!--<v-list-item-subtitle>
            More text
          </v-list-item-subtitle>-->
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
      </v-list>
     </v-navigation-drawer>

    <v-main>
      <v-container>
        <router-view />
      </v-container>
    </v-main>
  </v-app>
</template>


<script>
  export default {
    data: () => ({ 
      drawer: false,
      items: [
        {title: 'Login' , icon: 'mdi-arrow-right-thick', link: '/login'},
        {title: 'Breweries' , icon: 'mdi-home', link: '/breweries'},
        {title: 'Beers' , icon: 'mdi-glass-mug-variant', link: '/beers'},
        {title: 'Reviews' , icon: 'mdi-star', link: '/reviews'},
      ],
    }),
    methods:{
      toggleDrawer(){
        this.drawer = !this.drawer;
        console.log(this.drawer);
      },
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

.hub{
  border-radius:1.75px;
  background-color: orange;
  color: #000;
}

.v-navigation-drawer{
  position: absolute;
}

#app-bar a {
  color: white!important;
  text-decoration: none;
}

</style>