<template>
<div id="container">
    <h1>Welcome, {{this.$store.state.user.username}}</h1>
    <p>Role: {{this.$store.state.user.role}}</p>
    <p>User id: {{this.$store.state.user.userId}}</p>
    <v-btn to="/logout">Log out</v-btn>
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