<template>
  <div class="home">
    <h1>Home</h1>
    <employee/>
  </div>
</template>

<script>
import employee from "../components/Employee"
export default {
  components: {
    employee
  },
  name: "home"
};
</script>
