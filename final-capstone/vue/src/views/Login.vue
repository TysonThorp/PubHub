<template>
  <v-card id="login">
    <v-form @submit.prevent="login">
      <div
        class="alert alert-danger"
        role="alert"
        v-if="invalidCredentials"
      >Invalid username and password!</div>

      <div
        class="alert alert-success"
        role="alert"
        v-if="this.$route.query.registration"
      >Thank you for registering, please sign in.</div>

      <v-text-field
        type="text"
        id="username"
        class="form-control"
        placeholder="Username"
        label="Username"
        v-model="user.username"
        required
        autofocus
      />

      <v-text-field
        type="password"
        id="password"
        class="form-control"
        placeholder="Password"
        label="Password"
        v-model="user.password"
        required
      />
      <v-col class="text-right">
          <v-btn block type="submit" color='primary'>Log in</v-btn>
      </v-col>
      
      <div style="text-align: center">
      <router-link class="login-link" :to="{ name: 'register' }">Need an account?</router-link>
      </div>
      
    </v-form>
  </v-card>
</template>

<script>
import authService from "../services/AuthService";

export default {
  name: "login",
  components: {},
  data() {
    return {
      user: {
        username: "",
        password: ""
      },
      invalidCredentials: false
    };
  },
  methods: {
    login() {
      authService
        .login(this.user)
        .then(response => {
          if (response.status == 200) {
            this.$store.commit("SET_AUTH_TOKEN", response.data.token);
            this.$store.commit("SET_USER", response.data.user);
            this.$router.push("/");
          }
        })
        .catch(error => {
          const response = error.response;

          if (response.status === 401) {
            this.invalidCredentials = true;
          }
        });
    }
  }
};
</script>

<style scoped>
  #login{
    padding: 1em;
  }
  .login-link{
    color: #757575;
    text-decoration: none;
  }
</style>