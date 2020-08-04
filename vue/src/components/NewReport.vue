<template>
    <div>
       <h1>Report A New Pothole</h1> 
       <form action.prevent="submit">
           <label for="location">Nearest Address:</label>
           <input required type="text" id="location" name="location" v-model="pothole.location" placeholder="Exp: 123 Main St Cleveland OH 44112"><br><br>
           <label for="description">Pothole Description:</label>
           <input required type="text" id="description" name="description"  v-model="pothole.description" placeholder="Tell us about the pothole"><br><br>
           <input type="button" id="button" value="Submit" v-on:click="CreatePothole(pothole)">

       </form>
    </div>
</template>

<script>
import APIService from '../services/APIService'
export default {
    data(){
        return{
            pothole:{
                location: "",
                description: ""
            }
        }
    },
    methods:{
        CreatePothole(newPothole){
            APIService.reportPothole(newPothole)
            this.$router.push('/')
        }
    }

}
</script>

<style>

</style>