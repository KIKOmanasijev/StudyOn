<template>
<div class="single-match-wrapper" v-if="dataFetched">
    <div class="single-match-header">
        <div class="single-match-image">
            <img src="https://via.placeholder.com/700x300"/>         
                            <!-- <h2>{{this.match.fieldName}}</h2> -->
        </div>
        <div class="match-info">
            <div class="match-info-header">
                <span class="sport" :class="getClass(match.type)">{{match ? match.type : 'All Sports'}}</span>
                <button class="accept-match" @click="acceptMatch(match)"><i class="fa fa-check"></i></button>
            </div>
            
            <h3>Игралиште без име</h3>
            <i class="fa fa-user mr-2"></i> уште {{match.maxPlayers - match.currentPlayers}} играчи <br/>
            <i class="fa fa-clock mr-2"></i> {{formatTime(match.startTime)}}
        </div>
    </div>

    <div class="single-match-body">
        <h5>Играчи од натпреварот:</h5>
        <ul>
            <li v-for="player in players" :key="player.id"> <i class="fa fa-check"></i> {{player.userName}}</li>
        </ul>
    </div>
</div>
</template>

<script>
import axios from "axios";
import Swal from 'sweetalert2';

export default {
data(){
    return {
        dataFetched: false,
        match: null,
        players: []
    }
},
created(){
    axios.get(`https://localhost:5001/matches/${this.$route.params.matchId}`).then(res => {
        this.dataFetched = true;
        this.match = res.data.payload;
    }).catch(e => console.log(e));    

    axios.get(`https://localhost:5001/matches/${this.$route.params.matchId}/players`).then(res => {
        this.players = res.data.payload;
    })
},
methods: {
    getClass(type){
        return `${type}`
    },
    formatTime(time){
        return new Date(time).toLocaleString();
    },
    async acceptMatch(match){    
        let data =  { matchId: match.matchId };      
        const instance = axios.create({
            baseURL: 'https://localhost:5001/matches'
        });

        instance.defaults.headers.common['Authorization'] = `bearer ${this.$store.state.jwt}`
        instance.defaults.headers.post['Content-Type'] = "application/json";
        // console.log(instance);
        await instance.post('/join', JSON.stringify(data), {
            headers: {
                'Authorization': `bearer ${this.$store.state.jwt}`
            }
        }).then(res => {
            if (res.data.status == 200){
                Swal.fire({
                    title: 'Успешна потврда на натпревар!',
                    icon: 'success'
                })                    
            }
        });
        this.$store.dispatch('searchMatches');
    }
}
}
</script>

<style scoped>
.match-info-header {
    display: flex;
    justify-content: space-between;
    align-items: center;
}

.match-info-header .accept-match {
    height: 45px;
    width: 45px;
    border-radius: 50%;
    color: white;
    border: none;
    background: #3FE18B;
}
.single-match-wrapper {
    flex: 0 0 35vw;
    max-width: 35vw;
    padding: 20px 35px;
    text-align: left;
    background: white;
}

.single-match-header {
    background: rgb(249, 246, 255);
    border-radius: 15px;
}

.single-match-body {
    margin-top: 20px;
    background: rgb(249, 246, 255);
    border-radius: 15px;
    padding: 10px 18px;
}

.single-match-body li {
    list-style: none;
}

.single-match-body i {
    color: #3FE18B;
    margin-right: 5px;
}

.single-match-header h3 {
    margin-top: 10px;
}

.single-match-image img {
    width: 100%;
    border-radius: 15px;
}

.match-info {
    padding: 10px 18px;
}

.match-info .sport {
    font-size: 12px;
    padding: 5px 30px;
    color: white;
    border-radius: 15px;
    margin-top: 10px;
    display: inline-block;
}

.match-info .sport.Football {
    background: #3FE18B;
}

    .match-info .sport.Tennis {
    background: #52e13f;
}

.match-info .sport.Basketball {
    background: orange;
}

.match-info .sport.Handball {
    background: #1fa9ff;
}

.match-info .sport.Volleyball {
    background: #008080;
}

.match-info .sport.Footsal {
    background: #dd2d2d;
}
</style>