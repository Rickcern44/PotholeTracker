<template>
    <div>
       <h1>Report A New Pothole</h1> 
       <form action.prevent="submit">
           <label for="streetNumber">Street Number:</label>
           <input required type="text" id="streetNumber" name="streetNumber" v-model="address.streetNumber" placeholder="123"><br><br>
           <label for="streetName">Street Name:</label>
           <input required type="text" id="streetName" name="streetName" v-model="address.streetName" placeholder="Superior Ave"><br><br>
            <label for="zip">Zip Code:</label>
           <!-- <input required type="text" id="zip" name="zip" v-model="address.zip" placeholder="44112"><br><br>
           <label for="description">Pothole Description:</label> -->
           <label for="cars">Choose a car:</label>

           <!-- This is the dropdown menu -->
            <select id="cars" name="cars">
                <option value="volvo">Volvo</option>
                <option value="saab">Saab</option>
                <option value="fiat">Fiat</option>
                <option value="audi">Audi</option>
            </select><br><br>
           <input required type="text" id="description" name="description"  v-model="description" placeholder="Tell us about the pothole"><br><br>
           <input type="button" id="button" value="Submit" v-on:click="CreatePothole()">
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
        description: ""
        }
    },
    props:{
        location: String
    },
    methods:{
        CreatePothole(){
                let pothole = {

              location: this.parseAddress,  
                
                description: this.description
            }
            APIService.reportPothole(pothole)
            this.$router.push('/')
        },
    },
    computed:{
        parseAddress(){
            return `${this.address.streetNumber} ${this.address.streetName} ${this.address.city}, ${this.address.state} ${this.address.zip}`

        }

    }
}
</script>

<style>

</style>