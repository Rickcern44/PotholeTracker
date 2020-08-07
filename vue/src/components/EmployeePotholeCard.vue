<template>
  <div class="card">
    <p>{{pothole.Id}}</p>
    <p>{{pothole.location}}</p>
    <p id="status">{{statusString(pothole.status)}}</p>
    <label for="Status">Update Status: </label>
    <select name="Status" id="dropdownStatus" v-model="pothole.status" v-on:change="updatePotholeStatus(pothole.id, pothole.status)">
      <option value=1>Reported</option>
      <option value=2>Under Repair</option>
      <option value=3>Work Completed</option>
    </select>
    <p>{{pothole.description}}</p>
    <p>{{pothole.dateAddedString}}</p>
    <p v-if="checkSeverity(pothole.severity)" id="severity">Severity: {{pothole.severity}}</p>
    <label for="Severity">Update Severity: </label>
    <select name="Severity" id="dropdownSeverity" v-model="pothole.severity" v-on:change="updateSeverity(pothole.id, pothole.severity)">
      <option value=1>1</option>
      <option value=2>2</option>
      <option value=3>3</option>
      <option value=4>4</option>
      <option value=5>5</option>
    </select>
  </div>
</template>

<script>
import api from '../services/APIService'
export default {
  props: {
    pothole: {},
  },
  data() {
    return {
      statusOptions: [
        { text: 'Reported', value: 1 },
        { text: 'Under Repair', value: 2 },
        { text: 'Work Completed', value: 3 }
      ]
    }
  },
  methods: {
    statusString(status) {
      if (status === 1 || status === "1") {
        return "Reported";
      } else if (status === 2 || status === "2") {
        return "Under Repair";
      } else if (status === 3 || status === "3") {
        return "Work Completed";
      }
    },
    checkSeverity(severity) {
      if (severity === null || severity === 0) {
        return false;
      } else {
        return true;
      }
    },
    updatePotholeStatus(id, status) {
      api.updatePotholeStatus(id, status);
      api.getPublicPotholes();
    },
    updateSeverity(id, severity){
      api.updatePotholeSeverity(id, severity)
      api.getPublicPotholes();
    }
  },
  computed: {},
};
</script>

<style>
</style>