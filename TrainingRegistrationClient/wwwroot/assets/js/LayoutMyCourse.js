$(document).ready(function () {
    getMyCourse(userID);
    getLearnCourse(dataLearn);
});
function getMyCourse(SessionId) {
    console.log(SessionId)
    $.ajax({
        type: "GET",
        url: "https://localhost:44307/API/Payments/GetLessonCourse/" + SessionId,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            console.log(data);
            $("#DIV").html('');
            var rows = '';
            $.each(data, function (i, item) {
                rows += `
<div class="col-lg-4 col-md-6 d-flex align-items-stretch">
                    <div class="member">
                        <img src="${item.courseImg}" class="img-fluid" alt="">
                        <div class="member-content">
                            <h4>${item.courseName}</h4>
                            <span>Web Development</span>
                            <p>
                              ${item.modulTittle}
                            </p>
                            <div class="social">
                              <a href="LearnCourse/${item.courseId}" class="btn more-btn text-white" id="match" style="background-color: #2d3e50"  >Learn<i class="bx bx-chevron-right"></i></a>
                            </div>
                        </div>
                    </div>
                </div>
                            `;
            });
            $('#myCourse').append(rows);
        }, //End of AJAX Success function  

        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  
    });
}
/*function getMyCourse(id) {
    console.log(id)
    $.ajax({
        type: "GET",
        url: "https://localhost:44307/API/Payments/GetLearnCourse/" + id,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            console.log(id);
            $("#DIV").html('');
            var rows = '';
            $.each(data, function (i, item) {
                rows += `
<div class="col-lg-4 col-md-6 d-flex align-items-stretch">
                    <div class="member">
                        <img src="${item.courseImg}" class="img-fluid" alt="">
                        <div class="member-content">
                            <h4>${item.courseName}</h4>
                            <span>Web Development</span>
                            <p>
                              ${item.modulTittle}
                            </p>
                            <div class="social">
                              <a href="LearnCourse/${item.courseId}" class="btn more-btn text-white" id="match" style="background-color: #2d3e50"  >Learn<i class="bx bx-chevron-right"></i></a>
                            </div>
                        </div>
                    </div>
                </div>
                            `;
            });
            $('#myCourse').append(rows);
        }, //End of AJAX Success function  

        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  
    });
}*/
/*function getLearnCourse(Id) {
    console.log(Id)
    $.ajax({
        type: "GET",
        url: "https://localhost:44307/API/Courses/GetLearnCourse/" + Id,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            console.log(data);
            $("#DIV").html('');
            var rows = '';
            $.each(data, function (i, item) {
                rows += `   
                            `;
            });
            $('#myCourse').append(rows);
        }, //End of AJAX Success function  

        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  
    });
}
*/
/*$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "https://localhost:44307/API/Payments/GetLessonCourse",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            //alert(JSON.stringify(data));                  
            $("#DIV").html('');
            var rows = '';
            $.each(data, function (i, item) {
                rows = `
                               <div class="col-xl-3 col-md-6 d-flex align-items-stretch mb-3" data-aos="zoom-in" data-aos-delay="100">

                                <div class="row gutters-sm">
                                <div class="col-md-4 mb-3">
                                 <div class="card">
                                 <div class="card-body">
                                    <div class="d-flex flex-column align-items-center text-center">
                                        <img src="${item.courseImg}" class="rounded-circle" width="150">
                                        <div class="mt-3">
                                        <h4>${item.courseName}</a> <label>Course Name</label></h4>
                                        <p class="text-secondary mb-1">${item.courseDesc}</p><label>Course Desc</label>
                                    </div>
                                    </div>
                                    </div>
                                </div>

                                <div class="card">
                                <div class="card-body">
                                    <div class="row">
                                    <div class="col-sm-3">
                                    <h6 class="mb-0">Full Name</h6>
                                    </div>
                                        <div class="col-sm-9 text-secondary">
                                        ${item.firstName} ${item.lastName}
                                        </div>
                                        </div>
                                    <hr>
                                <div class="row">
                                    <div class="col-sm-3">
                                    <h6 class="mb-0">Status</h6>
                                    </div>
                                        <div class="col-sm-9 text-secondary">
                                        ${item.status}
                                        </div>
                                        </div>
                                    <hr>
                                <div class="row">
                                    <div class="col-sm-3">
                                    <h6 class="mb-0">Modul Title</h6>
                                    </div>
                                        <div class="col-sm-9 text-secondary">
                                        ${item.modulTittle}
                                        </div>
                                        </div>
                                    <hr>
                                <div class="row">
                                    <div class="col-sm-3">
                                    <h6 class="mb-0">Modul Desc</h6>
                                    </div>
                                        <div class="col-sm-9 text-secondary">
                                        ${item.modulDesc}
                                        </div>
                                        </div>
                                   
                                
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
});*/


