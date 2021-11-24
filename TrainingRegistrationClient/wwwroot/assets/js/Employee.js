$(document).ready(function () {
    $('#tableEmployee').DataTable({
        dom: 'Bfrtip',
        buttons: [
            {
                extend: 'excel',
                title: 'Excelllll',
                className: ' text-light far fa-file-excel bg-secondary',
                text: ' Excel',
                exportOptions: {
                    columns: [1, 2, 3, 4, 5]
                }
            },
            {
                extend: 'pdf',
                className: ' text-light far fa-file-pdf bg-success',
                text: ' PDF',

                exportOptions: {
                    columns: [1, 2, 3, 4, 5]
                }
            },
            {
                extend: 'print',
                className: ' text-light fas fa-download bg-info',
                text: ' Print',
                exportOptions: {
                    columns: [1, 2, 3, 4, 5]
                }
            },
            'colvis',

        ],
        columnDefs: [{
            targets: [0],
            visible: false
        }],
        'ajax': {
            'url': "/Employees/GetAll",
            'order': [[0, 'asc']],
            'dataSrc': ''
        },

        'columns': [
            {
                data: 'no', name: 'id', render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            { "data": "employeeId" },
            {
                "data": "",
                'render': function (data, type, row, meta) {
                    return row['firstName'] + " " + row['lastName'];

                }
            },
            { "data": "email" },
            {
                "data": "phone",
                render: function (data, type, row, meta) {
                    if (row['phone'].search(0) == 0) {
                        return row['phone'].replace('0', '+62');
                    } else {
                        return row['phone'];
                    }
                }
            },
            { "data": "address" },
            {
                "data": "gender",
                'render': function (data, type, row, meta) {
                    if (row['gender'] == 0) {
                        return "Male"
                    }
                    return "Female"
                }
            },
            { "data": "birthDate" },
            { "data": "hireDate" },
            {
                "data": "",
                'render': function (data, type, row, meta) {
                    return `<td scope=" row">  <a class="btn btn-warning btn-sm text-light" data-url=""  onclick="getDetailEmp('${row.employeeId}')" title="Detail"><i class="fa fa-info-circle"></i> </a></td>
                                    <td scope=" row">  <a class="btn btn-primary btn-sm text-light" data-url=""  onclick="getEmp('${row.employeeId}')"  title="Update"><i class="far fa-edit"></i></a></td>
                                  <td scope=" row"> <button type="button" class="btn btn-danger btn-sm text-light"  onclick="DeleleEmp('${row.employeeId}')" title="Delete"> <i class="fas fa-trash-alt"></i></button></td>`;
                }
            }
        ]
    });
    $(function () {
        $("form[name='nameModal']").validate({
            rules: {
                nik: {
                    required: true
                },
                firstName: {
                    required: true
                },
                lastName: {
                    required: true
                },
                phone: {
                    required: true,
                    minlength: 10,
                    maxlength: 13
                },
                birthDate: {
                    required: true
                },
                salary: {
                    required: true,
                    number: true
                },
                email: {
                    required: true,
                    email: true
                },
                password: {
                    required: true,
                    minlength: 8
                },
                gender: {
                    required: true
                },
                universiry_id: {
                    required: true
                },
                degree: {
                    required: true
                },
                gpa: {
                    required: true
                },
                role_id: {
                    required: true
                }
            },
            messages: {
                nik: {
                    required: "Please enter your NIK"
                },
                firstName: {
                    required: "Please enter your first name"
                },
                lastName: {
                    required: "Please enter your last name"
                },
                phone: {
                    required: "Please enter your phone number",
                    minlength: "Phone number should be at least 10 characters",
                    maxlength: "Phone number can't be longer than 13 characters"
                },
                birthDate: {
                    required: "Please enter your birthdate"
                },
                salary: {
                    required: "Please enter your salary"
                },
                email: {
                    required: "Please enter your email",
                    email: "The email should be in the format: abc@domain.tld"
                },
                gender: {
                    required: "Please choose your gender"
                },
                password: {
                    required: "Please enter your password",
                    minlength: "Password should be at least 8 characters",
                },
                degree: {
                    required: "Please choose your degree"
                },
                gpa: {
                    required: "Please enter your GPA"
                },
                universiry_id: {
                    required: "Please choose your university"
                },
                role_id: {
                    required: "Please choose your role"
                }
            }
        });
        $('#btnAddEmployee').click(function (e) {
            e.preventDefault();
            if ($('#formValidation').valid() == true) {

                InsertData();
            }
        });
        $('#btnUpdateEmployee').click(function (e) {
            e.preventDefault();
            if ($('#formValidation').valid() == true) {
                UpdateEmp();
            }
        });
    });
});

function InsertData() {
    var obj = new Object();
    obj.FirstName = $('#firstName').val();
    obj.LastName = $('#lastName').val();
    obj.Email = $('#email').val();
    obj.Phone = $('#phone').val();
    obj.Gender = $('#gender').val();
    obj.Address = $('#address').val();
    obj.BirthDate = $('#birthDate').val();
    obj.password = $('#password').val();
    obj.HireDate = $('#hireDate').val();
    obj.RoleId = $('#role_id').val();
    console.log(obj);
    $.ajax({
        url: "/Employees/RegisterEmp",
        'type': 'POST',
        'data': { entity: obj }, //objek kalian
        'dataType': 'json',
    }).done((result) => {
        Swal.fire({
            icon: 'success',
            title: 'Berhasil!',
            text: 'Data telah ditambahkan!'
        });
       window.location = "https://localhost:44344/auth/Employee";
    }).fail((error) => {
        Swal.fire({
            icon: 'error',
            title: 'Oops..',
            text: 'Data gagal ditambahkan'
        });
    });
};

function getEmp(employeeId) {
    console.log(employeeId)
    $.ajax({
        url: "/Employees/GetEmp/" + employeeId,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            console.log(result);
            var tanggal = result[0].birthDate.substr(0, 10);
            $('#employeeId').val(result[0].employeeId);
            $('#accountId').val(result[0].accountId);
            $('#firstName').val(result[0].firstName);
            $('#lastName').val(result[0].lastName);
            $('#email').val(result[0].email);
            $('#phone').val(result[0].phone);
            $('#gender').val(result[0].gender);
            $('#address').val(result[0].address);
            $('#birthDate').val(tanggal);
            $('#password').val(result[0].password);
            $('#tanggal').val(result[0].hireDate);
            $('#role_id').val(result[0].roleId);
            $('#modalData').modal('show');
            $('#btnUpdateEmployee').show();
            $('#btnAddEmployee').hide();
            $('#hireDate2').show();
            $('#hireDate1').hide();
            $('#hideRow').hide();
            $('#email').prop('disabled', true);;
            $('#tanggal').prop('disabled', true);;
        },
        error: function (errormessage) {
            /*alert(errormessage.responseText);*/
            Swal.fire({
                icon: 'error',
                title: 'Oops..',
                text: 'Data gagal Tidak DItemukan'
            });
        }
    });
    return false;
}
function UpdateEmp() {
    var employeeId = $('#employeeId').val();
    var obj = new Object();
    obj.employeeId = $('#employeeId').val();
    obj.accountId = $('#accountId').val();
    obj.FirstName = $('#firstName').val();
    obj.LastName = $('#lastName').val();
    obj.Email = $('#email').val();
    obj.Phone = $('#phone').val();
    obj.Gender = $('#gender').val();
    obj.Address = $('#address').val();
    obj.BirthDate = $('#birthDate').val();
    obj.HireDate = $('#tanggal').val();
    console.log(obj);
    $.ajax({
        url: "/Employees/Put/" + employeeId,
        type: "PUT",
        data: { id: employeeId, entity: obj }, 
    }).done((result) => {
        Swal.fire({
            icon: 'success',
            title: 'Success!',
            text: 'Data has been updated!'
        });
        $('#tableEmployee').DataTable().ajax.reload();
        $("#modalData").modal("hide");
    }).fail((error) => {
        Swal.fire({
            icon: 'error',
            title: 'Oops..',
            text: 'Data gagal ditambahkan'
        });
    });

}
function getDetailEmp(employeeId) {
    console.log(employeeId)
    $.ajax({
        url: "/Employees/GetEmp/" + employeeId,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            console.log(result[0].hireDate);
            var tanggal = result[0].birthDate.substr(0, 10);
            $('#employeeId').val(result[0].employeeId);
            $('#firstName').val(result[0].firstName);
            $('#lastName').val(result[0].lastName);
            $('#email').val(result[0].email);
            $('#phone').val(result[0].phone);
            $('#gender').val(result[0].gender);
            $('#address').val(result[0].address);
            $('#birthDate').val(tanggal);
            $('#password').val(result[0].password);
            $('#tanggal').val(result[0].hireDate);
            $('#role_id').val(result[0].roleId);
            $('#modalData').modal('show');
            $('#btnUpdateEmployee').hide();
            $('#btnAddEmployee').hide();
            $('#hireDate1').hide();
            $('#hireDate2').show();
            $('#hideRow').hide();
            $('#firstName').prop('disabled', true);;
            $('#lastName').prop('disabled', true);;
            $('#phone').prop('disabled', true);;
            $('#gender').prop('disabled', true);;
            $('#birthDate').prop('disabled', true);;
            $('#tanggal').prop('disabled', true);;
            $('#address').prop('disabled', true);;
            $('#password').prop('disabled', true);;
            $('#email').prop('disabled', true);;
        },
        error: function (errormessage) {
            /*alert(errormessage.responseText);*/
            swal({
                title: "FAILED",
                text: "Data tidak ditemukan!",
                icon: "error"
            }).then(function () {
                window.location = "https://localhost:44344/auth/Employee";
            });
        }
    });
    return false;
}
function DeleleEmp(id) {
    console.log(id);
    Swal.fire({
        title: 'Are you sure want to delete this Employee?',
        text: "you won't be able to revert this!",
        showCancelButton: true,
        confirmButtonColor: '#d33',
        cancelButtonColor: '#3085d6',
        confirmButtonText: 'Yes, Delete it!'
    })
        .then((willDelete) => {
            if (willDelete) {
                $.ajax({
                    url: "/Employees/Delete/" + id,
                    type: "Delete",
                    /*  contentType: "application/json;charset=UTF-8",
                      dataType: "json",*/
                    success: function (result) {
                        mytable.ajax.reload();
                        return Swal.fire(
                            'Delete Successfull',
                            'Employee Data Deleted!',
                            'success',
                        ).then(function () {
                            window.location = "https://localhost:44344/auth/Employee";
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


$.ajax({
    url: "https://localhost:44307/API/Roles",
    success: function (result) {
        var optionRole = `<option value="" >---Choose Role---</option>`;
        $.each(result, function (key, val) {
            optionRole += `
                            <option value="${val.roleId}">${val.roleName}</option>`;
        });
        $('#role_id').html(optionRole);
    }
});
