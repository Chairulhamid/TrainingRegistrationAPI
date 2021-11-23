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
                    return `<td scope=" row">  <a class="btn btn-warning btn-sm text-light" data-url=""  onclick="getData('${row.nik}')" title="Detail"><i class="fa fa-info-circle"></i> </a></td>
                                    <td scope=" row">  <a class="btn btn-primary btn-sm text-light" data-url=""  onclick="getNIK('${row.nik}')"  title="Update"><i class="far fa-edit"></i></a></td>
                                  <td scope=" row"> <button type="button" class="btn btn-danger btn-sm text-light"  onclick="Delele('${row.nik}')" title="Delete"> <i class="fas fa-trash-alt"></i></button></td>`;
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
        $('#btnAdd').click(function (e) {
            e.preventDefault();
            if ($('#formValidation').valid() == true) {
                InsertData();
            }
        });
        $('#btnUpdate').click(function (e) {
            e.preventDefault();
            if ($('#formValidation').valid() == true) {
                Update();
            }
        });
    });
});

function InsertData() {
    var obj = new Object();
    obj.FirstName = $('#firstName').val();
    obj.LastName = $('#lastName').val();
    obj.Phone = $('#phone').val();
    obj.Email = $('#email').val();
    obj.Address = $('#address').val();
    obj.Gender = $('#gender').val();
    obj.BirthDate = $('#birthDate').val();
    obj.HireDate = $('#hireDate').val();
    obj.RoleId = $('#role_id').val();
    console.log(obj);
    $.ajax({
        url: "/Employees/Register",
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
