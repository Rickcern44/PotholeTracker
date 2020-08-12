<template>
  <div class="card">
      <p>{{pothole.location}}</p>
      <p :class="statusColor">{{statusString(pothole.status)}}</p>
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
  font-weight: 900;
}

.under-repair{
  color: orange;
  font-weight: 900;
}

.work-completed{
  color: green;
  font-weight: 900;
}
.card:hover{
  background-color: lightgray;
}
.card{
  margin-right: 20px;
}
</style>