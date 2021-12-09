<template>
  <div>
    <v-container>
      <v-row>
        <v-col>
          <h1>One Column</h1>
        </v-col>
      </v-row>
      <v-row>
        <v-col>
          <h2>This is an awesome feature!</h2>
          Lorem, ipsum dolor sit amet consectetur adipisicing elit. Inventore molestiae, quidem quas asperiores illum amet. Ipsum laborum voluptates mollitia quod asperiores. Neque cum libero corporis nobis saepe quisquam tempore veritatis.
        </v-col>
        <v-col>
          column two
        </v-col>
        <v-col>
          column three
        </v-col>
      </v-row>
    </v-container>
    <HelloWorld/>
  <h1>Hello there you there?</h1>
  </div>
</template>

<script>
  import HelloWorld from '../components/HelloWorld'

  export default {
    name: 'home',

    components: {
      HelloWorld,
    },
  }
</script>
