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
    </div>
</template>

<script>
import axios from "axios";

export default {
    data(){
        return {
            dataFetched: false,
            match: null
        }
    },
    created(){
       axios.get(`https://localhost:5001/matches/${this.$route.params.matchId}`).then(res => {
        //    console.log(res.data.payload.Players);
            this.dataFetched = true;
            this.match = res.data.payload;
        }).catch(e => console.log(e));    
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
            }).then(res => console.log(res));
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