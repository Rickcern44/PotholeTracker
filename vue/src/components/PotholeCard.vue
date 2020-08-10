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
}
}
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
</style>