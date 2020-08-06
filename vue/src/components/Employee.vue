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
    <div class = "emp-pthl-list" v-for="pothole in potholes" :key="pothole.id">
        <ul>
            <employeePotholeCard class = "empPthlCard" v-bind:pothole = "pothole"/>
        </ul>
    </div>
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

<style>

</style>