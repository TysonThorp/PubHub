<template>
<div id="container">
    <h1>404</h1>
    <p>Couldn't find the page at "{{this.$route.path}}"!</p>
    <router-link to="/">Back to home</router-link>
</div>
</template>

<script>

export default {
  components: {  
  },

}
</script>

<style>
#container{
  text-align: center;
  font-size: 1.2em
}
</style>