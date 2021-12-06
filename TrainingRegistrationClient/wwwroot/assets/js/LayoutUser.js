
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
                                        <p>${item.courseDesc}</p>
                                        <a href="user/DetailCourse/${item.courseId}"    class="btn btn-warning klik_menu" id="buyCourse" >Detail</a>
                                        <a   class="text-black text-right" style="font-size:20px" id="buyCourse" ><b>Rp .  ${item.courseFee}</b></a>
                               
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


function GiveReview(){
    var obj = new Object();
    //obj.UserId = null;
    obj.Email = $('#email1').val();
    obj.Testimony = $('#testimony').val();
    console.log(obj)
    $.ajax({
        url: "/feedbacks/inputfeedback",
        'type': 'POST',
        'data': { entity: obj },
        'dataType': 'json',
    }).done((result) => {
        if (result == 200) {
            return Swal.fire({
                icon: 'success',
                title: 'Success!',
                text: 'Review Successful!'
            }).then(function () {
                window.location = "https://localhost:44344/";
            });
        } else if (result == 500) {
            return Swal.fire({
                icon: 'error',
                title: 'Oops..',
                text: 'Failed to Add , You have added testimonials!!'
            }).then(function () {
                window.location = "https://localhost:44344/";
            });
        }
        }).fail((error) => {
            return Swal.fire({
                icon: 'error',
                title: 'Oops..',
                text: 'Failed to Add Review'
            });
        });
};



