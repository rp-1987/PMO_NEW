<template>

    

    <div>
        <div class="card-deck">
            <div class="card">
                <div class="card-header bg-primary text-white text-center">
                    Last 3 Months
                </div>
                <div class="card-body  text-primary text-center">
                    <h1>&#8377; 1345</h1>
                </div>
            </div>
            <div class="card">
                <div class="card-header bg-warning text-white text-center">
                    Last 3 Months
                </div>
                <div class="card-body text-warning text-center">
                    <h1>&#8377; 1345</h1>
                </div>
            </div>
            <div class="card">
                <div class="card-header bg-success text-white text-center">
                    This Year
                </div>
                <div class="card-body text-success text-center">
                    <h1>&#8377; 1345</h1>
                </div>
            </div>
            <div class="card">
                <div class="card-header bg-danger text-white text-center">
                    Till Date
                </div>
                <div class="card-body text-danger text-center">
                    <h1>&#8377; 1345</h1>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col">
                <daywise-expense :chartdata="daywiseChartData" :chartoptions="daywiseChartOptions"></daywise-expense>
            </div>
            <div class="col">
                <categorywise-expense :chartdata="categorywiseChartData" :chartoptions="categorywiseChartOptions"></categorywise-expense>
            </div>

        </div>

    </div>
</template>

<script>
    import DaywiseExpense from './Charts/DaywiseExpense.vue';
    import CategorywiseExpense from './Charts/CategorywiseExpense.vue';
    export default {
        name: 'Landing',
        components: {
            'daywise-expense': DaywiseExpense,
            'categorywise-expense': CategorywiseExpense
        },
        data() {
            return {
                message: 'Landing Page',
                daywiseTransactions: null,
                categorywiseData: null,
                daywiseChartData: null,
                daywiseChartOptions: null,
                categorywiseChartData: null,
                categorywiseChartOptions: null,
                pieChartColors: []
            }
        },
        methods: {
            getChartData() {
                this.getDaywiseTransactions();
                this.getCategorywiseData();
            },
            getDaywiseTransactions() {
                this.daywiseTransactions = [
                    { transactionDate: '21/09/2019', amount: 123.00 },
                    { transactionDate: '22/09/2019', amount: 45.00 },
                    { transactionDate: '23/09/2019', amount: 27.00 },
                    { transactionDate: '24/09/2019', amount: 250.00 },
                    { transactionDate: '25/09/2019', amount: 1100.00 },
                    { transactionDate: '26/09/2019', amount: 216.00 },
                    { transactionDate: '27/09/2019', amount: 602.00 },
                ]
            },
            getCategorywiseData() {
                this.categorywiseData = [
                    { category: 'Vacation', amount: 81468.00 },
                    { category: 'Home Office', amount: 17450.00 },
                    { category: 'Household', amount: 6280.00 },
                    { category: 'Food', amount: 5040.00 },
                    { category: 'Other', amount: 1384.00 }
                ];
                for (var i in this.categorywiseData)
                {
                    this.pieChartColors.push(this.getRandomColor());
                }
            },
            prepareChartData() {
                this.prepareDaywiseChartData();
                this.prepareCategorywiseChartData();
            },
            prepareDaywiseChartData() {
                this.daywiseChartData = {
                    labels: this.daywiseTransactions.map(function (obj) { return obj.transactionDate; }),
                    datasets: [
                        {
                            label: 'Last 7 days',
                            backgroundColor: '#2e5090',
                            data: this.daywiseTransactions.map(function (obj) { return obj.amount; })
                        }
                    ]
                };
                this.daywiseChartOptions = {
                    responsive: true,
                    maintainAspectRatio: false
                };
            },
            prepareCategorywiseChartData() {
                this.categorywiseChartData = {
                    labels: this.categorywiseData.map(function (obj) { return obj.category; }),
                    datasets: [
                        {
                            label: 'Expense By Category',
                            backgroundColor: this.pieChartColors, 
                            data: this.categorywiseData.map(function (obj) { return obj.amount; })
                        }
                    ]
                };
                this.categorywiseChartOptions = {
                    responsive: true,
                    maintainAspectRatio: false
                };
            },
            getRandomColor() {
                var r = 51;
                var b = Math.floor(Math.random() * 255);
                var g = Math.floor(Math.random() * 255);
                return "rgb(" + r.toString() + "," + b.toString() + "," + g.toString() + ")";
            }
        },
        created() {
            console.log("Mounted of Parent fired");
            this.getChartData();
            this.prepareChartData();
        }
    }
</script>