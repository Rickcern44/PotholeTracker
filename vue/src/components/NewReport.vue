<template>
<body>
  <div id="container">
    <h1>Report A New Pothole</h1>
    <form action.prevent="submit">
      <label class="formlabel" for="streetNumber">Street Number:</label>
      <input
        required
        type="text"
        id="streetNumber"
        name="streetNumber"
        v-model="address.streetNumber"
        placeholder="123"
      />
      <br />
      <br />
      <label class="formlabel" for="streetName">Street Name:</label>
      <input
        required
        type="text"
        id="streetName"
        name="streetName"
        v-model="address.streetName"
        placeholder="Superior Ave"
      />
      <br />
      <br />
      <!-- <label for="zip">Zip Code:</label> -->
      <!-- <input required type="text" id="zip" name="zip" v-model="address.zip" placeholder="44112"><br><br>
      <label for="description">Pothole Description:</label>-->
      <label class="formlabel" for="zip">Choose Zip Code:</label>

      <!-- This is the dropdown menu -->
      <select required id="zips" name="Zips" v-model="address.zip">
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
      </select>
      <br />
      <br />
      <input
        required
        type="text"
        id="description"
        name="description"
        v-model="description"
        placeholder="Tell us about the pothole"
      />
      <br />
      <br />
      <input type="button" id="button" value="Submit" v-on:click="CreatePothole()" />
    </form>

    <!-- trying to make a custom vue alert box -->
    <div class="alert" v-if="alertBox">
        <h1>Alert</h1>
        <p>Please make sure all of the fields are filled in to continue!</p>
        <button @click="closeAlertBox">Click to close</button>
    </div>

  </div>
</body>
</template>

<script>
import APIService from "../services/APIService";

export default {
  data() {
    return {
      address: {
        streetNumber: "",
        streetName: "",
        city: "Cleveland",
        state: "OH",
        zip: "",
      },
      description: "",
      alertBox: false,
    };
  },
  props: {
    location: String,
  },
  methods: {
    CreatePothole() {
      let pothole = {
        location: this.parseAddress,

        description: this.description.trim(),
      };
      APIService.reportPothole(pothole)
        .then((resp) => {
          if (resp.status === 200) {
            APIService.getPublicPotholes();
            this.$router.push("/");
          }
        })
        .catch((error) => {
          const response = error.response;
          if (response.status === 403) {
              this.alertBox = true;
          }
        });
    },
    closeAlertBox(){
        this.alertBox = false;
    }
  },
  computed: {
    parseAddress() {
      return `${this.address.streetNumber.trim()} ${this.address.streetName.trim()} ${this.address.city.trim()}, ${this.address.state.trim()} ${this.address.zip.trim()}`;
    },
  },
};
</script>

<style scoped>
@import url("https://fonts.googleapis.com/css2?family=Oswald:wght@200&display=swap");

h1 {
  text-align: center;
  color: white;
  font-weight: bolder;
  text-shadow: black 2px 2px;
}
form {
  text-align: center;
  background: #beb9b5;
  width: 30%;
  padding: 40px;
  margin: 10px auto;
  border-radius: 30px;
  height: 312px; /*this stops the bottom of box from moving during button hover*/
}
#button {
  background-color: #96c0ce;
  text-align: center;
  justify-content: center;
  padding: 5px;
  border: black solid 1px;
  box-shadow: black 2px 2px;
  border-radius: 5px;
  font-family: "Oswald", sans-serif;
  font-weight: bolder;
}

#button:hover,
#button:focus {
  background-color: #c25b56;
  border: black solid 2px;
}
#container {
  display: flex;
  flex-direction: column;
}
body {
  background-image: url(https://nextconf.eu/wp-content/uploads/2018/12/marc-olivier-jodoin-502572-unsplash-1280x0-c-default.jpg);
  background-size: cover;
  background-attachment: fixed;
  height: 100vh;
  font-family: "Oswald", sans-serif;
}
.formlabel {
  padding-right: 5px;
  font-weight: bold;
}
.alert{
    display: flex;
    text-align: center;
    flex-direction: column;
    width: 300px;
    z-index: 100;
    justify-content: center;
    align-self: center;
    padding: 0px 10px 20px 10px ;
    border-radius: 10px;
    background-color: #c25b56;
}
</style>