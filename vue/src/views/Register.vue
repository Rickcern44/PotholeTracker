<template>
  <div id="register" class="text-center">
    <h1 class="h3 mb-3 font-weight-normal">The Cleveland Pothole Tracker</h1>
    <h2 class="h2-header">Register & Update Employee Accounts</h2>
    <img id="banner" src="https://www.artba.org/wp-content/uploads/2019/04/silicaCompliance_banner.jpg" alt="Cleveland Roadwork Image">
    <form class="form-register" @submit.once="register">
      
      <div
        class="alert alert-danger"
        role="alert"
        v-if="registrationErrors"
      >{{ registrationErrorMsg }}</div>
      <h3 id="registerHead">Register New Employee</h3>
      <!-- <label for="username" class="sr-only">Username</label> -->
      <input
        type="text"
        id="username"
        class="form-control"
        placeholder="Username"
        v-model="user.username"
        required
        autofocus
      />
      <!-- <label for="password" class="sr-only">Password</label> -->
      <input
        type="password"
        id="password"
        class="form-control"
        placeholder="Password"
        v-model="user.password"
        required
      />
      <input
        type="password"
        id="confirmPassword"
        class="form-control"
        placeholder="Confirm Password"
        v-model="user.confirmPassword"
        required
      />
      <!-- <router-link :to="{ name: 'login' }">Have an account?</router-link> -->
      <button class="createButton" type="submit">Create Account</button>
    </form>
    <div class="updateSelection">
      <h3 id="updateHeader">Update Employee</h3>
      <form id="updateForm"  >
        <input id="uid" type="text" placeholder="User ID Number" v-model="selectedEmployee.userId" required />
        <input id="ufn" type="text" placeholder="First Name" name="FirstName"  v-model="selectedEmployee.firstName" required />
        <input id="uln" type="text" placeholder="Last Name" name="LastName" v-model="selectedEmployee.lastName" required />
        <input id="uem" type="text" placeholder="Email" name="Email" v-model="selectedEmployee.email" />
        <input id="upn" type="text" placeholder="Phone Number" name="PhoneNumber" v-model="selectedEmployee.phoneNumber" />
        <button type="submit" id="button" v-on:click.prevent="updateAll();">Submit</button>
      </form>
    </div>
    <div id="listContainer">
      <h2 id="listHead">Employee List</h2>
      <div class="userList" v-for="employee in employeeList" :key="employee.userId" @click="assignUserId(employee)">
      <ul>
        <p>UserID: {{employee.userId}}</p>
        <p>First Name: {{employee.firstName}}</p>
        <p>Last Name: {{employee.lastName}}</p>
        <p>Email: {{employee.email}}</p>
        <p>Phone: {{employee.phoneNumber}}</p>
      </ul>
    </div>
    </div>
  <footer id="footer">&copy; The Pothole Tracker 2020</footer>
  </div>
  
</template>

<script>
import authService from "../services/AuthService";
import api from "../services/APIService";
export default {
  name: "register",
  data() {
    return {
      user: {
        username: "",
        password: "",
        confirmPassword: "",
        role: "user",
      },
      selectedEmployee:{},
      employeeList: [],
      registrationErrors: false,
      registrationErrorMsg: "There were problems registering this user.",
      userId: "",
    };
  },
  created() {
    api.getAllUsers().then((resp) => {
      this.employeeList = resp.data;
    });
  },
  methods: {
    register() {
      if (this.user.password != this.user.confirmPassword) {
        this.registrationErrors = true;
        this.registrationErrorMsg = "Password & Confirm Password do not match.";
      } else {
        authService
          .register(this.user)
          .then((response) => {
            if (response.status == 201) {
              this.$router.push({
                path: "/register",
                query: { registration: "success" },
              });
            }
          })
          .catch((error) => {
            const response = error.response;
            this.registrationErrors = true;
            if (response.status === 400) {
              this.registrationErrorMsg = "Bad Request: Validation Errors";
            }
          });
      }
    },
    clearErrors() {
      this.registrationErrors = false;
      this.registrationErrorMsg = "There were problems registering this user.";
    },
    assignUserId(employee){
      this.selectedEmployee = employee
    },
    updatePage(){
      api.getAllUsers().then(resp => {
        this.employeeList = resp.data
      })
    },
    updateAll(){
        api.updateEmployee(this.selectedEmployee).then(resp => {
          if (resp.status === 200){
              console.log("Updated")
          }
          
        })
    }
  },
};
</script>

<style>
@import url("https://fonts.googleapis.com/css2?family=Oswald:wght@200&display=swap");
#register {
  display: grid;
  grid-template-columns: 2fr 2fr 2fr;
  row-gap: 5px;
  column-gap: 5px;
  align-items: center;
  grid-template-areas:
    "header  header   header"
    "header2  header2   header2"
    "top     top      top"
    "emps    register update"
  ;
}
#banner {
  grid-area: top;
  height: 350px;
  width: fit-content;
}
#listContainer {
  grid-area: emps;
  overflow-y: auto;
  overflow-x: hidden;
  max-height: 500px;
}
.userList {
  border: black solid 3px;
  text-align: center;
  background-color: #FEF6EB;
  padding-right: 30px;
}
.userList:hover {
  background-color: #BEB9B5;
}
#listHead {
  grid-area: register;
  text-align: center;
}
.form-register {
  display: flex;
  flex-direction: column;
  /* row-gap: 5px; */
  align-items: flex-end;  
  grid-area: register;
  max-width: 400px;
}
.updateSelection {
  display: flex;
  flex-direction: column;
  grid-area: update;
  align-items: center;
}
#updateForm {
  display: flex;
  flex-direction: column;
  text-align: center;
  row-gap: 15px;
}
#updateHeader {
  grid-area: update;
  text-decoration: underline;
}
h1 {
  grid-area: header;
  
}
.h2-header {
grid-area: header2;
text-align: center;

}
#registerHead {
  display: flex;
  align-items: center;
  grid-area: register;
  text-decoration: underline;
  text-align: center;
  width: 200px;
}
/* .sr-only {
  margin: 15px;
} */
#uid, #ufn, #uln, #uem, #upn {
  width: 200px;
}
.createButton {
  width: 208px;
  margin: 15px;
  color: white;
  background-color: #96C0CE;
  border-radius: 5px;
}
.createButton:hover,.createButton:focus{
  /* border: 2px black solid; */
  background-color: #C25B56;
  /* border: black solid 2px; not doing anything*/
}
#button {
  background-color: #96C0CE;
  border-radius: 5px;
  color: white;
}
#button:hover, #button:focus {
 
   background-color: #C25B56; 
}
#username, #password, #confirmPassword {
  width: 200px;
  margin: 15px;
}
* {
  font-family: "Oswald", sans-serif;
}
</style>
