$(document).ready(function () {
    console.log("ready!");
});


window.onload = function () {

    var url = '@Url.Action("GetMonthlySpendingByYear")';
    $.get(url,
        function (data) {
            console.log(data);

            var ctx = document.getElementById('myChart');
            var myChart = new Chart(ctx, {
                type: 'line',
                data: {
                    labels: data.monthNames,
                    datasets: [{
                        label: 'Total Spending By Month (in USD$)',
                        data: data.monthlySpending,
                        backgroundColor: [
                            'rgba(54, 162, 235, 0.2)'
                        ],
                        borderColor: [
                            'rgba(54, 162, 235, 1)'
                        ]
                    }]



                },
                options: {
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: true
                            }
                        }]

                    }
                }
            });
        });



};