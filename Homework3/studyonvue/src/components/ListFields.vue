<template>
    <div class="list-panel">

        <div class="results">
            <div class="match-wrapper row" v-for="field in $store.state.fields" v-bind:key="field.id">
                <div class="col-md-3">
                    <img v-bind:src="field.images.length ? field.images[0] : 'https://via.placeholder.com/500x500'">
                </div>
                <div class="col-md-9">
                    <router-link :to="'/fields/' + field.id" class="match-meta">
                        <div class="match-info">
                            <span class="sport football">{{field.sport ? field.sport : 'All Sports'}}</span>
                            <h2>{{field.fieldName}}</h2>
                            <div v-if="field.rating" class="field-rating">
                                <i v-for="star in field.rating" :key="star" class="fa fa-star"></i>
                            </div>
                            <div v-else class="field-rating field-unrated">
                                <i class="fa fa-star"></i>
                                <i class="fa fa-star"></i>
                                <i class="fa fa-star"></i>
                                <i class="fa fa-star"></i>
                                <i class="fa fa-star"></i>
                            </div>
                            <div class="field-location">
                              <p class="mb-0">  <b> Lat:</b> {{field.lat}}</p>
                              <p>  <b> Lng:</b> {{field.lng}}</p>
                            </div>
                        </div>
                    </router-link>
                </div>
            </div>
    </div>
    </div>
</template>

<script>
import('../assets/css/all.css');
export default {
    name: "ListFields",
    computed: {
        generateFieldUrl(id){
            return `/fields/${id}`;
        },
        getFieldImage(field){
            console.log(field);
            return field.images.length > 0 ? field.images[0] : 'https://via.placeholder.com/500x500'; 
        }
    },
    props: ['getAllFields'],
    mounted(){
        this.getAllFields();
    },
    methods: {
        printRating(rate){
            console.log(rate);
            let str = "";
            for (let i = 0; i < rate; i++){
                str += `<i class="fa fa-star"></i>`;
            }

            return str;
        }
    }
}
</script>

<style scoped>
    .list-panel {
        padding: 50px 30px;
        flex: 0 0 35vw;
        background-color: #FCFBFF;
    }

    .search {
        display: flex;
        align-content: center;
        margin-bottom: 20px;
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
        box-sizing: initial;
    }

    .add-match:focus {
        outline: none;
    }

    .input-group {        
        font-size: 18px;
        font-weight: lighter;
        background: #ECEBF8;
        width: 100%;
        padding: 15px 25px;
        border-radius: 10px;
        border: none;
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

    .match-info .sport.football {
        background: #3FE18B;
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

    .match-wrapper a {
        text-decoration: none;
    }

    .field-rating {
        margin-top: -5px;
    }

    .field-rating i {
        color: gold;
    }

    .field-unrated i {
        color: rgb(192, 192, 192);
    }

    .field-location p {
        font-size: 13px;
        color: #999;
    }
</style>