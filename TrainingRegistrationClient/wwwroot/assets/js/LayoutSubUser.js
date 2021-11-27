




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
    getDCourse(dataID);
    getPayCourse(dataID);
});

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
                                                    <div class="text-center">
                                                        <a href="PayCourse/${item.courseId}" class="more-btn">Buy Now<i class="bx bx-chevron-right"></i></a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                            `;
            });
            $('#gambar').append(rows);
        /*    $("#trainer").html(data[0].trainerName);
            $("#courseFee").html(data[0].courseFee);
            $("#courseName").html(data[0].courseName);
            $("#courseDesc").html(data[0].courseDesc);*/
            /*onsole.log(data)
                $("#DIV").html('');
            var rows = '';
            $.each(data, function (i, item) {
                rows = `
                           
                            `;
                $('#materiDetail').html();
            });*/ //End of foreach Loop   
         /*   console.log(data);*/
        }, //End of AJAX Success function  

        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  
    });
}
function Random() {
  
}
function getPayCourse(courseId) {
    console.log(courseId)
            var acak =5;
    $.ajax({
        type: "GET",
        url: "https://localhost:44307/API/Courses/GetApvdIdCourse/" + courseId,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            console.log(data[0].courseFee);
            $("#courseName").html(data[0].courseName);
            $("#payment").html(data[0].courseFee + acak);
        }, //End of AJAX Success function  

        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  
    });
}


/*$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "https://localhost:44307/API/Courses",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            console.log(data[0].topic.topicName)
            //alert(JSON.stringify(data));                  
            $("#DIV").html('');
            var rows = '';
            $.each(data, function (i, item) {
                rows = `
                               <div class="col-xl-3 col-md-6 d-flex align-items-stretch mb-3" data-aos="zoom-in" data-aos-delay="100">
                        <div class="product">
                            <div class="imgbox"> <img src="${item.courseImg}"> </div>
                            <div class="specifies">
                                <h2>${item.courseName} <br> <span> ${item.topic.topicName}</span></h2>
                                <div class="price" >Rp. ${item.courseFee}</div> <label>Description</label>
                                <p>${item.courseDesc}</p>
                                <a href="user/DetailCourse/${item.courseId}" id="klik_menu"   class="btn btn-warning klik_menu" id="buyCourse" /*onclick="getDCourse('${item.courseId}')">Buy Now</a>
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

$(document).ready(function(){
    getDCourse(dataID);
        });
function getDCourse(courseId) {
    console.log(courseId)
    $.ajax({
        type: "GET",
        url: "https://localhost:44307/API/Courses/GetApvdIdCourse/" + courseId,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            console.log(data)
            *//*window.location.replace = "https://localhost:44344/auth/User";*//*
            //window.location.assign("https://localhost:44344/User/DetailCourse")
            //alert(JSON.stringify(data));                  
            $("#DIV").html('');
            var rows = '';
            $.each(data, function (i, item) {
                rows = `
                             <div class="course-info d-flex justify-content-between align-items-center">
                            <h5>Trainer</h5>
                            <p><a href="#">Walter White</a></p>
                        </div>
                            `;
                $('#materiDetail').html();
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
}*/