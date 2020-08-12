<template>
<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Document</title>
  </head>
  <h1 id="page-title">The Cleveland Pothole Tracker</h1>
  <h2 id="page-title">Admin Page</h2>
  <body id="main-grid">
    <div id="content" >
      <!-- <div id ="container"> -->
      <div id="emp-list" v-for="pothole in potholes" :key="pothole.id">
      <ul>
        <p>Pothole ID: {{pothole.id}}</p>
        <p>Pothole Location: {{pothole.location}}</p>
        <p>Status: {{pothole.status}}</p>
        <!-- Update status dropdown -->
        <p>Description: {{pothole.description}}</p>
        <p>Date Added: {{pothole.dateAdded}}</p>
        <p>Severity: {{pothole.severity}}</p>
        <!-- Update severity dropdown -->
        <p>Employees Assigned: {{pothole.userId}}</p>
      </ul>
      </div>
      <!-- </div> -->
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

<style scoped>
@import url("https://fonts.googleapis.com/css2?family=Oswald:wght@200&display=swap");
#page-title {
  text-align: center;
  font-weight: bold;
  
}

#admin-button {
  /* display: flex; */
  
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
#main-grid {
  display: grid;
  grid-template-columns: 1fr .5fr 1fr;
  grid-template-areas:
    "list  button ohio"
    "footer  . .";
}
#content {
  display: flex;
  /* flex-grow: 1; */
  flex-direction: column;
  /* justify-content: center; */
  /* object-fit: contain; */
  /* align-self: auto; */
  grid-area: list;
  /* border: black solid 2px; */
  overflow-y: auto;
  overflow-x: hidden;
  max-height: 535px;
  /* text-align: center; */
  /* padding-top: 190px; */
  /* display: flex; */
  /* align-items: flex-start; */
  border: black solid 1px;
  /* max-height: 200px; */
  max-width: 450px;
  /* grid-area: list; */
}


#ohio {
  grid-area: ohio;
  justify-self: right;
  /* align-self: ; */
}

/* .admin-pthl-list {
  grid-area: list;
} */
#footer {
  grid-area: footer;
}
#rlink {
  color: white;
}
#emp-list {
  display: flex;
  /* align-items: flex-start; */
  flex-direction: column;
  border: black solid 1px;
  max-height: 300px;
  max-width: 500px;
  text-align: center;
  grid-area: list;

}
* {
  font-family: "Oswald", sans-serif;
}
</style>