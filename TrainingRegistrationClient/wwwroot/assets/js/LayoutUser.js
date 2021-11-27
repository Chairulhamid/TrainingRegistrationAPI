
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

$(document).ready(function(){
    
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
            /*window.location.replace = "https://localhost:44344/auth/User";*/
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
}