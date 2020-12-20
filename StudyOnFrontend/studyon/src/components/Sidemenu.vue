<template lang="">
    <div class="sidemenu">
        <div class="logo">
            <span>S</span>
        </div>

        <div class="menu">
            <ul>
                <li><i class="flaticon-map active"></i></li>
                <li><i class="flaticon-football-game-field"></i></li>
                <li><i class="flaticon-ask"></i></li>    
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

        box-shadow: 2px 0 15px rgba(0,0,0, .1);
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

    .sidemenu .menu li i{
        font-size: 30px;
        font-weight: 500;
    }

    .sidemenu .menu li i.active {
        color: #685EFF;
        font-weight: 600;
    }

    .sidemenu .menu li:not(:last-of-type){
        margin-bottom: 40px;
    }
</style>