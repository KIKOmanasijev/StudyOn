<template>
    <div id="btn-register">
        <button v-on:click="register">register</button>
    </div>
</template>

<script>
    import Vue from 'vue';
    import axios from 'axios';

    const client = axios.create({
        baseURL: 'http://localhost:5000/api/users/',
        json: true
    })

    export default {
        async execute(method, resource, data) {
            const accessToken = await Vue.prototype.$auth.getAccessToken();
            return client({
                method,
                url: resource,
                data,
                headers: {}
            }).then(req => {
                return req.data
            })
        },
        registerService() {
            return this.execute('register', '/');
        }
    }
    var exampleRegister = new Vue({
        el: "#btn-register",
        methods: {
            register: function () {
                console.log('this')
            }
        }
    })
</script>



<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
    h3 {
        margin: 40px 0 0;
    }

    ul {
        list-style-type: none;
        padding: 0;
    }

    li {
        display: inline-block;
        margin: 0 10px;
    }

    a {
        color: #42b983;
    }
</style>
