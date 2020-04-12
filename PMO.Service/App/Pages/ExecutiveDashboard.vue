<template>

    <div>
        <nav class="navbar navbar-expand-sm bg-light">
            <!-- Links -->

            <a class="navbar-brand" href="#">PMO</a>

            <ul class="navbar-nav">
                <li class="nav-item dropdown" v-if="isProjectAssigned()">
                    <a class="nav-link dropdown-toggle" href="#" id="navbardrop" data-toggle="dropdown">
                        Projects
                    </a>
                    <div class="dropdown-menu">
                        <router-link class="dropdown-item" to="/executive-dashboard/ProjectMaster/ProjectDashboard" v-for="(item, index) in userProjects">
                            {{item.Project.ProjectShortName}}
                        </router-link>
                    </div>
                </li>
                <li class="nav-item">
                    <router-link to="/executive-dashboard/landing" class="nav-link">Create Project</router-link>
                </li>
                <li class="nav-item">
                    <router-link to="/executive-dashboard/AllProjects" class="nav-link">Executive Dashboard</router-link>
                </li>
            </ul>

            <ul class="navbar-nav ml-auto">
                <li class="navbar-text">
                    <span class="primary">{{userDetails.EmpName}}</span>
                    <span class="badge badge-primary">{{userDetails.Designation}},{{userDetails.Department}}</span>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="#" v-on:click="logout()">Logout</a>
                </li>
            </ul>
        </nav>

        <br />
        <div>
            <router-view></router-view>
        </div>
    </div>
</template>
<script>
    import axios from 'axios';
    export default {
        name: 'ExecutiveDashboard',
        data() {
            return {
                userDetails: null,
                userProjects: null
            }
        },
        methods: {
            getUserProjects(userId) {
                var self = this;
                var url = window.appSettings.baseServiceUrl + 'Project/ProjectsByUser/' + userId;
                axios.get( url, {
                    headers: {
                        Authorization: 'Bearer ' + self.$store.getters.authToken
                    }
                })
                    .then(function (response) {
                        if (self.checkData(response.data) && self.checkData(response.data.UserProjects)) {
                            self.userProjects = response.data.UserProjects;
                        }
                    })
                    .catch(function (error) {
                        console.log(error);
                    });

            },            
            checkData(obj) {
                return (obj != null || obj != undefined);
            },
            isProjectAssigned() {
                return this.checkData(this.userProjects)  && (this.userProjects.length > 0)
            },
            logout() {
                this.$store.commit('changeUserDetails', null);
                this.$store.commit('changeAuthtoken', null);
                this.$router.push('/');
            }
        },
        mounted() {
            this.userDetails = this.$store.getters.userDetails;
            console.log(this.userDetails);
            this.getUserProjects(this.userDetails.EmpNo);
        }
    }
</script>