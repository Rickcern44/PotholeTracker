<template>
  <div class="home">
    <h1>The Cleveland Pothole Tracker</h1>
    <h2>Employee Home Page</h2>
    <employee/>
  </div>
</template>

<script>
import employee from "../components/EmployeeComponent"
export default {
  components: {
    employee
  },
  name: "home",
  data(){
    return{
    }
  },
  methods:{
  }
};
</script>
<style>
@import url("https://fonts.googleapis.com/css2?family=Oswald:wght@200&display=swap");
h1{
  text-align: center;
}
.home {
  font-family: "Oswald", sans-serif;
  text-align: center;
}
</style>