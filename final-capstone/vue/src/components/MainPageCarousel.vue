<template>
  <v-carousel
  cycle
    height="400"
    hide-delimiter-background
    show-arrows-on-hover>
    <v-carousel-item
      v-for="(item,i) in items"
      :key="i"
      :src="item.src"
      reverse-transition="fade-transition"
      transition="fade-transition"
    ></v-carousel-item>
  </v-carousel>
</template>

<script>
  export default {
      name: "main-carousel",
    data () {
      return {
        items: [
        {
         src : require('/public/img/BraxtonInterior.jpg')
        },
        {
          src: require ('/public/img/BraxtonRooftop.jpg')
        },
        {
          src: require('/public/img/BraxtonTaps.jpg')
        },
      
    
        {
          src: require('/public/img/TaftsExterior.jpg')
        },
       
         {
          src: require('/public/img/TaftsLineup.jpg')
        },
       
          
        
          {
          src: require ('/public/img/RhinegeistSign.jpg')
        },
        
           {
          src: require('/public/img/RhinegeistBeers.jpg')
        },        
      ]
      }
    },
  }
</script>

<style>

</style>
