var mytable = null;
$(document).ready(function () {
    mytable = $("#tablePaymentNotPaid").DataTable({
        //'ordering': false,
        'ajax': {
            'url': "https://localhost:44307/API/Payments/GetPayStatus",
            'dataSrc': "",
        },
        'columns': [
            {
                "data": "id",
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            {
                "data": "paymentId"
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    return row['userId'];
                }
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    return row['firstName'] + " " + row['lastName'];
                }
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    return row['email'];
                }
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    return row['courseName'];
                },
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    return row['totalPayment'];
                }
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    return row['bankAccount'];
                }
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    return row['paymentDate'];
                }
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    return row['status'];
                }
            },
            {
                data: null,
                render: function (data, type, row) {
                    return `<td scope=" row">  <a class="btn btn-warning btn-sm text-light" data-url=""  onclick="getDetailPayment('${row.paymentId}')" title="Detail"><i class="fa fa-info-circle"></i> </a></td>
                                    <td scope=" row">  <a class="btn btn-primary btn-sm text-light" data-url=""  onclick="getCourse('${row.paymentId}')"  title="Update"><i class="far fa-edit"></i></a></td>
                                  <td scope=" row"> <button type="button" class="btn btn-danger btn-sm text-light"  onclick="DeleteCourse('${row.paymentId}')" title="Delete"> <i class="fas fa-trash-alt"></i></button></td>`;
                }
            }
        ],
    });
});

var mytable1 = null;
$(document).ready(function () {
    mytable1 = $("#tablePayment1").DataTable({
        //'ordering': false,
        'ajax': {
            'url': "https://localhost:44307/API/Payments/GetPayALL",
            'dataSrc': "",
        },
        'columns': [
            {
                "data": "id",
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            {
                "data": "paymentId"
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    return row['userId'];
                }
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    return row['firstName'] + " " + row['lastName'];
                }
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    return row['email'];
                }
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    return row['courseName'];
                },
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    return row['totalPayment'];
                }
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    return row['bankAccount'];
                }
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    return row['paymentDate'];
                }
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    return row['status'];
                }
            },
            {
                data: null,
                render: function (data, type, row) {
                    return `<td scope=" row">  <a class="btn btn-warning btn-sm text-light" data-url=""  onclick="getDetailCourse('${row.userId}')" title="Detail"><i class="fa fa-info-circle"></i> </a></td>
                                    <td scope=" row">  <a class="btn btn-primary btn-sm text-light" data-url=""  onclick="getCourse('${row.paymentId}')"  title="Update"><i class="far fa-edit"></i></a></td>
                                  <td scope=" row"> <button type="button" class="btn btn-danger btn-sm text-light"  onclick="DeleteCourse('${row.paymentId}')" title="Delete"> <i class="fas fa-trash-alt"></i></button></td>`;
                }
            }
        ],
    });
});

function getDetailPayment(paymentId) {
    console.log(paymentId)
    $.ajax({
        url: "/Payments/GetIdPayStatus/" + paymentId,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            console.log(result);
            var tanggal = result[0].paymentDate.substr(0, 10);
            $('#paymentId').val(result[0].paymentId);
            $('#userId').val(result[0].userId);
            $('#firstName').val(result[0].firstName);
            $('#lastName').val(result[0].lastName);
            $('#email').val(result[0].email);
            $('#courseName').val(result[0].courseName);
            $('#courseFee').val(result[0].courseFee);
            $('#bankAccount').val(result[0].bankAccount);
            $('#totalPayment').val(result[0].totalPayment);
            $('#paymentDate').val(result[0].paymentDate);
            $('#status').val(result[0].status);
            $('#modalPayment').modal('show');
            $('#paymentId').prop('disabled', true);;
            $('#userId').prop('disabled', true);;
            $('#firstName').prop('disabled', true);;
            $('#lastName').prop('disabled', true);;
            $('#email').prop('disabled', true);;
            $('#courseName').prop('disabled', true);;
            $('#courseFee').prop('disabled', true);;
            $('#bankAccount').prop('disabled', true);;
            $('#totalPayment').prop('disabled', true);;
            $('#paymentDate').prop('disabled', true);;
        },
        error: function (errormessage) {
            /*alert(errormessage.responseText);*/
            swal.fire({
                title: "Failed",
                text: "Data not found",
                icon: "error"
            }).then(function () {
                window.location = "https://localhost:44344/auth/payment";
            });
        }
    });
    return false;
}