<script>

    import { Bar } from 'vue-chartjs';

    export default {
        name: 'DaywiseExpense',
        extends: Bar,
        props: {
            chartdata: {
                type: Object,
                default: null
            },
            chartoptions: {
                type: Object,
                default: null
            }
        },
        mounted() {
            console.log("Mounted of Child fired");
            this.renderChart(this.chartdata, this.chartoptions);
        }
    }

</script>