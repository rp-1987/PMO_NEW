<template>


    <div id="allProjects">

        <div class="card-deck">
            <div class="card">
                <div class="card-header bg-secondary text-white">
                    Filter By PSC
                </div>
                <div class="card-body">
                    <div class="form-check-inline">
                        <label class="form-check-label">
                            <input type="radio" class="form-check-input" v-on:change="filterProjects()" value="NA" name="psc" v-model="psc">All
                        </label>
                    </div>
                    <div class="form-check-inline">
                        <label class="form-check-label">
                            <input type="radio" class="form-check-input" v-on:change="filterProjects()" value="1" name="psc" v-model="psc">PSC
                        </label>
                    </div>
                    <div class="form-check-inline">
                        <label class="form-check-label">
                            <input type="radio" class="form-check-input" v-on:change="filterProjects()" value="0" name="psc" v-model="psc">Non-PSC
                        </label>
                    </div>
                </div>
            </div>

            <div class="card">
                <div class="card-header bg-secondary text-white">
                    Filter By Importance
                </div>
                <div class="card-body">
                    <div class="form-check-inline">
                        <label class="form-check-label">
                            <input type="radio" class="form-check-input" v-on:change="filterProjects()" name="importance" value="NA" v-model="importance">All
                        </label>
                    </div>
                    <div class="form-check-inline">
                        <label class="form-check-label">
                            <input type="radio" class="form-check-input" v-on:change="filterProjects()" name="importance" value="H" v-model="importance">High
                        </label>
                    </div>
                    <div class="form-check-inline">
                        <label class="form-check-label">
                            <input type="radio" class="form-check-input" v-on:change="filterProjects()" name="importance" value="M" v-model="importance">Medium
                        </label>
                    </div>
                    <div class="form-check-inline">
                        <label class="form-check-label">
                            <input type="radio" class="form-check-input" v-on:change="filterProjects()" name="importance" value="L" v-model="importance">Low
                        </label>
                    </div>
                </div>
            </div>
        </div>





        <br />

        <div class="card-deck">
            <div class="card">
                <div class="card-header bg-danger text-white">
                    Projects in Red and Amber
                </div>
                <div class="card-body">
                    <table id="projectStatus" v-if="projectsRedAmber.length > 0" class="table table-bordered table-sm">
                        <thead class="thead-light">
                            <tr>
                                <th>Project</th>
                                <th>Status</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr v-for="(item, index) in projectsRedAmber">
                                <td>{{item.ProjectLongName}}</td>
                                <td>{{item.StatusSummary}}</td>
                            </tr>
                        </tbody>
                    </table>
                    <span v-else>
                        No Projects to Show in Red or Amber
                    </span>
                </div>
            </div>

            <div class="card">
                <div class="card-header bg-warning text-white">
                    Projects by Status
                </div>
                <div class="card-body">
                    <div v-if="checkData(pieChartData) && filteredProjects.length > 0">
                        <pie-chart :chartdata="pieChartData" :chartoptions="pieChartOptions" :key="pieChartKey">

                        </pie-chart>
                    </div>
                    <div v-else>
                        No Chart to show
                    </div>
                </div>
            </div>
        </div>


        <br />

        <div class="card">
            <div class="card-header bg-success text-white">
                Project Status
            </div>
            <div class="card-body">
                <table v-if="filteredProjects.length > 0" class="table table-bordered project-table table-sm">
                    <thead class="thead-light">
                        <tr>
                            <th>Project</th>
                            <th>Cost</th>
                            <th>Time</th>
                            <th>Resource</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="(item, index) in filteredProjects">
                            <td>{{item.ProjectLongName}}</td>
                            <td>
                                <svg height="40" width="40">
                                    <circle cx="20" cy="20" r="10" v-bind:stroke="item.CostStatus" stroke-width="3" v-bind:fill="item.CostStatus" />
                                </svg>
                            </td>
                            <td>
                                <svg height="40" width="40">
                                    <circle cx="20" cy="20" r="10" v-bind:stroke="item.TimeStatus" stroke-width="3" v-bind:fill="item.TimeStatus" />
                                </svg>
                            </td>
                            <td>
                                <svg height="40" width="40">
                                    <circle cx="20" cy="20" r="10" v-bind:stroke="item.ResourceStatus" stroke-width="3" v-bind:fill="item.ResourceStatus" />
                                </svg>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <span v-else>
                    No Projects to Show
                </span>
            </div>
        </div>
    </div>

</template>
<script>
    import axios from 'axios';
    import PieChart from './Charts/PieChart.vue';

    export default {
        name: 'AllProjects',
        components: {
            'pie-chart': PieChart
        },
        data() {
            return {
                importance: 'NA',
                psc: 'NA',
                projects: null,
                filteredProjects: null,
                pieChartData: null,
                pieChartOptions: null,
                projectsRedAmber: null,
                pieChartKey: 0
            }
        },
        methods: {
            getAllProjects() {
                var self = this;
                var url = window.appSettings.baseServiceUrl + 'Project/GetAllProjects/';
                axios.get(url, {
                    headers: {
                        Authorization: 'Bearer ' + self.$store.getters.authToken
                    }
                })
                    .then(function (response) {
                        if (self.checkData(response.data)) {
                            self.projects = response.data;
                            self.filteredProjects = response.data;
                            self.prepareChartData();
                            self.setProjectsRedAmber();

                        }
                    })
                    .catch(function (error) {
                        console.log(error);
                    });

            },
            checkData(obj) {
                return (obj != null || obj != undefined);
            },
            filterProjects() {
                var self = this;
                self.filteredProjects = self.projects;
                if (this.psc != 'NA') {
                    self.filteredProjects = self.projects.filter(function (obj) {
                        return obj.IsPSC == self.psc == "0" ? false : true;
                    })
                }

                if (this.importance != 'NA') {
                    this.filteredProjects = this.filteredProjects.filter(function (obj) {
                        return obj.ProjectImportance == self.importance;
                    })
                }

                this.prepareChartData();
                this.setProjectsRedAmber();
            },
            setProjectsRedAmber() {
                this.projectsRedAmber = this.filteredProjects.filter(function (obj) {
                    return obj.TimeStatus == "red" || obj.TimeStatus == "yellow";
                })
            },
            prepareChartData() {
                this.pieChartKey += 1;
                var pieChartAgg = this.filteredProjects.reduce(function (a, c) {
                    a[c.TimeStatus] = a[c.TimeStatus] + 1 || 1;
                    return a;
                }, {})

                this.pieChartData = {
                    labels: Object.getOwnPropertyNames(pieChartAgg),
                    datasets: [
                        {
                            label: 'Projects by Status',
                            backgroundColor: Object.getOwnPropertyNames(pieChartAgg),
                            data: Object.values(pieChartAgg)
                        }
                    ]
                };
                this.pieChartOptions = {
                    responsive: true,
                    maintainAspectRatio: false
                };
            }
        },
        mounted() {
            this.getAllProjects();
        }
    }
</script>
<style scoped>

    .project-table {
        height: 60vh;
        overflow-y: scroll;
    }
</style>