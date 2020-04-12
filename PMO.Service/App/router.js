import Vue from 'vue';
import VueRouter from 'vue-router';
import SampleLineChart from './Pages/SampleLineChart.vue';
import Landing from './Pages/Landing.vue';
import Login from './Pages/Login.vue';
import ExecutiveDashboard from './Pages/ExecutiveDashboard.vue';
import AllProjects from './Pages/AllProjects.vue';
import ProjectMaster from './Pages/ProjectMaster.vue';
import ProjectDashboard from './Pages/Project/ProjectDashboard.vue';
import Stakeholders from './Pages/Project/Stakeholders.vue';
import Milestones from './Pages/Project/Milestones.vue';
import Risk from './Pages/Project/Risk.vue';
import MOM from './Pages/Project/MOM.vue';

const routes = [
    {
        path: '/',
        component: Login
    },
    {
        path: '/executive-dashboard',
        component: ExecutiveDashboard,
        children: [
            {
                path: 'landing',
                component: Landing
            },
            {
                path: 'chart',
                component: SampleLineChart
            },            
            {
                path: 'AllProjects',
                component: AllProjects
            },
            {
                path: 'ProjectMaster',
                component: ProjectMaster,
                children: [
                    {
                        path: 'ProjectDashboard',
                        component: ProjectDashboard
                    },
                    {
                        path: 'Stakeholders',
                        component: Stakeholders
                    },
                    {
                        path: 'Milestones',
                        component: Milestones
                    },
                    {
                        path: 'Risk',
                        component: Risk
                    },
                    {
                        path: 'MOM',
                        component: MOM
                    }
                ]
            }
            
        ]
    }
]
Vue.use(VueRouter);
const router = new VueRouter({ mode: 'history', routes: routes });
export default router;