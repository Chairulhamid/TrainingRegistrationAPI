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
});*/
$(document).ready(function () {
    /*   getMyCourse(userID);*/
    //dataId tidak masuk
    getDCourse(dataID);
    getPayCourse(dataID);
    getPayCoursePayment(userId);
    getPayCoursePaymentVerified(userId)
    getCourseModul(dataID);
    getCourseModul1(dataID);
});

/*function getMyCourse(userID) {
    console.log(userID)
    $.ajax({
        type: "GET",
        url: "https://localhost:44307/API/Courses/GetLessonCourse/" + userID,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            console.log(data);
            $("#DIV").html('');
            var rows = '';
            $.each(data, function (i, item) {
                rows = `
                                        <div class="row">
                                            <div class="col-lg-8">
                                                <img id="courseImg" src="${item.courseImg}" class="img-fluid" alt="">

                                                <h3 id="courseName">${item.courseName}</h3>
                                                <p id="courseDesc">${item.courseDesc}</pid>
                                            </div>
                                            <div class="col-lg-4" id="materiDetail">
                                                <div class="content">
                                                    <div class="text-center">
                                                        <h4>Unlimite</h4>
                                                        <hr />
                                                    </div>
                                                    <div class="course-info d-flex justify-content-between align-items-center">
                                                        <h5>Trainer</h5>
                                                        <p id="trainer">${item.trainerName}</p>
                                                    </div>
                                                    <div class="course-info d-flex justify-content-between align-items-center">
                                                        <h5>Course Fee</h5>

                                                        <p id="courseFee">Rp. ${item.courseFee}</p>
                                                    </div>
                                                    <div class="text-center" >
                                                        <a href="PayCourse/${item.courseId}" class="more-btn" id="match" method="checkLogin();">Buy Now<i class="bx bx-chevron-right"></i></a>
                                                </div>
                                            </div>
                                        </div>
                             
                            `;
            });
            $('#gambar').append(rows);
        }, //End of AJAX Success function  

        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  
    });
}*/

function getDCourse(courseId) {
    console.log(courseId)
    $.ajax({
        type: "GET",
        url: "https://localhost:44307/API/Courses/GetApvdIdCourse/" + courseId,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            console.log(data);
            $("#DIV").html('');
            var rows = '';
            $.each(data, function (i, item) {
                rows = `
                                        <div class="row" >
                                            <div class="col-lg-8">
                                                <img id="courseImg" style="width:50%" src="${item.courseImg}" class="img-fluid" alt="">

                                                <h3 id="courseName">${item.courseName}</h3>
                                                <p id="courseDesc">${item.courseDesc}</pid>
                                            </div>
                                            <div class="col-lg-4" id="materiDetail">
                                                <div class="content" style="margin-top:150px">
                                                    <div class="text-center">
                                                        <h4>Details</h4>
                                                        <hr/>
                                                    </div>
                                                    <div class="course-info d-flex justify-content-between align-items-center">
                                                        <h5>Trainer</h5>
                                                        <p id="trainer">${item.trainerName}</p>
                                                    </div>
                                                    <div class="course-info d-flex justify-content-between align-items-center">
                                                        <h5>Course Fee</h5>

                                                        <p id="courseFee">Rp. ${item.courseFee}</p>
                                                    </div>
                                                    <div class="text-center" >
                                                        <a href="PayCourse/${item.courseId}" class="more-btn" id="match" method="checkLogin();">Buy Now<i class="bx bx-chevron-right"></i></a>
                                                </div>
                                            </div>
                                        </div>
                             
                            `;
            });
            $('#gambar').append(rows);
        }, //End of AJAX Success function  

        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  
    });
}

function maketextnumber(n) {
    for (var r = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9"], e = n, t = new Array, a = 0; a <= e - 1; a++) {
        t[a] = r[parseInt(Math.random() * r.length)];
        t = t;
        randomtextnumber = t.join("")
    }
   
}
var hasil = (maketextnumber(3), randomtextnumber);


function getPayCourse(courseId) {
    console.log(courseId)
    $.ajax({
        type: "GET",
        url: "https://localhost:44307/API/Courses/GetApvdIdCourse/" + courseId,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            const numb = data[0].courseFee;
            const format = numb.toString().split('').reverse().join('');
            const convert = format.match(/\d{1,3}/g);
            const rupiah = 'Rp ' + convert.join('.').split('').reverse().join('').substr(0,3)
            $("#courseName").html(data[0].courseName);
            $("#payment").html(rupiah + hasil);
           
        }, //End of AJAX Success function  

        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  
    });
}

