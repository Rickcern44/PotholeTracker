<template>
  <div class="home">
    <h1>Employee Home Page</h1>
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
h1{
  text-align: center;
}
</style>