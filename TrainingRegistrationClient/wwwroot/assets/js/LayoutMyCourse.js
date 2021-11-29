$(document).ready(function () {
    getMyCourse(userID);
    getLearnCourse(dataData);
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
                rows += `    <div class="col-lg-4 col-md-6 d-flex align-items-stretch">
                                    <div class="member">
                                        <img src="${item.courseImg}" class="img-fluid" alt="">
                                        <div class="member-content">
                                            <h4>${item.courseName}</h4>
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
function getLearnCourse(Id) {
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


