<template>
    <table>
    <thead>
      <tr>
        <th>Brewery List</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="brewery in $store.state.brewery" v-bind:key="brewery.id">
        <td>{{ brewery.id }}</td>
        <td>{{ brewery.name }}</td>
        <td>
          <router-link
            v-bind:to="{name:'brewery', params:{id: brewery.id} }">
            {{brewery.id}}
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
            brewery: {
                breweryName: '',
            }
        }
    },
};
</script>

<style>

</style>