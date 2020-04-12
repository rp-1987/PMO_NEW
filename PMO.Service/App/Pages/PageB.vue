<template>
    <div class="bg-success">
        Page B - <strong>{{message}}</strong>
    </div>
</template>
<script>
    export default {
        name: 'PageA',
        data() {
            return {
                message: 'Data from Page B'
            };
        }
    };
</script>