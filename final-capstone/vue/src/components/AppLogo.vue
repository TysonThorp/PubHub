<template>
  <router-link to="/">
    <div class="d-flex align-center" v-if="$vuetify.theme.dark">
      <div class="logo">
        Pub<span class="hub">Hub</span>
      </div>
    </div>

    <div class="d-flex align-center" v-if="!$vuetify.theme.dark">
      <span class="logo2">
        <img src="@/assets/logo.svg"/> PubHub 
      </span>
    </div>
  </router-link>
</template>


<script>
export default {
  name: "app-logo"
};
</script>

<style>

</style>