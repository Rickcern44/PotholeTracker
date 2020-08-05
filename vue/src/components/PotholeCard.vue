<template>
  <div class="card">
      <p>{{pothole.location}}</p>
      <p>{{statusString(pothole.status)}}</p>
      <p>{{pothole.description}}</p>
      <p>{{pothole.dateAddedString}}</p>
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
},
computed:{
  
}
}
</script>

<style>
</style>