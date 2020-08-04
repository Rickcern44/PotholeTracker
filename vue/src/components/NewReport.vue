<template>
    <div>
       <h1>Report A New Pothole</h1> 
       <form action.prevent="submit">
           <label for="streetNumber">Street Number:</label>
           <input required type="text" id="streetNumber" name="streetNumber" v-model="address.streetNumber" placeholder="123"><br><br>
           <label for="streetName">Street Name:</label>
           <input required type="text" id="streetName" name="streetName" v-model="address.streetName" placeholder="Superior Ave"><br><br>
            <label for="zip">Zip Code:</label>
           <input required type="text" id="zip" name="zip" v-model="address.zip" placeholder="44112"><br><br>
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
            address:{
                streetNumber: "",
                streetName: "",
                city: "Cleveland",
                state: "OH",
                zip: ""
            },
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
        },
    }

}
</script>

<style>

</style>