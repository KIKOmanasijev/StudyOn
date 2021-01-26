<template>
    <div class="list-panel">
        <div class="search">
            <div class="wrapper">
                <div class="input-group">
                    <span class="input-group-prepend">
                        <select class="form-control" name="searchSport" v-model="searchSport">
                            <option value="">Сите</option>   
                            <option value="Football">Футбал</option>   
                            <option value="Footsal">Футсал</option>
                            <option value="Basketball">Koшарка</option>
                            <option value="Tennis">Тенис</option>
                            <option value="Handball">Ракомет</option>
                            <option value="Volleyball">Одбојка</option>
                        </select>
                        <!-- <div class="input-group-text border-none"><i class="fa fa-search"></i></div> -->
                    </span>
                
                    <!-- <input class="form-control" type="search" placeholder="Пребарувај овде" id="example-search-input">                -->
                </div>
                <button class="search-button" type="button" @click="searchMatch">Пребарувај</button>
            </div>
            <button v-if="$store.state.loggedUser" class="add-match" @click="toggleModal">+</button>
        </div>       

        <p class="search-result-info text-left my-5">
            Пронајдовме <strong> {{$store.state.matches.length}} </strong> од Вашето барање...
        </p>

        <div class="results">
            <div class="match-wrapper row" v-for="match in $store.state.matches" v-bind:key="match.id">
                <div class="col-md-3">
                    <img v-bind:src="'https://via.placeholder.com/500x500'">
                </div>
                <div class="col-md-9">
                    <router-link :to="'/match/' + match.id" class="match-meta">
                        <div class="match-info">
                            <span class="sport" :class="match.type">{{match.type}}</span>
                            <h2>{{match.fieldName ? match.fieldName : 'Игралиште без име'}}</h2>

                            <div class="players-meta">
                                <i class="flaticon-user-profile"></i> {{playersMissing(match.currentPlayers, match.maxPlayers)}}
                            </div>
                            <div class="time-meta">
                                <i class="flaticon-search"></i> <strong>{{formatHours(match.startTime)}}</strong> {{formatDate(match.startTime)}}
                            </div>
                        </div>
                        <div class="match-actions">
                            <div class="accept"><i class="flaticon-verification-checkmark-symbol"></i></div>
                        </div>
                    </router-link>
                </div>
            </div>
    </div>
    </div>
</template>

<script>
import('../assets/css/all.css');
import Swal from 'sweetalert2'
export default {
    name: "ListMatches",
    data(){
        return {
            searchSport: ""
        }        
    },
    props: {
        
    },
    inject: ['getAllMatches', 'addMatch'],
    methods: {
        searchMatch(){
            this.getAllMatches(this.searchSport)
        },
        playersMissing(curr, maxPlayers){
            return `Уште ${(maxPlayers)-curr} играчи`;
        },
        formatHours(date){
            let tmp = new Date(date+"Z");
            return `${tmp.getHours()}:${tmp.getMinutes()}`;
        },
        formatDate(date){
            let tmp = new Date(date+"Z");
            return `${tmp.getDate()+1}.${tmp.getMonth()+1}.${tmp.getFullYear()+1}`;
        },
        toggleModal(){
            Swal.fire({
                title: 'Додај натпревар',
                icon: 'warning',
                confirmButtonText: 'Додај',
                confirmButtonColor: '#3FE18B',
                showCancelButton: true,
                cancelButtonText: 'Откажи',
                html: '<input id="swal-input2" type="number" class="swal2-input" placeholder="Потребни играчи" style="max-width: 100%">' +
                      `<select id="swal-input3" class="swal2-input swal2-select" style="max-width: 100%; display: flex;">
                        <option value="" disabled="">Избери Спорт</option>
                        <option value="Football">Футбал</option>
                        <option value="Basketball">Кошарка</option>
                        <option value="Handball">Ракомет</option>
                        <option value="Footsal">Футсал</option>
                        <option value="Volleyball">Одбојка</option>
                        <option value="Tennis">Тенис</option>
                        </select>
                        <input id="swal-input4" type="datetime-local" class="swal2-input">
                        <input id="swal-input5" type="number" class="swal2-input" placeholder="Времетраење на натпревар" style="max-width: 100%">
                        `
                      ,
            }).then((res) => {
                //TODO add match
                if (res.isConfirmed){
                    let startDate = new Date(document.getElementById("swal-input4").value);
                    let endDate = new Date(document.getElementById("swal-input4").value)
                    endDate.setHours(startDate.getHours() + parseInt(document.getElementById("swal-input5").value));
                    let match = {
                        CourtId: "364978134",
                        Type: document.getElementById("swal-input3").value,
                        MaxPlayers: document.getElementById("swal-input2").value,
                        StartTime: startDate.toISOString(),
                        EndTime: endDate.toISOString()
                    } 

                    this.addMatch(match);
                }
            })
        }
    }
}
</script>

