
/*$.ajax({
    url: "https://localhost:44307/API/Roles",
    success: function (result) {
        var optionRole = `<option value="" >---Choose Role---</option>`;
        $.each(result, function (key, val) {
            optionRole += `
                            <option value="${val.roleId}">${val.roleName}</option>`;
        });
        $('#role_id').html( );
    }
});

*/
$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "https://localhost:44307/API/Courses/GetAprovedCourse",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            console.log(data[0].topicName)
            //alert(JSON.stringify(data));                  
            $("#DIV").html('');
            var rows = '';
            $.each(data, function (i, item) {
                rows = `
                               <div class="col-xl-3 col-md-6 d-flex align-items-stretch mb-3" data-aos="zoom-in" data-aos-delay="100">
                                <div class="product">
                                    <div class="imgbox"> <img src="${item.courseImg}"> </div>
                                    <div class="specifies">
                                        <h2>${item.courseName} <br> <span> ${item.topicName}</span></h2>
                                        <div class="price" >Rp. ${item.courseFee}</div> <label>Description</label>
                                        <p>${item.courseDesc}</p>
                                        <a href="user/DetailCourse/${item.courseId}"    class="btn btn-warning klik_menu" id="buyCourse" >Detail</a>
                                    </div>
                                </div>
                            </div>
                            `;
                $('#lesson').append(rows);
            }); //End of foreach Loop   
            console.log(data);
        }, //End of AJAX Success function  

        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  
    });
});

function InsertDataEmpIndex() {
    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = today.getFullYear();
    today = mm + '/' + dd + '/' + yyyy;

    var obj = new Object();
    obj.FirstName = $('#firstName').val();
    obj.LastName = $('#lastName').val();
    obj.Email = $('#email').val();
    obj.Phone = $('#phone').val();
    obj.Gender = $('#gender').val();
    obj.CV = $('#cv').val();
    obj.Address = $('#address').val();
    obj.BirthDate = $('#birthDate').val();
    obj.password = $('#password').val();
    obj.RegistDate = today;
    obj.RoleId = 3;
    console.log(obj);
    $.ajax({
        url: "/Employees/RegisterEmp",
        'type': 'POST',
        'data': { entity: obj }, //objek kalian
        'dataType': 'json',
    }).done((result) => {
        Swal.fire({
            icon: 'success',
            title: 'Success!',
            text: 'Register Successful!'
        }).then(function () {
            window.location = "https://localhost:44344/Home/LoginEmp";
        });
    }).fail((error) => {
        Swal.fire({
            icon: 'error',
            title: 'Oops..',
            text: 'Failed to Add Data'
        });
    });
};
