import axios from 'axios';



export default {

    
    getPublicPotholes(){
        return axios.get('Home')
    },
    reportPothole(newPothole){
        return axios.post('Home/Report', newPothole)
    },
    updatePotholeStatus(id, status){
        const url = `Update/${id}/${status}`
        return axios.put(url)
    },
    updatePotholeSeverity(id, severity){
        const url = `Severity/${id}/${severity}`
        return axios.put(url)
    },
    getAllUsers(){
        return axios.get('Login')
    },
    updateUserFirstName(id, firstName){
        return axios.put(`Login/Update/id=${id}&firstName=${firstName}`)
    },
    updateUserLastName(id, lastName){
        return axios.put(`Login/Update/id=${id}&lastName=${lastName}`)
    },
    updateUserEmail(id, Email){
        return axios.put(`Login/Update/id=${id}&email=${Email}`)
    },
    updateUserPhone(id, Phone){
        return axios.put(`Login/Update/id=${id}&phone=${Phone}`)
    }
}