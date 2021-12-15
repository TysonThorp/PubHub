<template>
  <router-link to="/">
    <div class="d-flex align-center">
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
.router-link-active{
  text-decoration: none;
}
</style>