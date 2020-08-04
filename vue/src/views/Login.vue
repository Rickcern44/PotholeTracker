<template>
  <div class="grid">
      <img class="picture" alt="Image of Cleveland" src="https://cleveland.feb.gov/wp-content/uploads/2018/08/keepbig-homeslide1-cleveland-background1.jpg"/>
    
    
    <div id="login" class="text-center">
      <form class="form-signin" @submit.prevent="login">
        <h1 class="h3 mb-3 font-weight-normal">Cleveland Pothole Tracker</h1>
        <div
          class="alert alert-danger"
          role="alert"
          v-if="invalidCredentials"
        >Invalid username and password!</div>
        <div
          class="alert alert-success"
          role="alert"
          v-if="this.$route.query.registration"
        >Thank you for registering, please sign in.</div>
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
        <!-- <router-link :to="{ name: 'register' }">Need an account?</router-link> -->
        <button type="submit">Sign in</button>
      </form>
      <p class="pothole-title">Active Potholes</p>
    <div class="content">
      
        <div class="potholelist" v-for="pothole in potholes" :key="pothole.id">
          
          <ul>
            <!-- All the potholes will go in here -->
            <potholeCard class="card" v-bind:pothole="pothole" />
          </ul>
        </div>
    </div>
      <router-link :to="{ name: 'report'}">Report A Pothole</router-link>
    </div>
  </div>
</template>

<script>
import authService from "../services/AuthService";
import api from "../services/APIService";
import potholeCard from "../components/PotholeCard";

export default {
  name: "login",
  components: {
    potholeCard,
  },
  data() {
    return {
      potholes: [],
      user: {
        username: "",
        password: "",
      },
      invalidCredentials: false,
    };
  },
  methods: {
    login() {
      authService
        .login(this.user)
        .then((response) => {
          if (response.status == 200) {
            this.$store.commit("SET_AUTH_TOKEN", response.data.token);
            this.$store.commit("SET_USER", response.data.user);
            this.$router.push("/");
          }
        })
        .catch((error) => {
          const response = error.response;

          if (response.status === 401) {
            this.invalidCredentials = true;
          }
        });
    },
  },
  created() {
    api.getPublicPotholes().then((resp) => {
      this.potholes = resp.data;
    });
  },
};
</script>
<style>
.grid{
  display: grid;
  grid-template-columns: 1fr 2fr;
  grid-template-rows: auto 100px 500px 100px;
  grid-template-areas: "picture picture" "title title" "pothole map" "footer footer";
  max-height: 1vh;
}
.content {
  overflow-y: auto;
  overflow-x: hidden;
  border: black solid 2px;
  width: 500px;
  height: 600px;
  grid-area: pothole;
}
.pothole-title{
  grid-area: pothole;
}
#login{
  grid-area: title;
  text-align: center;
}
.card {
  border: black solid 1px;
  text-align: center;
  margin: 10px;
}
.picture{
grid-area: picture;
height: 300px;
margin: 0 auto;
}
.sr-only{
  padding: 5px;
}
</style>
