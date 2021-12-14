<template>
<div>
  <v-card id="register">
    <v-form @submit.prevent="register">
      <div class="alert alert-danger" role="alert" v-if="registrationErrors">
        {{ registrationErrorMsg }}
      </div>

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

      <v-text-field
        type="password"
        id="confirmPassword"
        class="form-control"
        label="Confirm Password"
        v-model="user.confirmPassword"
        required
      />

      <v-col class="text-right">
          <v-btn block type="submit" color='primary'>Register</v-btn>
      </v-col>

      <div style="text-align: center">
      <router-link class="login-link" :to="{ name: 'login' }">Already have an account?</router-link>
      </div>
      
    </v-form>
  </v-card>
  </div>
</template>

<script>
import authService from '../services/AuthService';

export default {
  name: 'register',
  data() {
    return {
      user: {
        username: '',
        password: '',
        confirmPassword: '',
        role: 'user',
      },
      registrationErrors: false,
      registrationErrorMsg: 'There were problems registering this user.',
    };
  },
  methods: {
    register() {
      if (this.user.password != this.user.confirmPassword) {
        this.registrationErrors = true;
        this.registrationErrorMsg = 'Password & Confirm Password do not match.';
      } else {
        authService
          .register(this.user)
          .then((response) => {
            if (response.status == 201) {
              this.$router.push({
                path: '/login',
                query: { registration: 'success' },
              });
            }
          })
          .catch((error) => {
            const response = error.response;
            this.registrationErrors = true;
            if (response.status === 400) {
              this.registrationErrorMsg = 'Bad Request: Validation Errors';
            }
          });
      }
    },
    clearErrors() {
      this.registrationErrors = false;
      this.registrationErrorMsg = 'There were problems registering this user.';
    },
  },
};
</script>

<style scoped>
  #register{
    padding: 1em;
  }
  .login-link{
    color: #757575;
    text-decoration: none;
  }
</style>