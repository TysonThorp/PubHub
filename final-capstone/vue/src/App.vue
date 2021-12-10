<template>
  <v-app id="inspire">
    
    <v-app-bar app>
      <v-app-bar-nav-icon @click="toggleDrawer"></v-app-bar-nav-icon>
      <div class="logo">
          Pub<span class="hub">Hub</span>
      </div>
    </v-app-bar>
     <v-navigation-drawer v-model="drawer">
       
      <v-list-item>
        <v-list-item-content>
          <v-list-item-title class="text-h6">
            Application
          </v-list-item-title>
          <v-list-item-subtitle>
            subtext
          </v-list-item-subtitle>
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
          link
          to="/login"
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
      <router-view></router-view>
      <!--  -->
    </v-main>
  </v-app>
</template>


<script>
  export default {
    data: () => ({ 
      drawer: false,
      items: [
        {title: 'Sign-in' , icon: 'mdi-view-dashboard'},
        {title: 'Beer' , icon: 'mdi-image'},
        {title: 'Brewery' , icon: 'mdi-image'},
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




</style>