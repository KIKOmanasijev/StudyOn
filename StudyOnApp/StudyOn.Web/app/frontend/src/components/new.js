import Vue from 'vue';
import axios from 'axios';

const client = axios.create({
    baseURL: 'http://localhost:5000/api/users/',
    json: true
})

export default {
    async execute(method, resource, data) {
        const accessToken = await Vue.prototype.$auth.getAccessToken()
        return client({
            method,
            url: resource,
            data,
            headers: { }
        }).then(req => {
            return req.data
        })
    },
    register() {
        return this.execute('register', '/');
    }
}