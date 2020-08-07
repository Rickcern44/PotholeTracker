import axios from 'axios';

export default {

    getPublicPotholes(){
        return axios.get('Home')
    },
    reportPothole(newPothole){
        return axios.post('Home/Report', newPothole)
    },
    updatePotholeStatus(pothole){
        return axios.put('Home/Update' , pothole)
    },
    updatePotholeSeverity(id, severity){
        const url = `Severity/${id}/${severity}`
        return axios.put(url)
    }
}