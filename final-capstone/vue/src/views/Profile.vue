<template>
<div>
    <h1>Hi, {{this.$store.state.user.username}}</h1>
    <p>Role: {{this.$store.state.user.role}}</p>
    <p>User id: {{this.$store.state.user.userId}}</p>
    <v-btn to="/logout">Log out</v-btn>

    <div v-if="this.$store.state.user.role === 'user'">
        <p>You are eligible to become a Brewer. Click the button below to change your role. You will need to log in again.</p>
        <v-btn v-on:click="BecomeBrewer">Brew me up!</v-btn>
    </div>
</div>
</template>

<script>
import UserService from '../services/UserService.js';

export default {
  components: {  
  },
  data() {
      return {
          user: {
            userId: this.$store.state.user.userId,
            username: this.$store.state.user.username,
            role: 'brewer',
        },
        };
    },
methods: {
BecomeBrewer(){
    UserService.updateUser(this.user).then((response) => {
    if (response.status == 200) {
    this.$store.commit("LOGOUT");
    this.$router.push("/login");
    }
    // doesn't currently commit a mutation so
});
      }
  }

}
</script>

<style>
#container{
  text-align: center;
  font-size: 1.2em
}
</style>