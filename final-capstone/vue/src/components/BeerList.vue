<template>
    <table>
    <thead>
      <tr>
        <th>Beer List</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="beer in $store.state.beers" v-bind:key="beer.id">
        <td>{{ beer.id }}</td>
        <td>{{ beer.name }}</td>
        <td>
          <router-link
            v-bind:to="{name:'beers', params:{id: beer.id} }">
            {{beer.id}}
          </router-link>
        </td>
      </tr>
    </tbody>
  </table>
</template>

<script>
export default {
    name: "beer-list",
    data() {
        return {
            beer: {
                beerName: '',
            }
        }
    },
};
</script>

<style>

</style>