<template>
    <div class="list-panel">
        <div class="search">
           <div class="input-group">
                <span class="input-group-prepend">
                    <div class="input-group-text border-none"><i class="fa fa-search"></i></div>
                </span>
                <input class="form-control" type="search" placeholder="Пребарувај овде" id="example-search-input">               
            </div>

            <p class="search-result-info text-left my-5">
                Пронајдовме <strong> 13 резултати </strong> од Вашето барање...
            </p>
        </div>

        <div class="results">
            <div class="match-wrapper row">
                <div class="col-md-3">
                    <img src="https://ading.com.mk/CMS/Upload/Referenci/tenisko-igraliste-micei-international(1).jpg" alt="">
                </div>
                <div class="col-md-9">
                    <a href="#" class="match-meta">
                        <div class="match-info">
                            <span class="sport football">Football</span>
                            <h2>Игралиште Форза Карпош</h2>

                            <div class="players-meta">
                                <i class="flaticon-user-profile"></i> Уште 5 играчи
                            </div>
                            <div class="time-meta">
                                <i class="flaticon-search"></i> <strong>18:30</strong> 21.12.2020
                            </div>
                        </div>
                        <div class="match-actions">
                            <div class="accept"><i class="flaticon-verification-checkmark-symbol"></i></div>
                        </div>
                    </a>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import('../assets/css/all.css');
export default {
    name: "ListMatches"
}
</script>

<style>
    .list-panel {
        padding: 50px 30px;
        flex: 0 0 35vw;
        background-color: #FCFBFF;
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

    input.form-control:active, :focus {
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

    .match-wrapper img {
        width: 150px;
        height: 150px;
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
        font-size: 14px;
        padding: 8px 30px;
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
        margin-top: 20px;
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
</style>