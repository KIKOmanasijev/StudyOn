<template>
    <div class="single-match-wrapper">
       <div class="single-match-header">
            <div class="single-match-image">
                <img src="https://via.placeholder.com/700x300"/>         
                                <!-- <h2>{{this.match.fieldName}}</h2> -->
            </div>
            <div class="match-info">
                <span class="sport Football">{{match ? match.type : 'All Sports'}}</span>
                <h3>Игралиште без име</h3>
            </div>
        </div>
    </div>
</template>

<script>
import axios from "axios";

export default {
    data(){
        return {
            match: null
        }
    },
    created(){
       axios.get(`https://localhost:5001/matches/${this.$route.params.matchId}`).then(res => {
            console.log(res.data.payload);
            this.match = res.data.payload;
        }).catch(e => console.log(e));
    }
}
</script>

<style scoped>
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