$.ajax({
    type: "GET",
    url: "https://localhost:44307/API/Employees/CountEmp",
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    success: function (result) {
        console.log(result.result[0].value)
        $("#employeeVal").html(result.result[0].value);
    }, 
});
$.ajax({
    type: "GET",
    url: "https://localhost:44307/API/Users/CountUser",
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    success: function (result) {
        console.log(result.result[0].value)
        $("#userVal").html(result.result[0].value);
    },
});
/*AJax Untuk Charts Status Course*/
$.ajax({
    url: "https://localhost:44307/API/Courses/CountStatusCourse",
    success: function (result) {
        var series = [];
        var label = [];
        $.each(result.result, function (key, val) {
            console.log(val)
            series.push(val.value);
            if (val.statusCourse === 0) {
                label.push("WaitingForApproval");
            } else if (val.statusCourse === 1) {
                label.push("Approved");
            } else {
                label.push("Declined");
            }
        });
        var options = {
            chart: {
                type: 'donut'
            },
            series: series,
            labels: label
        }
        var chart = new ApexCharts(document.querySelector("#chartCourse"), options);
        chart.render();
    }
});

/*AJax Untuk Charts Paymnet*/
$.ajax({
    url: "https://localhost:44307/API/Payments/CountStatusPayment",
    success: function (result) {
        var series = [];
        var label = [];
        $.each(result.result, function (key, val) {
            console.log(val)
            series.push(val.value);
            if (val.status === 0) {
                label.push("NotPaid");
            } else if (val.status === 1) {
                label.push("Declined");
            } else {
                label.push("Verified");
            }
        });
        var options = {
            chart: {
                type: 'pie'
            },
            series: series,
            labels: label
        }
        var chart = new ApexCharts(document.querySelector("#chartPayment"), options);
        chart.render();
    }
});