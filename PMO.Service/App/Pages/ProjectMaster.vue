<template>
    <div>
        <div class="row">
            <div class="col-sm-2">
                <nav class="navbar bg-light">
                    <ul class="navbar-nav">
                        <li class="nav-item">
                            <router-link to="/executive-dashboard/ProjectMaster/ProjectDashboard" class="nav-link">Project Dashboard</router-link>
                        </li>
                        <li class="nav-item">
                            <router-link to="/executive-dashboard/ProjectMaster/Stakeholders" class="nav-link">Stakeholders</router-link>
                        </li>
                        <li class="nav-item">
                            <router-link to="/executive-dashboard/ProjectMaster/Risk" class="nav-link">Risk</router-link>
                        </li>
                        <li class="nav-item">
                            <router-link to="/executive-dashboard/ProjectMaster/Milestones" class="nav-link">Milestones</router-link>
                        </li>
                        <li class="nav-item">
                            <router-link to="/executive-dashboard/ProjectMaster/MOM" class="nav-link">MOM</router-link>
                        </li>
                    </ul>
                </nav>
            </div>
            <div class="col-sm-10">
                <router-view></router-view>
            </div>
        </div>
    </div>
</template>
<script>
    export default {
        name: 'ProjectMaster',
        data() {
            return {
                message: ''
            }
        }
    }
</script>