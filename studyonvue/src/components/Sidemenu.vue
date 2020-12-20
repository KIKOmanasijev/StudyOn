<template lang="">
    <div class="sidemenu">
        <div class="logo">
            <span>S</span>
        </div>

        <div class="menu">
            <ul>
                <li class="active"><a href="#"><i class="flaticon-map"></i></a></li>
                <li><a href="#"><i class="flaticon-football-game-field"></i></a></li>
                <li><a href="#"><i class="flaticon-ask"></i></a></li>    
            </ul>
        </div>

        <div class="user-profile">
            <span>H</span>
        </div>
    </div>
</template>

<script>
import('../assets/fonts/flaticon.css');

export default {
    name: "Sidemenu"
}
</script>

<style>
    .sidemenu {
        display: flex;
        flex-direction: column;
        justify-content: space-between;
        align-items: center;
        width: 100px;
        height: 100%;
        padding: 50px 15px;

        box-shadow: 2px 0 15px rgba(0,0,0, .07);
        z-index: 100;
    }

    .sidemenu .logo span {
        font-size: 40px;
        font-weight: 700;
        display: flex;
        justify-content: center;
        align-items: center;
        width: 60px;
        height: 60px;
        color: #fff;
        background: #685EFF;
        border-radius: 50%;
    }

    .sidemenu .user-profile span {
        font-size: 40px;
        font-weight: 700;
        display: flex;
        justify-content: center;
        align-items: center;
        width: 60px;
        height: 60px;
        color: #fff;;
        background: #777;
        border-radius: 50%;
    }

    .sidemenu .menu ul {
        list-style: none;
        padding-left: 0;
    }

    .sidemenu .menu li a i{
        font-size: 30px;
        font-weight: 500;
        color: #999;
    }

    .sidemenu .menu .active i {
        color: #685EFF;
        font-weight: 600;
    }

    .sidemenu .menu li a {
        text-decoration: none;
    }

    .sidemenu .menu li:not(:last-of-type){
        margin-bottom: 40px;
    }
</style>