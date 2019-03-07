<template>
  <v-app>
    <v-container>
      <router-view/>
    </v-container>
  </v-app>
</template>

<script>
  export default {
    data: () => ({
      drawer: null
    }),

    props: {
      source: String
    }
  }
</script>