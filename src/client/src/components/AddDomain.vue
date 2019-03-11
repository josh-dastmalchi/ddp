<template>
  <v-form>
    <v-text-field v-model="name" label="Name"></v-text-field>
    <v-btn @click="addDomain">Add Domain</v-btn>
  </v-form>
</template>

<script>
import domainService from "../services/domainService.js";

export default {
  data: function() {
    return {
      name: null
    };
  },
  methods: {
    addDomain: function() {
      domainService
        .add(this.name)
        .then(function(response) {
          console.log("added domain with id " + response.data);
        })
        .catch(function(error) {
          console.log("got an error: " + error);
        });
    }
  }
};
</script>