<template>
    <div class="container">
        <router-view></router-view>
    </div>
</template>
<script>
    export default {
        data() {
            return {
                message: 'Message from App.vue',
            };
        }
    };
</script>