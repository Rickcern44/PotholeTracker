<template>
  <div id="app">
    <div id="nav">
      <router-link class="link" v-bind:to="{ name: 'home' }" v-if="getPages()">Home</router-link> 
      <router-link class="link"  v-bind:to="{ name: 'admin' }" v-if="getUserRole()">Administration</router-link>
      <router-link class="link"  v-bind:to="{ name: 'employee' }"  v-if="addEmployeeLink()">Employee</router-link>
      <router-link class="link"  v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
    </div>
    <router-view />
  </div>
</template>
<script>
export default {
  data(){
    return {

    }
  },
  methods:{
    getPages(){
      if(this.$route.name === 'home' || this.$route.name === 'employee' || this.$route.name === 'admin'){
          return false;
      }else{
        return true
      }
    },
    addEmployeeLink(){
      if (this.$route.name === 'admin'){
        return true
      }else{
        return false
      }
    },
    getUserRole(){
      let role = this.$store.state.user.role

      if (role == "admin"){
        return true;
      }
    }
  }
}
</script>
<style scoped>
.link{
  padding: 5px;
  margin: 20px 5px 5px 5px ;


}
</style>
