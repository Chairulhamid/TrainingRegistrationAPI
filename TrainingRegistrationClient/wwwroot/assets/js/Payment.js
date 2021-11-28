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
                    return `<p class="bg-info text-white">${row.status}</p>`;
                }
            },
            {
                data: null,
                render: function (data, type, row) {
                    return `<td scope=" row">  <a class="btn btn-primary btn-sm text-light" data-url=""  onclick="getDetailPayment('${row.paymentId}')" title="Update"><i class="fa fa-info-circle"></i> </a></td>
                               `;
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
                    if (row['status'] == "Verified") {
                        /*     return row['phone'].replace('0', '+62');*/
                        return `<p class="bg-primary text-white">${row.status}</p>`;
                    } else {

                        return `<p class="bg-warning text-white">${row.status}</p>`;
                    }
                }
            },
            {
                data: null,
                render: function (data, type, row) {
                    return `<td scope=" row">  <a class="btn btn-warning btn-sm text-light" data-url=""  onclick="getDetailPayment1('${row.paymentId}')" title="Detail"><i class="fa fa-info-circle"></i> </a></td>
                                  <td scope=" row"> <button type="button" class="btn btn-danger btn-sm text-light"  onclick="DeletePayment('${row.paymentId}')" title="Delete"> <i class="fas fa-trash-alt"></i></button></td>`;
                }
            }
        ],
    });
});

function getDetailPayment(paymentId) {
    console.log(paymentId)

    $.ajax({
        url: "/Payments/GetPayStatusId/" + paymentId,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            console.log(result);
            /*var tanggal = result[0].paymentDate.substr(0, 10);*/
            $('#paymentId').val(result[0].paymentId);
            $('#userId').val(result[0].userId);
            $('#firstName').val(result[0].firstName);
            $('#lastName').val(result[0].lastName);
            $('#email').val(result[0].email);
            $('#courseName').val(result[0].courseName);
            $('#courseFee').val(result[0].courseFee);
            $('#bankAccount').val(result[0].bankAccount);
            $('#registeredCourseId').val(result[0].registeredCourseId);
            $('#totalPayment').val(result[0].totalPayment);
            $('#paymentDate').val(result[0].paymentDate);
            $('#status').val(result[0].status);
            $('#modalPayment').modal('show');
            $('#paymentId').prop('disabled', true);;
            $('#userId').prop('disabled', true);;
            $('#firstName').prop('disabled', true);;
            $('#lastName').prop('disabled', true);;
            $('#status').prop('disabled', true);;
            $('#email').prop('disabled', true);;
            $('#courseName').prop('disabled', true);;
            $('#courseFee').prop('disabled', true);;
            $('#bankAccount').prop('disabled', true);;
            $('#totalPayment').prop('disabled', true);;
            $('#paymentDate').prop('disabled', true);;
            //$('#status').prop('disabled', true);;

        
        },
        error: function (errormessage) {
            /*alert(errormessage.responseText);*/
            swal.fire({
                title: "Failed",
                text: "Data not found",
                icon: "error"
            })
        }
    });
    return false;
}
function getDetailPayment1(paymentId) {
    console.log(paymentId)
    $.ajax({
        url: "/Payments/GetPayStatusId/" + paymentId,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            console.log(result);
            /*var tanggal = result[0].paymentDate.substr(0, 10);*/
            $('#paymentId').val(result[0].paymentId);
            $('#userId').val(result[0].userId);
            $('#firstName').val(result[0].firstName);
            $('#lastName').val(result[0].lastName);
            $('#email').val(result[0].email);
            $('#courseName').val(result[0].courseName);
            $('#courseFee').val(result[0].courseFee);
            $('#bankAccount').val(result[0].bankAccount);
            $('#registeredCourseId').val(result[0].registeredCourseId);
            $('#totalPayment').val(result[0].totalPayment);
            $('#paymentDate').val(result[0].paymentDate);
            $('#status').val(result[0].status);
            $('#modalPayment').modal('show');
            $('#paymentId').prop('disabled', true);;
            $('#userId').prop('disabled', true);;
            $('#firstName').prop('disabled', true);;
            $('#lastName').prop('disabled', true);;
            $('#status').prop('disabled', true);;
            $('#email').prop('disabled', true);;
            $('#courseName').prop('disabled', true);;
            $('#courseFee').prop('disabled', true);;
            $('#bankAccount').prop('disabled', true);;
            $('#totalPayment').prop('disabled', true);;
            $('#paymentDate').prop('disabled', true);;
            $('#paymentAcc').hide();
            $('#paymentDc').hide();
            //$('#status').prop('disabled', true);;


        },
        error: function (errormessage) {
            /*alert(errormessage.responseText);*/
            swal.fire({
                title: "Failed",
                text: "Data not found",
                icon: "error"
            })
        }
    });
    return false;
}

