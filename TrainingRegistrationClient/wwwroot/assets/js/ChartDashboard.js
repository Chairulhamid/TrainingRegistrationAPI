//UNTUK ROLE
$.ajax({
    url: "https://localhost:44309/API/Employees/CountRole",
    success: function (result) {
        var dataRole = [];
        var jenisRole = [];
        $.each(result.result, function (key, val) {
            dataRole.push(val.value);
            if (val.role_Id === 3) {
                jenisRole.push("Director");
            } else if (val.role_Id === 5) {
                jenisRole.push("Manager");
            }
            else {
                jenisRole.push("Employee");
            }
        });
        var options = {
            chart: {
                type: 'bar',
            },

            series: [{

                data: dataRole
            }],
            xaxis: {
                categories: jenisRole
            }
        }
        var chart = new ApexCharts(document.querySelector("#bar"), options);

        chart.render();
    }
});