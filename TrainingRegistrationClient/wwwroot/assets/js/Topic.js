
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
                    return `<button id="button-update" style="background-color:#2eb0e8; color:white; margin-right:15px;" type="button" name="submit" class="btn btn-sm" onclick="ModalUpdate(${row['topicId']})" data-dismiss="modal">Update</button>`
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

//LAMA
/*function Validation() {
  var a = $("#addTopic").valid();
   console.log(a);
     if (a == true) {
        Insert();
     }
     else {
       Swal.fire({
       icon: 'error',
       title: 'Oops...',
       text: 'Register Failed!',
       footer: 'All columns must be filled !'
       })
     }
}
*/

//END LAMA


//INSERT DATA
/*function InsertData() {
    var obj = new Object();
    obj.TopicName = $('#topicName').val();
    obj.TopicDesc = $('#topicDesc').val();
    console.log(obj);
    $.ajax({
        url: "https://localhost:44307/API/Topics",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        'type': 'POST',
       'data': { entity: obj }, //objek kalian
        //'data': JSON.stringify(obj), //objek kalian
        'dataType': 'json',
       *//* 'type': 'POST',
        'dataType': 'json',*//*
    }).done((result) => {
        if (result == 200) {
            swal({
                title: "Good job!",
                text: "Data Berhasil Ditambahkan!!",
                icon: "success",
                button: "Okey!",
            }).then(function () {
                window.location = "https://localhost:44306/auth";
            });
        } else if (result == 400) {
            swal({
                title: "Failed!",
                text: "Data Gagal Dimasukan, NIK,Phone,Email Sudah Terdaftar!!",
                icon: "error",
                button: "Close",
            });
        }
    }).fail((error) => {

        swal({
            title: "Failed!",
            text: "Data Gagal Dimasukan!!",
            icon: "error",
            button: "Close",
        });
    })
}*/
//END INSERT
function InsertTopic() {
    var obj = new Object();
    obj.TopicName = $("#topicName").val();
    obj.TopicDesc = $("#topicDesc").val();
    console.log(obj);
    $.ajax({
        url: "/Topics/RegisterTopic",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        'type': 'POST',
        'data': { entity: obj },
        'dataType': 'json'
    }).done((result) => {
        Swal.fire({
            icon: 'success',
            title: 'Berhasil!',
            text: 'Data telah ditambahkan!'
        });
        $('#tableTopic').DataTable().ajax.reload();
        $("#topicModal").modal("hide");
    }).fail((error) => {
        Swal.fire({
            icon: 'error',
            title: 'Oops..',
            text: 'Data gagal ditambahkan'
        });
    });
};



