




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