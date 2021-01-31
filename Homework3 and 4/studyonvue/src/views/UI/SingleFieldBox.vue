<template>
<div class="single-match-wrapper" v-if="dataFetched">
    <div class="single-match-header">
        <div class="single-match-image">
            <img src="https://via.placeholder.com/700x300"/>         
                            <!-- <h2>{{this.match.fieldName}}</h2> -->
        </div>
        <div class="match-info">
            <div class="match-info-header">
                <span><i class="fa fa-star"></i> {{field.averageRating ? field.averageRating : '0'}}</span>
                <span class="type">{{field.sport ? field.sport : "За сите спортови"}}</span>
            </div>
            
            <h3>{{ field.fieldName ? field.fieldName : 'Игралиште без име'}}</h3>           
        </div>        
    </div>
    
    <div class="single-match-body">
        <div class="row">
            <div class="col-md-6">
                <h4>Коментари:</h4>
                <ul v-if="ratings" class="ratings-wrapper">
                    <li v-for="rate in ratings" :key="rate.id">
                        <div class="single-rating-header">
                            <h6>Корисник: {{rate.userName}}</h6>
                            <ul class="stars-rating">
                                <li v-for="(star, index) in rate.rate" :key="index">
                                    <i class="fa fa-star"></i>
                                </li>
                            </ul>
                            <p class="my-0">{{rate.comment}}</p>
                        </div>
                    </li>
                </ul>
                <p v-else>Нема коментари</p>
            </div>
            <div class="col-md-6">
                <h4>Остави коментар</h4>

                <input class="comment-input" type="text" v-model="currentComment"/>
                <input class="rating-input" type="number" min="1" max="5" v-model="currentRating">

                <button class="submit-button" type="button" @click="submitRating">Испрати</button>
            </div>
        </div>
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
        field: null,
        players: [],
        ratings: [],
        currentComment: '',
        currentRating: 5,
        matchId: ''
    }
},
created(){
    this.matchId = this.$route.params.matchId;
    axios.get(`http://localhost:5000/courts/${this.$route.params.matchId}`).then(res => {
        this.dataFetched = true;
        this.field = res.data.payload;
    }).catch(e => console.log(e));    

    axios.get(`http://localhost:5000/courts/${this.$route.params.matchId}/ratings`).then(res => {
        this.ratings = res.data.payload;
    }).catch(e => console.log(e));    
},
methods: {
    getClass(type){
        return `${type}`
    },
    submitRating(){
        axios.post(`http://localhost:5000/courts/review/${this.matchId}`, {
            'CourtId': parseInt(this.matchId),
            'Rate': parseInt(this.currentRating),
            'Comment': this.currentComment
        }, {
            headers: {
                "Authorization": `bearer ${this.$store.state.jwt}`,
            }
        }).then(res => {
            if (res.data.status == 200){
                Swal.fire({
                    title: 'Успешна потврда на натпревар!',
                    icon: 'success'
                })                    
            }
        })
    }
}
}
</script>

<style scoped>
.ratings-wrapper > li {
    padding: 10px;
    background: white;
    margin-bottom: 10px;
    border-radius: 8px;
}
.match-info-header {
    display: flex;
    justify-content: space-between;
    align-items: center;
}

.fa-star {
    color: #eedc40 !important;
}

.match-info-header .type {
    background: #3FE18B;
    color: #fff;
    border-radius: 10px;
    padding: 10px 25px;
}

.submit-button {
    background: #3FE18B;
    color: #fff;
    border-radius: 10px;
    border: none;
    padding: 8px 20px;
    margin-top: 10px;
}

.rating-input, .comment-input {
    width: 100%;
    border: none;
}

.comment-input {
    margin-bottom: 5px;
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

.stars-rating {
    padding-left: 0;
    display: flex;
}

.ratings-wrapper {
    padding-left: 0;
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