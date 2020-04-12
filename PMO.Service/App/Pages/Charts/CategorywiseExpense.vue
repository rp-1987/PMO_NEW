<script>

    import { Pie } from 'vue-chartjs';

    export default {
        name: 'CategorywiseExpense',
        extends: Pie,
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
            this.renderChart(this.chartdata, this.chartoptions);
        }
    }

</script>