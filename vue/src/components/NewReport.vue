<template>
    <body>
        <div id="container">
            <h1>Report A New Pothole</h1> 
            <form action.prevent="submit">
            <label for="streetNumber">Street Number:</label>
            <input required type="text" id="streetNumber" name="streetNumber" v-model="address.streetNumber" placeholder="123"><br><br>
            <label for="streetName">Street Name:</label>
            <input required type="text" id="streetName" name="streetName" v-model="address.streetName" placeholder="Superior Ave"><br><br>
            <!-- <label for="zip">Zip Code:</label> -->
           <!-- <input required type="text" id="zip" name="zip" v-model="address.zip" placeholder="44112"><br><br>
           <label for="description">Pothole Description:</label> -->
            <label for="zip">Choose Zip Code:</label>

           <!-- This is the dropdown menu -->
            <select id="zips" name="Zips" v-model="address.zip">
                <option value="44102">44102</option>
                <option value="44103">44103</option>
                <option value="44104">44104</option>
                <option value="44105">44105</option> 
                <option value="44106">44106</option>
                <option value="44108">44108</option>
                <option value="44109">44109</option>
                 <option value="44110">44110</option>
                <option value="44111">44111</option>
                <option value="44112">44112</option>
                <option value="44113">44113</option>
                <option value="44114">44114</option>
                <option value="44115">44115</option>
                <option value="44117">44117</option>
                <option value="44119">44119</option>
                <option value="44120">44120</option>
                <option value="44121">44121</option>
                <option value="44126">44126</option>
                <option value="44127">44127</option>
                <option value="44128">44128</option>
                <option value="44129">44129</option>
                <option value="44134">44134</option>
                <option value="44135">44135</option>
                <option value="44142">44142</option>
                <option value="44144">44144</option>

                </select><br><br>
                <input required type="text" id="description" name="description"  v-model="description" placeholder="Tell us about the pothole"><br><br>
                <input type="button" id="button" value="Submit" v-on:click="CreatePothole()">
                </form>
            </div>
    </body>
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
            APIService.getPublicPotholes();
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

<style scoped>
    h1{
        text-align: center;
        color:red;
    }
    form{
        text-align: center;
        background: white;
        width: 30%;
        padding: 40px;
        margin: 10px auto;


    }
    #button{
        background-color:lawngreen;
        text-align: center;
        justify-content: center;
        padding: 5px;
        border: black solid 1px;
    } 
    #container{
        display:flex;
        flex-direction: column;
    }
    body{
        background-image: url(https://rockford-main.s3.us-east-2.amazonaws.com/s3fs-public/pothole_interstate_highway_winter%20%282%29.jpg);
        background-size: cover;
        background-attachment: fixed;
    }

</style>