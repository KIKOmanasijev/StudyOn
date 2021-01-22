<template lang="">
    <div class="sidemenu">
        <div class="logo">
            <router-link to="/"><span>S</span></router-link>
        </div>

        <div class="menu">
            <ul>
                <li class="active"><router-link to="/"><i class="flaticon-map"></i></router-link></li>
                <li><router-link to="/fields"><i class="flaticon-football-game-field"></i></router-link></li>
                <li><router-link to="/faq"><i class="flaticon-ask"></i></router-link></li>    
            </ul>
        </div>

        <div class="user-profile">
            <!-- Default dropright button -->
            <div class="btn-group dropright">
                <button type="button" class="btn btn-secondary dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    H
                </button>
                <div class="dropdown-menu">
                   <button v-if="$store.state.loggedUser" @click="logOut">Log out <i class="fas fa-sign-out-alt"></i></button>
                   <button v-else @click="logIn">Log In <i class="fas fa-user"></i> </button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import('../assets/fonts/flaticon.css');
import Swal from 'sweetalert2'

export default {
    name: "Sidemenu",
    data(){
        return {
            userInput: '',
            passInput: ''
        }
    },
    methods: {
        logIn(){
            Swal.fire({
                title: 'Најава',
                html: '<input id="swal-input1" type="text" class="swal2-input" placeholder="Email">' +
                      '<input id="swal-input2" type="password" class="swal2-input" placeholder="Password" >',
                confirmButtonText: 'Најави се',
                showCancelButton: true,
                cancelButtonText: 'Откажи',
            }).then((res) => {
                if (res.isConfirmed){
                    var email = document.getElementById('swal-input1').value;
                    var password = document.getElementById('swal-input2').value;
                    //TODO LOGIN functionality
                    this.$store.commit('logInUser', {
                        user: {
                            email,
                            password
                        }
                    })
                }
            });
           
        },
        logOut(){
             Swal.fire({
                title: 'Одјава',
                text: 'Потврдете за да се одјавите',
                icon: 'warning',
                confirmButtonText: 'Одјави се',
                showCancelButton: true,
                cancelButtonText: 'Откажи',
            }).then((result) => {
                if (result.isConfirmed) {
                    Swal.fire({
                        title: 'Одјавата беше успешна',
                        icon: 'success'
                    })
                    this.$store.commit('logOutUser');
                }
            })

            
        }
    }
}
</script>

<style scoped>
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

    .dropdown-menu {
        padding: 0;
    }

    .dropdown-menu button {
        background: #fff;
        width: 100%;
        border: none;
        padding: 14px 30px;
        font-size: 18px;
    }

    .dropdown-menu button i {
        display: inline-block;
        font-size: 16px;
        margin-left: 10px;
    }

    .sidemenu .logo span, .btn-secondary {
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

    .dropright .dropdown-toggle::after {
        display: none;
    }

    .sidemenu a {
        text-decoration: none;
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

    .sidemenu .menu .router-link-exact-active i {
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