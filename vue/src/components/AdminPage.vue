<template>
<!doctype html>
<html lang="en">
  <head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Document</title>
  </head>
  <h1 id="page-title">The Cleveland Pothole Tracker</h1>
  <h2 id="page-title">Admin Page</h2>
  <body id="main-grid">
    <div id="content" class="admin-pthl-list" v-for="pothole in potholes" :key="pothole.id">
      <div id ="container">
        <p>Pothole ID: {{pothole.id}}</p>
        <p>Pothole Location: {{pothole.location}}</p>
        <p>Status: {{pothole.status}}</p>
        <!-- Update status dropdown -->
        <p>Description: {{pothole.description}}</p>
        <p>Date Added: {{pothole.dateAdded}}</p>
        <p>Severity: {{pothole.severity}}</p>
        <!-- Update severity dropdown -->
        <p>Employees Assigned: {{pothole.userId}}</p>
      </div>
    </div>
    <button id="admin-button">
      <router-link id="rlink" :to="{ name: 'register' }">Register a new employee</router-link>
    </button>

    <div id="ohio">
      <img src="https://i.redd.it/se12qhg8ku011.png" alt="picture of Ohio shaped pothole" />
    </div>
    <!-- <div id="content">
      <div class="potholelist" v-for="pothole in potholes" :key="pothole.id">
        <ul>
          <potholeCard class="card" v-bind:pothole="pothole" />
        </ul>
      </div>
    </div>-->
    <footer id="footer">&copy; The Pothole Tracker 2020</footer>
  </body>
</html>
</template>

<script>
import api from "../services/APIService";
export default {
  data() {
    return {
      potholes: [],
      employeeList: [],
    };
  },
  methods() {},
  created() {
    api.getPublicPotholes().then((resp) => {
      this.potholes = resp.data;
    });
  },
  mounted() {},
};
</script>

<style>
#page-title {
  text-align: center;
  font-weight: bold;
  font-family: "Oswald", sans-serif;
}

#admin-button {
  /* display: flex; */
  font-family: "Oswald", sans-serif;
  font-size: 20px;
  justify-content: center;
  text-align: center;
  /* align-self: flex-start; */
  font-weight: bolder;
  background-color: lawngreen;
  height: 60px;
  grid-area: list;
  box-shadow: black 2px 2px;
  border-radius: 5px;
  grid-area: button;
}
#admin-button:hover {
  border: black solid 3px;
}

#content {
  display: flex;
  flex-grow: 1;
  flex-direction: column;
  justify-content: center;
  object-fit: contain;
  align-self: auto;
  grid-area: list;
  border: black solid 2px;
  overflow-y: auto;
  overflow-x: hidden;
  max-height: 600px;
  text-align: center;
  /* padding-top: 190px; */
}
#main-grid {
  display: grid;
  grid-template-columns: 1fr 1fr 1fr;
  grid-template-areas:
    "list  button ohio"
    "footer  . .";
}

#ohio {
  grid-area: ohio;
  justify-self: right;
  /* align-self: ; */
}

.admin-pthl-list {
  grid-area: list;
}
#footer {
  grid-area: footer;
}
#rlink {
  color: white;
}
#container {
  border: black 1px;
  
}
</style>