function BuyNow(userId, courseId) {
    console.log(userId, courseId)
    var obj = new Object();
    var payment = document.getElementById("payment").innerHTML;
    var result = payment.substring(3);
    var total = parseInt(result);
    obj.UserId = userId;
    //obj.UserId = $('#userId').val();
    obj.CourseId = courseId;
    obj.PaymentDate = $('#date').val();
    obj.BankAccount = $('#bankAccount').val();
    obj.TotalPayment = total;
    console.log(obj)
    $.ajax({
        url: "/Payments/RegisterPay",
        'type': 'POST',
        'data': { entity: obj }, //objek kalian
        'dataType': 'json',
    }).done((result) => {
        Swal.fire({
            icon: 'success',
            title: 'Success!',
            text: 'Register Successful!'

        }).then(function () {
            window.location = "https://localhost:44344/user/PaymentPage/" + userId;
        }).fail((error) => {
            Swal.fire({
                icon: 'error',
                title: 'Oops..',
                text: 'Failed to Register'
            });
        });
    });
}
function getPayCoursePayment(userId) {
    console.log(userId)
    $.ajax({
        url: "https://localhost:44307/API/Payments/GetPayStatusUserId/" + userId,
        success: function (result) {
            console.log(result);
            var listPayment = ""
            $.each(result, function (key, val) {
                listPayment += `<tr>
                                <td>${val.paymentId}</td>
                                 <td>${val.courseName}</td>
                                <td>${val.courseFee}</td>
                                 <td>${val.totalPayment}</td>
                                <td>${val.bankAccount}</td>
                                 <td class="bg-warning">${val.status}</td>
                            </tr>`
            });
            $('#tablePayments').html(listPayment);
        }
    })
}

function getPayCoursePaymentVerified(userId) {
    console.log(userId)
    $.ajax({
        url: "https://localhost:44307/API/Payments/GetPayStatusUserIdVerified/" + userId,
        success: function (result) {
            console.log(result);
            var listPayment1 = ""
            $.each(result, function (key, val) {
                listPayment1 += `<tr>
                                <td>${val.paymentId}</td>
                                 <td>${val.courseName}</td>
                                <td>${val.courseFee}</td>
                                 <td>${val.totalPayment}</td>
                                <td>${val.bankAccount}</td>
                                 <td class="bg-info">${val.status}</td>
                            </tr>`
            });
            $('#tablePaymentVerified').html(listPayment1);
        }
    })
}

function getCourseModul(courseId) {
    console.log(courseId)
    $.ajax({
        url: "https://localhost:44307/API/Moduls/GetCourseModul/" + courseId,
        success: function (result) {
            console.log(result);
            var listModul = ""
            var listModuldua = ""
            $.each(result, function (key, val) {
                listModul += `
                                <ul class="nav nav-tabs flex-column">
                                <li class="nav-item">
                                <a class="nav-link active show" data-bs-toggle="tab" href="${key + 1}">${val.modulTittle}</a>
                                </li>
                                </ul>`
                listModuldua += `
                                <div class="tab-pane active show" id="tab-1">
                            <div class="row">
                                <div class="col-lg-8 details order-2 order-lg-1">
                                     <a class="nav-link active show" data-bs-toggle="tab" href="${val.modulContent}">${val.modulDesc}</a>
                                </div>
                                
                            </div>
                        </div>`
            });
            $('#modulNav').html(listModul);
            $('#modulNavdua').html(listModuldua);
        }
    })
};

function getCourseModul1(courseId) {
    console.log(courseId)
    $.ajax({
        url: "https://localhost:44307/API/Moduls/GetCourseModul/" + courseId,
        success: function (result) {
            console.log(result);
            var listModul = ""
            $.each(result, function (key, val) {
                listModul += `<ul class="list-group" style="margin-bottom:15px">
                                <li class="list-group-item active"><h4>${val.modulTittle}<h3></li>
                                <li class="list-group-item"><h5>${val.modulTittle}</h5></li>
                              </ul> `
            });
            $('#modulList').html(listModul);
        }
    })
};



/*function getPayCoursePayment(userId) {
    console.log(userId)
    $.ajax({
        type: "GET",
        url: "https://localhost:44307/API/Payments/GetPayStatusUserId/" + userId,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $("#courseName1").html(data[0].courseName);
            $("#payment1").html(data[0].totalPayment);
            $("#bankAccount1").html(data[0].bankAccount);

        }, //End of AJAX Success function  

        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  
    });
}*/

/*function getPayCoursePayment(userId) {
    console.log(userId)
    $.ajax({
        type: "GET",
        url: "https://localhost:44307/API/Payments/GetPayStatusUserId/" + userId,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            console.log(data);
            $("#DIV").html('');
            var rows = '';
            $.each(data, function (i, item) {
                rows = ``;
            });
        }, //End of AJAX Success function  

        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  
    });
}*/