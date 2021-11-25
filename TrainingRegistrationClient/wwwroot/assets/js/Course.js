$(document).ready(function () {
    $('#tableCourse').DataTable({
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
            'url': "/Courses/GetCourse",
            'order': [[0, 'asc']],
            'dataSrc': ''
        },

        'columns': [
            {
                data: 'no', name: 'id', render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            { "data": "courseName" },
            { "data": "topicName" },
            {
                data: "courseFee",
                render: function (data, type) {
                    var number = $.fn.dataTable.render.number(',', '', '', 'Rp. ').display(data);
                    return number;
                }
            },
            { "data": "courseImg" },
            { "data": "trainerName" },
            {
                "data": "",
                'render': function (data, type, row, meta) {
                    return `<td scope=" row">  <a class="btn btn-warning btn-sm text-light" data-url=""  onclick="getDetailCourse('${row.courseId}')" title="Detail"><i class="fa fa-info-circle"></i> </a></td>
                                    <td scope=" row">  <a class="btn btn-primary btn-sm text-light" data-url=""  onclick="getCourse('${row.courseId}')"  title="Update"><i class="far fa-edit"></i></a></td>
                                  <td scope=" row"> <button type="button" class="btn btn-danger btn-sm text-light"  onclick="DeleteCourse('${row.courseId}')" title="Delete"> <i class="fas fa-trash-alt"></i></button></td>`;
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
        $('#btnAddCourse').click(function (e) {
            e.preventDefault();
            if ($('#formValidation').valid() == true) {

                InsertDataCourse();
            }
        });
        $('#btnUpdateCourse').click(function (e) {
            e.preventDefault();
            if ($('#formValidation').valid() == true) {
                UpdateCourse();
            }
        });
    });
});

function InsertDataCourse() {
    var obj = new Object();
    obj.CourseName = $('#courseName').val();
    obj.CourseDesc = $('#courseDesc').val();
    obj.CourseFee = $('#courseFee').val();
    obj.CourseImg = $('#courseImg').val();
    obj.TopicId = $('#topicId').val();
    obj.TrainerId = $('#employeeId').val();
    console.log(obj);
    $.ajax({
        url: "/Courses/RegisterCourse",
        'type': 'POST',
        'data': { entity: obj }, //objek kalian
        'dataType': 'json',
    }).done((result) => {
        Swal.fire({
            icon: 'success',
            title: 'Berhasil!',
            text: 'Data telah ditambahkan!'
        });
       window.location = "https://localhost:44344/auth/Course";
    }).fail((error) => {
        Swal.fire({
            icon: 'error',
            title: 'Oops..',
            text: 'Data gagal ditambahkan'
        });
    });
};

function getCourse(courseId) {
    console.log(courseId)
    $.ajax({
        url: "/Courses/GetIdCourse/" + courseId,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            console.log(result);
            $('#courseId').val(result[0].courseId);
            $('#courseName').val(result[0].courseName);
            $('#courseDesc').val(result[0].courseDesc);
            $('#courseFee').val(result[0].courseFee);
            $('#topicId').val(result[0].topicId);
            $('#employeeId').val(result[0].trainerId);
            $('#courseImg').val(result[0].courseImg);
            $('#modalCourse').modal('show');
            $('#btnUpdateCourse').show();
            $('#btnAddCourse').hide();
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
function UpdateCourse() {
    var courseId = $('#courseId').val();
    var obj = new Object();
    obj.CourseId = $('#courseId').val();
    obj.CourseName = $('#courseName').val();
    obj.CourseDesc = $('#courseDesc').val();
    obj.CourseFee = $('#courseFee').val();
    obj.CourseImg = $('#courseImg').val();
    obj.TopicId = $('#topicId').val();
    obj.TrainerId = $('#employeeId').val();
    console.log(obj);
    $.ajax({
        url: "/Courses/Put/" + courseId,
        type: "PUT",
        data: { id: courseId, entity: obj },
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
function getDetailCourse(courseId) {
    console.log(courseId)
    $.ajax({
        url: "/Courses/GetIdCourse/" + courseId,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            console.log(result);
         /*   var tanggal = result[0].birthDate.substr(0, 10);*/
            $('#courseId').val(result[0].courseId);
            $('#courseName').val(result[0].courseName);
            $('#courseDesc').val(result[0].courseDesc);
            $('#courseFee').val(result[0].courseFee);
            $('#topicId').val(result[0].topicId);
            $('#employeeId').val(result[0].trainerId);
            $('#courseImg').val(result[0].courseImg);
            $('#modalCourse').modal('show');
            $('#btnUpdateCourse').hide();
            $('#btnAddCourse').hide();
            $('#courseName').prop('disabled', true);;
            $('#courseDesc').prop('disabled', true);;
            $('#courseFee').prop('disabled', true);;
            $('#topicId').prop('disabled', true);;
            $('#employeeId').prop('disabled', true);;
            $('#courseImg').prop('disabled', true);;
        },
        error: function (errormessage) {
            /*alert(errormessage.responseText);*/
            swal.fire({
                title: "FAILED",
                text: "Data tidak ditemukan!",
                icon: "error"
            }).then(function () {
                window.location = "https://localhost:44344/auth/Course";
            });
        }
    });
    return false;
}
function DeleteCourse(id) {
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
                    url: "/Courses/Delete/" + id,
                    type: "Delete",
                    success: function (result) {
                        mytable.ajax.reload();
                        return Swal.fire(
                            'Delete Successfull',
                            'Employee Data Deleted!',
                            'success',
                        ).then(function () {
                            window.location = "https://localhost:44344/auth/Course";
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
    url: "https://localhost:44307/API/Employees",
    success: function (result) {
        var optionRole = `<option value="" >---Choose Trainer---</option>`;
        $.each(result, function (key, val) {
            optionRole += `
                            <option value="${val.employeeId}">${val.firstName + " " +val.lastName}</option>`;
        });
        $('#employeeId').html(optionRole);
    }
});
$.ajax({
    url: "https://localhost:44307/API/Topics",
    success: function (result) {
        var optionRole = `<option value="" >---Choose Topic---</option>`;
        $.each(result, function (key, val) {
            optionRole += `
                            <option value="${val.topicId}">${val.topicName}</option>`;
        });
        $('#topicId').html(optionRole);
    }
});
