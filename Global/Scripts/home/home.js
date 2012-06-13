$(document).ready(function () {
    GetSalesAmountToday();
    GetSalesAmountThisMonth();
    GetSalesAmountThisYear();
    GetOutstandingAmountToday();
    GetOutstandingAmountThisMonth();
    GetOutstandingAmountThisYear();
    $.ajax({
        type: 'GET',
        url: '/Home/MonitoringSalesByPeriode',
        dataType: 'json',
        success: function (data) {
            var sales = new Array();
            var salesAmount = new Array();
            for (var i = 0; i < data.length; i++) {
                sales.push([data[i].Date.toDefaultFormatDate(), data[i].Amount]);
                salesAmount.push("Rp " + data[i].Amount.toCurrency(2));
            }
            CreateGrafik(sales, salesAmount);
        }
    });

});

function GetSalesAmountToday() {
    $.ajax({
        type: 'GET',
        url: '/Home/SalesAmountToday',
        dataType: 'json',
        success: function (data) {
            $("#TotalRentalToday").text("Rp " + data.Total.toCurrency());
        }
    });
}

function GetSalesAmountThisMonth() {
    $.ajax({
        type: 'GET',
        url: '/Home/SalesAmountThisMonth',
        dataType: 'json',
        success: function (data) {
            $("#TotalRentalThisMonth").text("Rp " + data.Total.toCurrency());
        }
    });
}

function GetSalesAmountThisYear() {
    $.ajax({
        type: 'GET',
        url: '/Home/SalesAmountThisYear',
        dataType: 'json',
        success: function (data) {
            $("#TotalRentalThisYear").text("Rp " + data.Total.toCurrency());
        }
    });
}

function GetOutstandingAmountToday() {
    $.ajax({
        type: 'GET',
        url: '/Home/OutstandingAmountToday',
        dataType: 'json',
        success: function (data) {
            $("#TotalOutstandingToday").text("Rp " + data.Total.toCurrency());
        }
    });
}

function GetOutstandingAmountThisMonth() {
    $.ajax({
        type: 'GET',
        url: '/Home/OutstandingAmountThisMonth',
        dataType: 'json',
        success: function (data) {
            $("#TotalOutstandingThisMonth").text("Rp " + data.Total.toCurrency());
        }
    });
}

function GetOutstandingAmountThisYear() {
    $.ajax({
        type: 'GET',
        url: '/Home/OutstandingAmountThisYear',
        dataType: 'json',
        success: function (data) {
            $("#TotalOutstandingThisYear").text("Rp " + data.Total.toCurrency());
        }
    });
}

function CreateGrafik(sales, salesAmount){
    chart = new Highcharts.Chart({
        chart: {
            renderTo: 'grafik-container',
            backgroundColor: '#FFF356',
            borderRadius: 15,
            borderColor: '#91E842',
            borderWidth: 1,
            plotBackgroundColor: null,
            plotShadow: false,
            plotBorderWidth: 0
        },
        credits: {
            enabled: false
        },
        xAxis: {
            type: 'datetime',
            tickInterval: 7 * 24 * 3600 * 1000, // one week
            tickWidth: 0,
            gridLineWidth: 1,
            labels: {
                align: 'left',
                x: 3,
                y: 3
            }
        },
        title: { text: "" },
        yAxis: {
            startOnTick: false,
            lineColor: 'black',
            gridLineColor: 'white',
            title: {
                text: 'Total Penyewaan (Juta)',
                style: { color: '#000', fontWeight: 'normal' }
            },
            plotLines: [{
                value: 0,
                width: 1
            }],
            labels: {
                formatter: function () {
                    return '';
                }
            }
        },
        tooltip: {
            formatter: function () {
                return '<b>' + this.series.name + '</b><br/>' +
								sales[this.x][0] +'<br/>' + salesAmount[this.x];
            }
        },
        legend: {
            layout: 'vertical',
            align: 'center',
            verticalAlign: 'top',
            x: 0,
            y: 20,
            borderWidth: 0
        },
        series: [{
            name: 'Total Penyewaan',
            data: sales,
            color: '#FFA63A',
            marker: {
                radius: 3
            },
            style: { color: '#000', fontWeight: 'normal' }
        }]
    });
}