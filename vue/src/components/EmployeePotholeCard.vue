<template>
  <div class="card">
      <p>{{pothole.Id}}</p>
      <p>{{pothole.location}}</p>
      <p id="status">{{statusString(pothole.status)}}</p>
      <p>{{pothole.description}}</p>
      <p>{{pothole.dateAddedString}}</p>
      <p v-if="checkSeverity(pothole.severity)" id="severity">Severity: {{pothole.severity}}</p>
  </div>
</template>

<script>
export default {
props:{
    pothole: {}
},
methods:{
statusString(status){
    if (status === 1){
      return 'Reported'
    }else if (status === 2){
      return 'Under Repair'
    }else {
      return 'Work Completed'
    } 
},
    checkSeverity(severity) {
        if (severity === null || severity === 0) {
            return false;
        }
        else {
            return true;
        }
    }
},
computed:{
  
}
}
</script>

<style>

</style>