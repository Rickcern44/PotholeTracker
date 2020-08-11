<template>
  <div id="register" class="text-center">
    <form class="form-register" @submit.prevent="register">
      <h1 class="h3 mb-3 font-weight-normal">Create Account</h1>
      <div
        class="alert alert-danger"
        role="alert"
        v-if="registrationErrors"
      >{{ registrationErrorMsg }}</div>
      <label for="username" class="sr-only">Username</label>
      <input
        type="text"
        id="username"
        class="form-control"
        placeholder="Username"
        v-model="user.username"
        required
        autofocus
      />
      <label for="password" class="sr-only">Password</label>
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
      <router-link :to="{ name: 'login' }">Have an account?</router-link>
      <button class="btn btn-lg btn-primary btn-block" type="submit">Create Account</button>
    </form>
    <div class="updateSelection">
      <form @submit.prevent="submit">
        <input type="text" placeholder="User Id" v-model="userId" />
        <input type="text" placeholder="First Name" v-model="firstName" />
        <input type="text" placeholder="Last Name" v-model="lastName" />
        <input type="text" placeholder="Email" v-model="email" />
        <input type="text" placeholder="Phone Number" v-model="phoneNumber" />
        <button type="submit" id="button"  v-on:click="updateUserFirstName(), updateLastName(), updateEmail(), updatePhone(), updatePage()">Submit</button>
      </form>
    </div>
    <div class="userList" v-for="employee in employeeList" :key="employee.userId">
      <p>UserID: {{employee.userId}}</p>
      <p>First Name: {{employee.firstName}}</p>
      <p>Last Name: {{employee.lastName}}</p>
      <p>Email: {{employee.email}}</p>
      <p>Phone: {{employee.phoneNumber}}</p>
    </div>
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
      employeeList: [],
      registrationErrors: false,
      registrationErrorMsg: "There were problems registering this user.",
      //user info
      userId: "",
      firstName: "",
      lastName: "",
      email: "",
      phoneNumber: "",
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
                path: "/login",
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

    updateUserFirstName(id, firstName) {
      id = this.userId;
      firstName = this.firstName;
      api.updateUserFirstName(id, firstName);
      //Call the get to update the list
    },
    updateLastName(id, lastName) {
      id = this.userId;
      lastName = this.lastName;
      api.updateUserLastName(id, lastName);
    },
    updateEmail(id, email){
      id = this.userId
      email = this.email
      api.updateUserEmail(id, email)
    },
    updatePhone(id, phone){
      id = this.userId;
      phone = this.phoneNumber
      api.updateUserPhone(id, phone)
    },
    updatePage(){
      api.getAllUsers().then(resp => {
        this.employeeList = resp.data
      })
    }
  },

  computed() {},
};
</script>

<style></style>
