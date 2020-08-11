<template>
    <div>   
        <admin-page/>
    </div>
</template>

<script>
import api from '../services/APIService'
import AdminPage from '../components/AdminPage'
export default {
components:{
    AdminPage
},
created(){
    api.getAllUsers().then(resp => {
        this.employeeList = resp.data
    })
},
data(){
    return{
        employeeList: []
    }
}
}
</script>

<style>

</style>