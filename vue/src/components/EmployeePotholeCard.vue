<template>
  <div class="card">
    <p>{{pothole.Id}}</p>
    <p>{{pothole.location}}</p>
    <p id="status" :class="statusColor">{{statusString(pothole.status)}}</p>
    <label for="Status">Update Status: </label>
    <select name="Status" id="dropdownStatus" v-model="pothole.status" v-on:change="updatePotholeStatus(pothole.id, pothole.status)">
      <option value=1>Reported</option>
      <option value=2>Under Repair</option>
      <option value=3>Work Completed</option>
    </select>
    <p>User Description: {{pothole.description}}</p>
    <p>Date Reported: {{pothole.dateAddedString}} </p>
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
    }
  },
  methods: {
    statusString(status) {
      if (status === 1 || status === "1") {
        return "Reported";
      } else if (status === 2 || status === "2") {
        return "Under Repair";
      } else if (status === 3 || status === '3') {
        return "Work Completed";
      }
    },
    statusColorSwitch(status){
      if (status === 1 || status === '1'){
        return true;
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
  computed: {
        statusColor(){
          let className = "";
      if (this.pothole.status === 1 || this.pothole.status === '1'){
            className = 'reported';
      }else if (this.pothole.status === 2 || this.pothole.status === '2'){
        className = 'under-repair'
      }else {
        className = 'work-completed'
      }
      return className
    },
  },
};
</script>

<style>
.reported{
  color: red;
}

.under-repair{
  color: orange;
}

.work-completed{
  color: green;
}

#dropdownStatus:hover {
  background-color: lightskyblue ;
}

#dropdownSeverity:hover {
  background-color: lightskyblue;
}

/* .card {
  border: 50px solid transparent;
  padding: 5px;
  border-image: url(https://3dwarehouse.sketchup.com/warehouse/v1.0/publiccontent/797fb274-3d77-4bf5-8f74-2cb547bc5845) 50010;
  border-image-repeat: repeat;
} */
</style>