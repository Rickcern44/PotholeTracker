<template>
  <div class="card">
      <p>{{`The pothole ID is :${pothole.id}`}}</p>
      <p>{{pothole.location}}</p>
      <p>{{statusString(pothole.status)}}</p>
      <p>{{pothole.dateAdded}}</p>
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
  }
},
computed:{
  
}
}
</script>

<style>

</style>