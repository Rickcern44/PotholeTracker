<template>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <div v-for="pothole in potholes" :key="pothole.id">
        <p>Pothole ID: {{pothole.id}}</p>
        <p>Pothole Location: {{pothole.location}}</p>
        <p>Status: {{pothole.status}}</p>
        <!-- Update status dropdown -->
        <p> Description: {{pothole.description}}</p>
        <p>Date Added: {{pothole.dateAdded}}</p>
        <p>Severity: {{pothole.severity}}</p>
        <!-- Update severity dropdown -->
        <p>Employees Assigned: {{pothole.userId}}</p>

    </div>
</body>
</html>
</template>

<script>
import api from "../services/APIService";
export default {
  data() {
    return {
      potholes: [],
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
</style>