function ChangeStatus() {
    var PaymentId = $('#paymentId').val();
    var obj = new Object();
    obj.PaymentId = $('#paymentId').val();
    obj.PaymentDate = $('#paymentDate').val();
    obj.BankAccount = $('#bankAccount').val();
    obj.TotalPayment = $('#totalPayment').val();
    obj.Status = 2;
    obj.RegisteredCourseId = $('#registeredCourseId').val();
  
    console.log(obj);
    $.ajax({
        url: "/Payments/Put/" + PaymentId,
        type: "PUT",
        data: { id: PaymentId, entity: obj },
       
    }).done((result) => {
        Swal.fire({
            icon: 'success',
            title: 'Success!',
            text: 'Data has been updated!'
        }).then(function () {
            window.location = "https://localhost:44344/auth/Payment";
        });
    }).fail((error) => {
        Swal.fire({
            icon: 'error',
            title: 'Oops..',
            text: 'Failed to update data'
        });
    });

}
function Decline() {
    var PaymentId = $('#paymentId').val();
    var obj = new Object();
    obj.PaymentId = $('#paymentId').val();
    obj.PaymentDate = $('#paymentDate').val();
    obj.BankAccount = $('#bankAccount').val();
    obj.TotalPayment = $('#totalPayment').val();
    obj.Status = 1;
    obj.RegisteredCourseId = $('#registeredCourseId').val();

    console.log(obj);
    $.ajax({
        url: "/Payments/Put/" + PaymentId,
        type: "PUT",
        data: { id: PaymentId, entity: obj },

    }).done((result) => {
        Swal.fire({
            icon: 'success',
            title: 'Success!',
            text: 'Data has been updated!'
        }).then(function () {
            window.location = "https://localhost:44344/auth/Payment";
        });
    }).fail((error) => {
        Swal.fire({
            icon: 'error',
            title: 'Oops..',
            text: 'Failed to update data'
        });
    });

}
function DeletePayment(id) {
    console.log(id);
    Swal.fire({
        title: 'Are you sure want to delete this Payment?',
        text: "you won't be able to revert this!",
        showCancelButton: true,
        confirmButtonColor: '#d33',
        cancelButtonColor: '#3085d6',
        confirmButtonText: 'Yes, Delete it!'
    })
        .then((willDelete) => {
            if (willDelete) {
                $.ajax({
                    url: "/Payments/Delete/" + id,
                    type: "Delete",
                    success: function (result) {
                        mytable.ajax.reload();
                        return Swal.fire(
                            'Delete Successfull',
                            'Course Data Deleted!',
                            'success',
                        ).then(function () {
                            window.location = "https://localhost:44344/auth/Payment";
                        });
                    },
                    error: function (errormessage) {
                        alert(errormessage.responseText);
                        return Swal.fire({
                            icon: 'error',
                            title: 'Oops...',
                            text: 'Delete not successful',
                        });
                    }
                });
            } else {
                swal("Data Gagal Dihapus!");
            }
        });
}


