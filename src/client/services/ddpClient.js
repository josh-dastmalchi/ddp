import axios from 'axios'
import applicationConfiguration from '../services/applicationConfiguration.js'

export default axios.create({
    baseURL: applicationConfiguration.baseUrl,
    headers: {
        'Content-Type': 'application/json',
        'Accept': 'application/json'
    }
});