
//document ready
var mytable = null;
$(document).ready(function () {
    mytable = $("#table").DataTable({
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
                    return `<button id="button-update" style="background-color:#2eb0e8; color:white; margin-right:15px;" type="button" name="submit" class="btn btn-sm" onclick="ModalUpdate(${row['nik']})" data-dismiss="modal">Update</button>`
                        + `<button id="button-delete" style="background-color:#c41f2b; color: white;" type="button" name="submit" class="btn btn-sm" onclick="Delete(${row['nik']})" data-dismiss="modal">Delete</button>`;
                }
            }
        ],
    });
});

function Validation() {
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

function Insert() {
    var obj = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
    //ini ngambil value dari tiap inputan di form nya
    obj.TopicName = $("#topicName").val();
    obj.TopicDesc = $("#topicDesc").val();
    console.log(obj);
    //isi dari object kalian buat sesuai dengan bentuk object yang akan di post
    $.ajax({
        url: "https://localhost:44383/API/Topics",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        'type': 'POST',
        'data': JSON.stringify(obj), //objek kalian
        'dataType': 'json',
    }).done((result) => {
        return Swal.fire(
            'Register successful',
            'Employee Registered!',
            'success',
        )
        $("#topicModal").modal("toggle"),
            $('#topicModal').modal('hide'),
            mytable.ajax.reload();
    }).fail((error) => {
        return Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Register not successful',
        });
    })
};



