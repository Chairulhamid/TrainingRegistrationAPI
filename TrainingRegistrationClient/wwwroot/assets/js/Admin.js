var mytable = null;
//document ready


/*$.ajax({
    url: "https://localhost:44307/API/Topics",
    success: function (result) {
        console.log(result);
        var listTopic = ""
        $.each(result, function (key, val) {
            listTopic += `<tr>
                                    <td>${topicId}</td>
                                    <td>${topicName}</td>
                                    <td>${topicDesc}</td>
                                    <td></td>
                                </tr>`
        });
        $('#tableTopic').html(listTopic);
    }
})*/

$(document).ready(function () {
    mytable = $("#table").DataTable({
        //'ordering': false,
        'ajax': {
            'url': "https://localhost:44307/API/Topics",
            'dataSrc': "",
        },
        buttons: [
            {
                extend: 'excelHtml5',
                name: 'excel',
                title: 'Employee',
                sheetName: 'Employee',
                text: '',
                className: 'buttonHide fa fa-download btn-default',
                filename: 'Data',
                autoFilter: true,
                exportOptions: {
                    columns: [1, 2, 3, 4, 5, 6]
                }
            }
        ],
        'columnDefs': [
            { orderable: false, targets: 7 }
        ],
        'columns': [
            {
                "data": "id",
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            {
                "data": "nik"
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    return row['firstName'] + " " + row['lastName'];
                }
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    if (row['gender'] == 0) {
                        return "Male";
                    }
                    else
                        return "Female";
                }
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    if (row['phoneNumber'].substring(0, 1) == '0') {
                        return "+62" + row['phoneNumber'].substring(1, row['phoneNumber'].length);
                    }
                    else {
                        return row['phoneNumber'];
                    }
                }
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    return row['salary'];
                }
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    return row['email'];
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

function Validation() {
  var a = $("#register").valid();
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



