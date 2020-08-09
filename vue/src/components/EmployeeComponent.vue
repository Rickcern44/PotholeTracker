<template>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<header>

</header>
<body>
    <section id="left-panel">
    <div class = "emp-pthl-list" v-for="pothole in potholes" :key="pothole.id">
        <ul>
            <employeePotholeCard class = "empPthlCard" v-bind:pothole = "pothole"/>
        </ul>
    </div>
    </section>

    <section id = "right-panel">
        <div>
            Where does this display? Will it grow if I type more?  It does!
        </div>
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
}

#left-panel {
    background-color: lightgray;
    display: flex;
    flex-direction: column;
    flex-basis: 100%
}

#right-panel {
    display: flex;
    flex-direction: column;
    flex-basis: 100%;
    background: url(https://i.redd.it/se12qhg8ku011.png)
}
</style>