<template>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body id="main-grid">
 
    <div class="admin-pthl-list" v-for="pothole in potholes" :key="pothole.id">
      <p>Pothole ID: {{pothole.id}}</p>
      <p>Pothole Location: {{pothole.location}}</p>
      <p>Status: {{pothole.status}}</p>
      <!-- Update status dropdown -->
      <p> Description: {{pothole.description}}</p>
      <p>Date Added: {{pothole.dateAdded}}</p>
      <p>Severity: {{pothole.severity}}</p>
      <!-- Update severity dropdown -->
      <!-- <p>Employees Assigned: {{pothole.userId}}</p> -->
    </div>
    <div>
      <router-link :to="{ name: 'register' }">Register a new employee</router-link>
    </div>
    
    <div id="ohio">
      <img src="https://i.redd.it/se12qhg8ku011.png" alt="picture of Ohio shaped pothole"/>
    </div>
    <footer id="footer">
      &copy; The Pothole Tracker 2020
    </footer>
</body>
</html>
</template>

<script>
import api from "../services/APIService";
export default {
  data() {
    return {
      potholes: [],
      employeeList: [],
    };
  },
  methods() {},
  created() {
    api.getPublicPotholes().then((resp) => {
      this.potholes = resp.data;
    });
  },
  mounted() {},
};
</script>

<style>
#main-grid{
  display: grid;
  grid-template-columns: 1fr 1fr;
  grid-template-areas: "list ohio";  
  
}

#ohio{
  grid-area: ohio;
  justify-self: right;
  /* align-self: ; */

 
}
.admin-pthl-list{
  grid-area: list;
}
</style>