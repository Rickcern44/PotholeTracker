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
    }
}