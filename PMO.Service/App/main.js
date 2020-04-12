import 'bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import './custom.css';
import Vue from 'vue';
import App from './App.vue';
import Router from './router';
import { store } from './Stores/store';

new Vue({
    el: '#app',
    store,
    template: '<App/>',
    components: { App },
    router: Router
});