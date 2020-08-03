import axios from 'axios';

export default {

    getPublicPotholes(){
        return axios.get('Home')
    }
}