
//document ready
var mytable = null;
$(document).ready(function () {
    mytable = $("#tableTopic").DataTable({
        //'ordering': false,
        'ajax': {
            'url': "https://localhost:44307/API/Topics",
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
                "data": "topicId"
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    return row['topicName'];
                }
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    return row['topicDesc'];
                }
            },
            {
                data: null,
                render: function (data, type, row) {
                    return `<button id="button-update" style="background-color:#2eb0e8; color:white; margin-right:15px;" type="button" name="submit" class="btn btn-sm" onclick="getTopic(${row['topicId']})" data-dismiss="modal">Update</button>`
                        + `<button id="button-delete" style="background-color:#c41f2b; color: white;" type="button" name="submit" class="btn btn-sm" onclick="Delete(${row['topicId']})" data-dismiss="modal">Delete</button>`;
                }
            }
        ],
    });
});



////VALIDATE
$(function () {
    $("form[name='nameModal']").validate({
        rules: {
            topicName: {
                required: true
            },
            topicDesc: {
                required: true
            },
        },
        messages: {
            topicName: {
                required: "Please enter your Topic Name"
            },
            topicDesc: {
                required: "Please enter your Tapic Desc"
            },
        }
    });
    $('#btnAddTopic').click(function (e) {
        e.preventDefault();
        if ($('#formValidation').valid() == true) {
            InsertTopic();
        }
    });
    $('#btnUpdate').click(function (e) {
        e.preventDefault();
        if ($('#formValidation').valid() == true) {
            Update();
        }
    });
});

function InsertTopic() {
    var obj = new Object();
    obj.TopicName = $("#topicName").val();
    obj.TopicDesc = $("#topicDesc").val();
    console.log(obj);
    $.ajax({
        url: "/Topics/RegisterTopic",
        'type': 'POST',
        'data': { entity: obj },
        'dataType': 'json'
    }).done((result) => {
        mytable.ajax.reload();
        Swal.fire({

            icon: 'success',
            title: 'Berhasil!',
            text: 'Data successfully Added'
        });
        $('#tableTopic').DataTable().ajax.reload();
        $("#modalTopic").modal("hide");
    }).fail((error) => {
        Swal.fire({
            icon: 'error',
            title: 'Oops..',
            text: 'Failed to Add Data'
        });
    });
};

function Delete(id) {
    console.log(id);
    Swal.fire({
        title: 'Are you sure want to delete this Employee?',
        text: "you won't be able to revert this!",
        showCancelButton: true,
        confirmButtonColor: '#d33',
        cancelButtonColor: '#3085d6',
        confirmButtonText: 'Yes, Delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                'data': JSON.stringify(id),
                url: 'Topics/Delete/' + id,
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

function getTopic(topicId) {
    console.log(topicId)
    $.ajax({
        url: "/Topics/GetTopic/" + topicId,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            console.log(result);
            $('#modalUpdate').modal('show');
            $('#topicId1').val(result[0].topicId);
            $('#topicName1').val(result[0].topicName);
            $('#topicDesc1').val(result[0].topicDesc);
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
function Update() {
    var topicId = $('#topicId1').val();
    var obj = new Object();
    obj.TopicId = $('#topicId1').val()
    obj.TopicName = $("#topicName1").val();
    obj.TopicDesc = $("#topicDesc1").val();
    console.log(obj);
    $.ajax({
        url: "/Topics/Put/" + topicId,
        type: "PUT",
        data: { id: topicId, entity: obj },
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
            text: 'Data gagal ditambahkan'
        });
    });
}





