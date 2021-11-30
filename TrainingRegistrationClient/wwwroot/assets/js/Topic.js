//DATA TABLE
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
                    return ` <td scope=" row">  <a class="btn btn-warning btn-sm text-light" data-url=""  onclick="getDetailTopic('${row.topicId}')"  title="Update"><i class="fa fa-info-circle"></i></a></td>
                                <td scope=" row">  <a class="btn btn-primary btn-sm text-light" data-url=""  onclick="getTopic('${row.topicId}')"  title="Update"><i class="far fa-edit"></i></a></td>
                             <td scope=" row"> <button type="button" class="btn btn-danger btn-sm text-light"  onclick="DeleteTopic('${row.topicId}')" title="Delete"> <i class="fas fa-trash-alt"></i></button></td>`;
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
                required: "Please enter your Topic Desc"
            },
        }
    });
    $('#btnAddTopic').click(function (e) {
        e.preventDefault();
        if ($('#formValidation').valid() == true) {
            InsertTopic();
        }
    });
    $('#btnUpdateTopic').click(function (e) {
        e.preventDefault();
        if ($('#formValidation').valid() == true) {
            UpdateTopic();
        }
    });
});

/*INSERT TOPIC*/
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
            title: 'Success!',
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
/*DELETE TOPIC*/
function DeleteTopic(id) {
    console.log(id);
    Swal.fire({
        title: 'Are you sure want to delete this Topic?',
        text: "you won't be able to revert this!",
        showCancelButton: true,
        confirmButtonColor: '#d33',
        cancelButtonColor: '#3085d6',
        confirmButtonText: 'Yes, Delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                'data': JSON.stringify(id),
                url: '/Topics/Delete/' + id,
                type: 'Delete'
            }).done((result) => {
                mytable.ajax.reload();
                return Swal.fire(
                    'Delete Successful',
                    'Topic Deleted!',
                    'success',
                ).then(function () {
                    window.location = "https://localhost:44344/auth";
                });
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

/*GET TOPIC DETAIL*/
function getDetailTopic(topicId) {
    console.log(topicId)
    $.ajax({
        url: "/Topics/GetTopic/" + topicId,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            console.log(result);
            $('#modalDetail').modal('show');
            $('#topicId2').val(result[0].topicId);
            $('#topicName2').val(result[0].topicName);
            $('#topicDesc2').val(result[0].topicDesc);
            $('#topicName2').prop('disabled', true);
            $('#topicDesc2').prop('disabled', true);
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

/*GETT TOPIC TO UPDATE*/
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
                text: 'Data not found'
            });
        }
    });
    return false;
}
/*UPDATE TOPIC*/
function UpdateTopic() {
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
        }).then(function () {
            window.location = "https://localhost:44344/Auth/Topic";
        });
    }).fail((error) => {
        Swal.fire({
            icon: 'error',
            title: 'Oops..',
            text: 'Failed to update data'
        });
    });
}





