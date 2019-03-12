<template>
  <v-navigation-drawer>
    <v-list>
      <v-list-tile v-for="item in items" :key="item.title">
        <v-list-tile-action>
          <v-icon>{{ item.icon }}</v-icon>
        </v-list-tile-action>

        <v-list-tile-content>
          <v-list-tile-title>{{ item.title }}</v-list-tile-title>
        </v-list-tile-content>
      </v-list-tile>
    </v-list>
  </v-navigation-drawer>
</template>

<script>
module.exports = {
  data: function() {
    return {
      items: [
        { title: "Domains" },
        { title: "Concepts" },
        { title: "Concept Attributes" }
      ]
    };
  }
};
</script>