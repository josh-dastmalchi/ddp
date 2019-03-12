<template>
<v-app>
  <v-navigation-drawer app><router-view name="navdrawer"></router-view></v-navigation-drawer>
  <v-toolbar app><router-view name="toolbar"></router-view></v-toolbar>
  <v-content>
    <v-container fluid>
      <router-view></router-view>
    </v-container>
  </v-content>
  <v-footer app></v-footer>
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