$(document).ready(function () {
    $('#tableUser').DataTable({
      /*  dom: 'Bfrtip',
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
        }],*/
        'ajax': {
            'url': "/Users/GetAll",
            'order': [[0, 'asc']],
            'dataSrc': ''
        },

        'columns': [
            {
                data: 'no', name: 'id', render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
        /*    { "data": "employeeId" },*/
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
            { "data": "registDate" },
            {
                "data": "",
                'render': function (data, type, row, meta) {
                    return `<td scope=" row">  <a class="btn btn-warning btn-sm text-light" data-url=""  onclick="getDetailUser('${row.userId}')" title="Detail"><i class="fa fa-info-circle"></i> </a></td>
                                    <td scope=" row">  <a class="btn btn-primary btn-sm text-light" data-url=""  onclick="getUser('${row.userId}')"  title="Update"><i class="far fa-edit"></i></a></td>
                                  <td scope=" row"> <button type="button" class="btn btn-danger btn-sm text-light"  onclick="DeleteUser('${row.userId}')" title="Delete"> <i class="fas fa-trash-alt"></i></button></td>`;
                }
            }
        ]
    });
    $(function () {
        $("form[name='nameModal']").validate({
            rules: {
                userId: {
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
                registDate: {
                    required: true
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
                role_id: {
                    required: true
                }
            },
            messages: {
                userId: {
                    required: "Please enter your userId"
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
                registDate: {
                    required: "Please enter your registdate"
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
                role_id: {
                    required: "Please choose your role"
                }
            }
        });
        $('#btnAddUser').click(function (e) {
            e.preventDefault();
            if ($('#formValidation').valid() == true) {

                InsertData();
            }
        });
        $('#btnUpdateUser').click(function (e) {
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
    obj.RegistDate = $('#registDate').val();
    obj.RoleId = $('#role_id').val();
    console.log(obj);
    $.ajax({
        url: "/Users/RegisterUser",
        'type': 'POST',
        'data': { entity: obj }, //objek kalian
        'dataType': 'json',
    }).done((result) => {
        Swal.fire({
            icon: 'success',
            title: 'Berhasil!',
            text: 'Data telah ditambahkan!'
        });
       window.location = "https://localhost:44344/auth/User";
    }).fail((error) => {
        Swal.fire({
            icon: 'error',
            title: 'Oops..',
            text: 'Data gagal ditambahkan'
        });
    });
};

function getUser(userId) {
    console.log(userId)
    $.ajax({
        url: "/Users/GetUser/" + userId,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            console.log(result);
            var tanggal = result[0].birthDate.substr(0, 10);
            $('#userId').val(result[0].userId);
            $('#accountId').val(result[0].accountId);
            $('#firstName').val(result[0].firstName);
            $('#lastName').val(result[0].lastName);
            $('#email').val(result[0].email);
            $('#phone').val(result[0].phone);
            $('#gender').val(result[0].gender);
            $('#address').val(result[0].address);
            $('#birthDate').val(tanggal);
            $('#password').val(result[0].password);
            $('#tanggal').val(result[0].registDate);
            $('#role_id').val(result[0].roleId);
            $('#modalData').modal('show');
            $('#btnUpdateUser').show();
            $('#btnAddUser').hide();
            $('#registDate2').show();
            $('#registDate1').hide();
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
function UpdateUser() {
    var userId = $('#userId').val();
    var obj = new Object();
    obj.userId = $('#userId').val();
    obj.accountId = $('#accountId').val();
    obj.FirstName = $('#firstName').val();
    obj.LastName = $('#lastName').val();
    obj.Email = $('#email').val();
    obj.Phone = $('#phone').val();
    obj.Gender = $('#gender').val();
    obj.Address = $('#address').val();
    obj.BirthDate = $('#birthDate').val();
    obj.RegistDate = $('#tanggal').val();
    console.log(obj);
    $.ajax({
        url: "/Users/Put/" + userId,
        type: "PUT",
        data: { id: userId, entity: obj }, 
    }).done((result) => {
        Swal.fire({
            icon: 'success',
            title: 'Success!',
            text: 'Data has been updated!'
        });
        $('#tableUser').DataTable().ajax.reload();
        $("#modalData").modal("hide");
    }).fail((error) => {
        Swal.fire({
            icon: 'error',
            title: 'Oops..',
            text: 'Data gagal ditambahkan'
        });
    });

}
function getDetailUser(userId) {
    console.log(userId)
    $.ajax({
        url: "/Users/GetUser/" + userId,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            console.log(result);
            var tanggal = result[0].birthDate.substr(0, 10);
            $('#userId').val(result[0].userId);
            $('#firstName').val(result[0].firstName);
            $('#lastName').val(result[0].lastName);
            $('#email').val(result[0].email);
            $('#phone').val(result[0].phone);
            $('#gender').val(result[0].gender);
            $('#address').val(result[0].address);
            $('#birthDate').val(tanggal);
            $('#password').val(result[0].password);
            $('#tanggal').val(result[0].registDate);
            $('#role_id').val(result[0].roleId);
            $('#modalData').modal('show');
            $('#btnUpdateUser').hide();
            $('#btnAddUser').hide();
            $('#registDate1').hide();
            $('#registDate2').show();
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
            swal.fire({
                title: "FAILED",
                text: "Data tidak ditemukan!",
                icon: "error"
            }).then(function () {
                window.location = "https://localhost:44344/auth/User";
            });
        }
    });
    return false;
}
function DeleteUser(id) {
    console.log(id);
    Swal.fire({
        title: 'Are you sure want to delete this User?',
        text: "you won't be able to revert this!",
        showCancelButton: true,
        confirmButtonColor: '#d33',
        cancelButtonColor: '#3085d6',
        confirmButtonText: 'Yes, Delete it!'
    })
        .then((willDelete) => {
            if (willDelete) {
                $.ajax({
                    url: "/Users/Delete/" + id,
                    type: "Delete",
                    /*  contentType: "application/json;charset=UTF-8",
                      dataType: "json",*/
                    success: function (result) {
                        mytable.ajax.reload();
                        return Swal.fire(
                            'Delete Successfull',
                            'User Data Deleted!',
                            'success',
                        ).then(function () {
                            window.location = "https://localhost:44344/auth/User";
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
