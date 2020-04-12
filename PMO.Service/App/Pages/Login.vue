<template>
    <div id="login">
        <h3 class="text-center text-white pt-5">Login form</h3>

        <div id="login-row" class="row justify-content-center align-items-center">
            <div id="login-column" class="col-md-6">
                <div id="login-box" class="col-md-12">
                    <div id="login-form" class="form">
                        <h3 class="text-center text-info">Login to PMO</h3>
                        <div class="form-group">
                            <label for="username" class="text-info">Username:</label><br>
                            <input type="text" name="username" id="username" v-model="userName" class="form-control">
                        </div>
                        <div class="form-group">
                            <label for="password" class="text-info">Password:</label><br>
                            <input type="text" name="password" id="password" v-model="password" class="form-control">
                        </div>
                        <div class="form-group">                            
                            <button @click="login" class="btn btn-info btn-md">Submit</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div v-if="authMessage.length > 0">
            Error: {{authMessage}}
        </div>

    </div>
</template>
<script>
    import axios from 'axios';
    export default {
        name: 'Login',
        data() {
            return {
                userName: '',
                password: '',
                authMessage: ''
            };
        },
        methods: {
            login() {
                var self = this;
                this.authMessage = "";
                var url = window.appSettings.baseServiceUrl + 'api/Auth/login';
                axios.post(url, {
                    "UserName": this.userName,
                    "Password": this.password
                })
                    .then(function (response) {

                        if (self.checkData(response.data) && self.checkData(response.data.UserDetails) && self.checkData(response.data.Token)) {
                            self.$store.commit('changeUserDetails', response.data.UserDetails);
                            self.$store.commit('changeAuthtoken', response.data.Token);
                            self.$router.push('/executive-dashboard/AllProjects');
                        }
                        else {
                            self.authMessage = "There was an error signing in";
                        }
                    })
                    .catch(function (error) {
                        console.log(error);                        
                        self.authMessage = "There was an error signing in";
                    }); 

            },
            checkData(obj) {
                return (obj != null || obj != undefined);
            }
        },
        mounted() {
            this.authMessage = this.$store.getters.authMessage;
            console.log(this.authMessage);
        }
    };
</script>
<style scoped>
    body {
        margin: 0;
        padding: 0;
        background-color: #17a2b8;
        height: 100vh;
    }

    #login #login-row #login-column #login-box {
        margin-top: 120px;
        max-width: 600px;
        height: 320px;
        border: 1px solid #9C9C9C;
        background-color: #EAEAEA;
    }

        #login #login-row #login-column #login-box #login-form {
            padding: 20px;
        }

            #login #login-row #login-column #login-box #login-form #register-link {
                margin-top: -85px;
            }
</style>