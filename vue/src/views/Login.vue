<template>
  <body>
    <header>
      <img
        id="header-image"
        alt="Image of Cleveland"
        src="https://hoodline-assets.imgix.net/metros/cleveland.jpg"
      />
    </header>
    <!-- The page title -->
    <h1 id="title" class="h3 mb-3 font-weight-normal">The Cleveland Pothole Tracker</h1>
    <div id="container">
      <!-- Login form div -->
      <div id="login" class="text-center">
        <form class="form-signin" @submit.prevent="login">
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
          <button type="submit">Sign in</button>
        </form>
        </div>
      <button id="report-button">
        <!-- TODO: Make the button text white -->
        <router-link id="rlink"  :to="{ name: 'report'}">Report A Pothole</router-link>
      </button>
      <div id="content">
        <div class="potholelist" v-for="pothole in potholes" :key="pothole.id">
          <ul>
            <potholeCard class="card" v-bind:pothole="pothole" />
          </ul>
        </div>
      </div>
      <div id="map">
        <img id="test-map"
          src="https://northstar-pres.com/wp-content/uploads/2015/10/google-map-placeholder.png"
          alt="The google map"
        />
      </div>
    </div>
    <!-- <footer id="footer">footer</footer> -->
    <!-- <router-link :to="{ name: 'register' }">Need an account?</router-link> -->
</body>
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
@import url("https://fonts.googleapis.com/css2?family=Oswald:wght@200&display=swap");
*{
  box-sizing: border-box;
  font-family: "Oswald", sans-serif;
  font-weight: bold;
}

header img {
  /* increased height from 250px */
  height: 375px;
  width: 100%;
  margin-bottom: 10px;
}
#title {
  text-align: center;
  font-family: "Oswald", sans-serif;
}
#container {
  display: grid;
  grid-template-columns: 1.5fr 2fr;
  row-gap: 5px;
  column-gap: 5px;
  align-items: center;
  grid-template-areas:
  "login map"
  "list map";
}

#report-button{
  display: flex;
  font-family: 'Oswald', sans-serif;
  font-size: 30px;
  justify-content: center;
  align-self: flex-start;
  font-weight: 800;
  background-color: red;
  height: 60px;
  grid-area: list;
  box-shadow: black 2px 2px;
  border-radius: 5px;
}
#login{
  display: flex;
  grid-area: login;
  justify-content: flex-start;
}
#content{
display: flex;
flex-direction: column;
justify-content: center;
align-self: flex-end;
grid-area: list;
border: black solid 3px;
overflow-y: auto;
overflow-x: hidden ;
height: 200px;
text-align: center;

}
#map{
  display: flex;
  height: 80%;
  width: 100%;
  justify-content: center;
  grid-area: map;
}
.card{
  border-bottom: black solid 1px;
}
#rlink{
  color: white;
}


</style>
