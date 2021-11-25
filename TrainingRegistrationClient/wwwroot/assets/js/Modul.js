var mytable = null;
$(document).ready(function () {
    mytable = $("#tableModul").DataTable({
        //'ordering': false,
        'ajax': {
            'url': "https://localhost:44307/API/Moduls/getmodul",
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
                "data": "modulId"
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    return row['modulTittle'];
                }
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    return row['modulDesc'];
                }
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    return row['modulContent'];
                },
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    return row['courseName'];
                },
            },
            {
                data: null,
                render: function (data, type, row) {
                    return `<button id="button-update" style="background-color:#2eb0e8; color:white; margin-right:15px;" type="button" name="submit" class="btn btn-sm" onclick="getModul(${row['modulId']})" data-dismiss="modal">Update</button>`
                        + `<button id="button-delete" style="background-color:#c41f2b; color: white;" type="button" name="submit" class="btn btn-sm" onclick="DeleteModul(${row['modulId']})" data-dismiss="modal">Delete</button>`;
                }
            }
        ],
    });
});

$(function() {
    $("form[name='nameModal']").validate({
        rules: {
            modulName: {
                required: true
            },
            modulDesc: {
                required: true
            },
            modulContent: {
                required: true
            },
            courseId: {
                required: true
            },
        },
        messages: {
            modulName: {
                required: "Please enter your Modul Name"
            },
            modulDesc: {
                required: "Please enter your Modul Desc"
            },
            modulContent: {
                required: "Please enter your Modul Content"
            },
            courseId: {
                required: "Please enter your Course"
            },
        }
    });
    $('#btnAddModul').click(function (e) {
        e.preventDefault();
        if ($('#formValidation').valid() == true) {
            InsertModul();
        }
    });
    $('#btnUpdateModul').click(function (e) {
        e.preventDefault();
        if ($('#formValidation').valid() == true) {
            UpdateModul();
        }
    });
});

function InsertModul() {
    var obj = new Object();
    obj.ModulTittle = $("#modulTittle").val();
    obj.ModulDesc = $("#modulDesc").val();
    obj.ModulContent = $("#modulContent").val();
    obj.CourseId = $("#courseId").val();
    console.log(obj);
    $.ajax({
        url: "/Moduls/RegisterModul",
        'type': 'POST',
        'data': { entity: obj},
        'dataType': 'json'
    }).done((result) => {
        mytable.ajax.reload();
        Swal.fire({

            icon: 'success',
            title: 'Berhasil!',
            text: 'Data successfully Added'
        });
        $('#tableModul').DataTable().ajax.reload();
        $("#modalModul").modal("hide");
    }).fail((error) => {
        Swal.fire({
            icon: 'error',
            title: 'Oops..',
            text: 'Failed to Add Data'
        });
    });
};

function DeleteModul(id) {
    console.log(id);
    Swal.fire({
        title: 'Are you sure want to delete this Modul?',
        text: "you won't be able to revert this!",
        showCancelButton: true,
        confirmButtonColor: '#d33',
        cancelButtonColor: '#3085d6',
        confirmButtonText: 'Yes, Delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                'data': JSON.stringify(id),
                url: '/Moduls/Delete/' + id,
                type: 'Delete'
            }).done((result) => {
                mytable.ajax.reload();
                return Swal.fire(
                    'Delete Successfull',
                    'Employee Data Deleted!',
                    'success',
                )
            }).fail((error) => {
                return Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: 'Delete not successful',
                });
            })
        }
    })
};

function getModul(modulId) {
    console.log(modulId)
    $.ajax({
        url: "/Moduls/GetIdModul/" + modulId,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            console.log(result);
            $('#modalUpdateModul').modal('show');
            $('#modulId1').val(result[0].modulId);
            $('#modulTittle1').val(result[0].modulTittle);
            $('#modulDesc1').val(result[0].modulDesc);
            $('#modulContent1').val(result[0].modulContent);
            $("#courseId1").val(result[0].courseId);
        },
        error: function (errormessage) {
            /*alert(errormessage.responseText);*/
            Swal.fire({
                icon: 'error',
                title: 'Oops..',
                text: 'Data gagal Tidak Ditemukan'
            });
        }
    });
    return false;
}
function Update() {
    var modulId = $('#modulId1').val();
    var obj = new Object();
    obj.modulId = $('#modulId1').val()
    obj.modulTittle = $("#modulTittle1").val();
    obj.modulDesc = $("#modulDesc1").val();
    obj.modulContent = $("#modulContent1").val();
    obj.courseId = $("#courseId1").val();
    console.log(obj);
    $.ajax({
        url: "/Moduls/Put/" + modulId,
        type: "PUT",
        data: { id: modulId, entity: obj },
    }).done((result) => {
        mytable.ajax.reload();
        Swal.fire({
            icon: 'success',
            title: 'Success!',
            text: 'Data has been updated!'
        });
        $("#modalUpdate").modal("hide");
    }).fail((error) => {
        Swal.fire({
            icon: 'error',
            title: 'Oops..',
            text: 'Failed to update data!'
        });
    });
}

$.ajax({
    url: "https://localhost:44307/API/Courses/getcourse",
    success: function (result) {
        var optionRole = `<option value="" >Choose a Course</option>`;
        $.each(result, function (key, val) {
            optionRole += `
                            <option value="${val.courseId}">${val.courseName}</option>`;
        });
        $('#courseId').html(optionRole);
    }
});
$.ajax({
    url: "https://localhost:44307/API/Courses/getcourse",
    success: function (result) {
        var optionRole = `<option value="" >Choose a Course</option>`;
        $.each(result, function (key, val) {
            optionRole += `
                            <option value="${val.courseId}">${val.courseName}</option>`;
        });
        $('#courseId1').html(optionRole);
    }
});