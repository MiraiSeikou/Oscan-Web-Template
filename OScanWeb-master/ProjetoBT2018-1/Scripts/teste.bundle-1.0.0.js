//$(document).ready(function () {
//    google.charts.load('current', {
//        'packages': ['corechart']
//    });

//    google.charts.setOnLoadCallback(drawChart);

//    function drawChart() {

//        var data = google.visualization.arrayToDataTable([
//            ['Effort', 'clock1'],
//            ['My all1', 100],
//            ['My uso', 30]
//        ]);

//        var options = {
//            pieHole: 0.5,
//            pieSliceTextStyle: {
//                color: 'black',
//            },
//            legend: 'none'
//        };

//        setInterval(function () {
//            data.setValue(0, 1, 40 + Math.round(60 * Math.random()));
//            chart.draw(data, options);
//        }, 1000);

//        for (i = 0; i < 5; i++) {
//            $('.processor').append('<div class="processor" style="width: 900px; height: 500px;"></div>')

//            var chart = new google.visualization.PieChart($('processor').last()[0]);
//            chart.draw(data, options);

//        }
//    }
//}

