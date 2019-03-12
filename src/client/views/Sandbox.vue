<template>
  <div>
    <h1>Sandbox Page</h1>
    <div>
      <p>Make a domain</p>
      <add-domain />
    </div>
    
  </div>
</template>

<script>
import AddDomain from '../components/AddDomain.vue'

export default {
  components: {
    AddDomain
  }
}
</script>