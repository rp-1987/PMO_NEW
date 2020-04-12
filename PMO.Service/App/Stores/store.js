import Vue from 'vue';
import Vuex from 'vuex';

Vue.use(Vuex);

export const store = new Vuex.Store({
    state: {
        authToken: '',
        authMessage:'',
        userDetails: {}
    },
    mutations: {
        changeAuthtoken(state, authToken) {
            state.authToken = authToken;
        },
        changeAuthMessage(state, authMessage) {
            state.authMessage = authMessage;
        },
        changeUserDetails(state, userDetails) {           
            state.userDetails = userDetails;
        }
    },
    getters: {        
        authToken(state) {
            return state.authToken;
        },
        authMessage(state) {
            return state.authMessage;
        },
        userDetails(state) {            
            return state.userDetails;
        }
    }
})