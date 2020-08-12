<template>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<header>
    <img
      id="headerImg"
      alt="RoadWorkImage"
      src="https://callisto.guardian.co.tt/sites/default/files/roadwork%281%29.jpg"
    />
</header>
<body>
    <section id="left-panel">
    <div class = "emp-pthl-list" v-for="pothole in potholes" :key="pothole.id">
        <ul>
            <employeePotholeCard class = "empPthlCard" v-bind:pothole = "pothole"/>
        </ul>
    </div>
    </section>

    <section>
        <!-- <div id = "right-panel">
            <img id= "OhPothole" src="https://i.redd.it/se12qhg8ku011.png" alt="Ohio Pothole Image">
        </div> -->
    </section>
</body>
<footer>
    
</footer>
</html>
</template>

<script>
import employeePotholeCard from "../components/EmployeePotholeCard";
import api from "../services/APIService";
export default {
    components: {
        employeePotholeCard
    },
data(){
    return{
        potholes: []
    }
},
created(){
    api.getPublicPotholes().then(resp => {
        this.potholes = resp.data;
    })
}
}

</script>

<style scoped>
body {
    margin:0;
    padding: 0;
    /* max-height: 100vh; also tried min-height */
    /* background: url(https://i.redd.it/se12qhg8ku011.png) left / cover no-repeat; this is OH pothole */
    display: flex;
    text-align: center;
}

.empPthlCard{
    margin-right: 40px;
    /* margin-bottom: 10px; */
}
.empPthlCard:hover {
    background-color:gray; /*was lightblue*/
    font-weight: bolder;
}

#left-panel {
    background-color: lightgray;
    display: flex;
    flex-direction: column;
    flex-basis: 100%;
    justify-content: center;
    margin: 0px 300px 0px 300px;
    border-radius: 10px;
}

/* #right-panel {
    display: flex;
    flex-direction: column;
    flex-basis: 100%;
    justify-content: center;
    padding-left: 575px;
    flex-grow: 1;
} */
/* #OhPothole {
    display: flex;
    position: fixed;
    height: auto;
    width: 350px;
}  */

#headerImg {
    /*height was 300px*/
    /* margin-left: auto;
    margin-right: auto; */
    height: 375px;
    width: 100%;
    /* display: flex;
    justify-self: center; */
}
</style>