<style scoped>
    .form-control {
        background: transparent;
        border:none;
    }
    
    .list-panel {
        padding: 50px 30px;
        flex: 0 0 35vw;
        background-color: #FCFBFF;

        overflow: scroll;
    }

    .search {
        display: flex;
        justify-content: space-between;
        align-content: center;
    }

    .search .add-match {
        font-size: 32px;
        height: 70px;
        width: 70px;
        background: #3FE18B;
        color: #fff;
        border-radius: 50%;
        border: none;
        margin-left: 20px;
    }

    .add-match:focus {
        outline: none;
    }

    .input-group {        
        font-size: 18px;
        font-weight: lighter;
        background: #ECEBF8;
        padding: 15px 25px;
        border-radius: 10px;
        border: none;
        width: auto;
    }

    input.form-control {
        font-size: 18px;
        font-weight: lighter;
        border: none;
        background: transparent;
    }

    input.form-control::placeholder{
        font-size: 18px;
        color: #333;
    }

    input.form-control:active, input.form-control:focus {
        outline: none !important;
        border: none !important;
        background: transparent !important;
        box-shadow: none !important;
    }

    .border-none {
        border: none;
        background: transparent;
    }

    .search-result-info {
        color: #999;
    }

    .search-result-info strong {
        color: #777;
    }

    .match-wrapper {
        display: flex;
    }

    .match-wrapper:not(:last-of-type){
        margin-bottom: 40px
    }

    .match-wrapper img {
        width: 100%;
        height: 100%;
        object-fit: cover;
        border-radius: 15px;
        margin-right: 20px;
    }

    .match-wrapper .col-md-9{
        display: flex;
        flex-direction: column;
        justify-content: center;
        text-align: left;
    }

    .match-info .sport {
        font-size: 12px;
        padding: 5px 30px;
        color: white;
        border-radius: 15px;
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

    .match-meta {
        display: flex;
        justify-content: space-between;
        align-items: center;
    }

    .match-info h2 {
        font-size: 22px;
        font-weight: 500;
        color: #444;
        margin: 15px 0;
    }

    .match-info .players-meta, .time-meta {
        font-size: 12px;
        color: #999;
    }

    .match-info .players-meta i, .time-meta i {
        font-size: 14px;
        margin-right: 8px;
        color: #685EFF;
    }

    .match-info .time-meta {
        margin-top: 0px;
    }

    .match-wrapper a {
        text-decoration: none;
    }

    .match-actions .accept i{
        background-color: #3FE18B;
        color: #fff;
        font-size: 18px;
        height: 40px;
        width: 40px;
        display: flex;
        align-items: center;
        justify-content: center;
        border-radius: 50%;
    }

    .form-control {
        padding: .375rem 2rem
    }
    .wrapper {
        display: flex;
    }
    .search-button {
        border: none;
        border-radius: 15px;
        background: #999;
        color: white;
        margin-left: 5px;
        padding: 0 15px;
    }
</style>