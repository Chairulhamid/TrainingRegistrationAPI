var myTable = null;
$(document).ready(function () {
    myTable = $('#tableCourseNotApproved').DataTable({
        'ajax': {
            'url': "https://localhost:44307/API/Courses/GetWaitingCourse",
            'dataSrc': "",
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
                "render": function (data, type, row, meta) {
                    return `<p class="bg-info text-white">${row.statusCourse}</p>`;
                }
            },
            {
                "data": "",
                'render': function (data, type, row, meta) {
                    return `<td scope=" row">  <a class="btn btn-primary btn-sm text-light" data-url=""  onclick="getDetailWaitCourse('${row.courseId}')" title="Detail"><i class="fa fa-info-circle"></i> </a></td>
                        `;
                }
            }
        ]
    });
});

var myCourse = null;
$(document).ready(function () {
    myCourse = $('#tableCourse').DataTable({
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
            'url': "https://localhost:44307/API/Courses/GetActCourse",
            'dataSrc': "",
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
                "render": function (data, type, row, meta) {
                    if (row['statusCourse'] == "Approved") {
                   /*     return row['phone'].replace('0', '+62');*/
                    return `<p class="bg-primary text-white">${row.statusCourse}</p>`;
                    } else {
                      
                    return `<p class="bg-warning text-white">${row.statusCourse}</p>`;
                    }
                }
            },
            {
                "data": "",
                'render': function (data, type, row, meta) {
                    return `
                               
                                  <td scope=" row"> <button type="button" class="btn btn-danger btn-sm text-light"  onclick="DeleteCourse('${row.courseId}')" title="Delete"> <i class="fas fa-trash-alt"></i></button></td>`;
                }
            }
        ]
    });
});

function getDetailWaitCourse(courseId) {
    console.log(courseId)
    $.ajax({
        url: "/Courses/GetWaitIdCourse/" + courseId,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            console.log(result);
            //*   var tanggal = result[0].birthDate.substr(0, 10);*//*
            $('#courseId').val(result[0].courseId);
            $('#courseName').val(result[0].courseName);
            $('#courseDesc').val(result[0].courseDesc);
            $('#courseFee').val(result[0].courseFee);
            $('#topicId').val(result[0].topicId);
            $('#employeeId').val(result[0].trainerId);
            $('#courseImg').val(result[0].courseImg);
            $('#statusCourse').val(result[0].statusCourse);
            $('#modalCourse').modal('show');
            $('#btnUpdateCourse').hide();
            $('#btnAddCourse').hide();
            $('#courseName').prop('disabled', true);;
            $('#courseDesc').prop('disabled', true);;
            $('#courseFee').prop('disabled', true);;
            $('#topicId').prop('disabled', true);;
            $('#employeeId').prop('disabled', true);;
            $('#courseImg').prop('disabled', true);;
            $('#statusCourse').prop('disabled', true);;
        },
        error: function (errormessage) {
            //*alert(errormessage.responseText);*//*
            swal.fire({
                title: "FAILED",
                text: "Data not found!",
                icon: "error"
            }).then(function () {
                window.location = "https://localhost:44344/auth/Course";
            });
        }
    });
}

function getDetailCourse(courseId) {
    console.log(courseId)
    $.ajax({
        url: "/Courses/GetActIdCourse/" + courseId,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            console.log(result);
         //*   var tanggal = result[0].birthDate.substr(0, 10);*//*
            $('#courseId').val(result[0].courseId);
            $('#courseName').val(result[0].courseName);
            $('#courseDesc').val(result[0].courseDesc);
            $('#courseFee').val(result[0].courseFee);
            $('#topicId').val(result[0].topicId);
            $('#employeeId').val(result[0].trainerId);
            $('#courseImg').val(result[0].courseImg);
            $('#statusCourse').val(result[0].statusCourse);
            $('#modalCourse').modal('show');
            $('#btnUpdateCourse').hide();
            $('#btnAddCourse').hide();
            $('#courseName').prop('disabled', true);;
            $('#courseDesc').prop('disabled', true);;
            $('#courseFee').prop('disabled', true);;
            $('#topicId').prop('disabled', true);;
            $('#employeeId').prop('disabled', true);;
            $('#courseImg').prop('disabled', true);;
            $('#statusCourse').prop('disabled', true);;
        },
        error: function (errormessage) {
           //*alert(errormessage.responseText);*//*
                swal.fire({
                    title: "FAILED",
                    text: "Data not found!",
                    icon: "error"
                }).then(function () {
                    window.location = "https://localhost:44344/auth/Course";
                });
        }
    });
    return false;
}

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
            title: 'Success!',
            text: 'Data successfully Added!'
        });
        window.location = "https://localhost:44344/auth/Course";
    }).fail((error) => {
        Swal.fire({
            icon: 'error',
            title: 'Oops..',
            text: 'Failed to Add Data'
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
                text: 'Data not found'
            });
        }
    });
    return false;
}
function UpdateCourse1() {
    var courseId = $('#courseId').val();
    var obj = new Object();
    obj.CourseId = $('#courseId').val();
    obj.CourseName = $('#courseName').val();
    obj.CourseDesc = $('#courseDesc').val();
    obj.CourseFee = $('#courseFee').val();
    obj.CourseImg = $('#courseImg').val();
    obj.TopicId = $('#topicId').val();
    obj.employeeId = $('#employeeId').val();
    obj.StatusCourse = $('#statusCourse1').val();
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
        }).then(function () {
            window.location = "https://localhost:44344/auth/Course";
        });
    }).fail((error) => {
        Swal.fire({
            icon: 'error',
            title: 'Oops..',
            text: 'Failed to update data'
        });
    });

}
function UpdateCourse2() {
    var courseId = $('#courseId').val();
    var obj = new Object();
    obj.CourseId = $('#courseId').val();
    obj.CourseName = $('#courseName').val();
    obj.CourseDesc = $('#courseDesc').val();
    obj.CourseFee = $('#courseFee').val();
    obj.CourseImg = $('#courseImg').val();
    obj.TopicId = $('#topicId').val();
    obj.employeeId = $('#employeeId').val();
    obj.StatusCourse = $('#statusCourse2').val();
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
        }).then(function () {
            window.location = "https://localhost:44344/auth/Course";
        });
    }).fail((error) => {
        Swal.fire({
            icon: 'error',
            title: 'Oops..',
            text: 'Failed to update data'
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
                text: "Data not found!",
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
        title: 'Are you sure want to delete this Course?',
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
                            'Course Data Deleted!',
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
                            <option value="${val.employeeId}">${val.firstName + " " + val.lastName}</option>`;
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