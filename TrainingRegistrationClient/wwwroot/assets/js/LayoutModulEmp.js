
$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "https://localhost:44307/API/Moduls/GetModulCourse" + SessionID,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            console.log(result);
            //alert(JSON.stringify(data));                  
            //$("#DIV").html('');
            var listModuls = '';
            $.each(result, function (key, val) {
                listModuls += `
                               <tr>
                                <td>${val.modulId}</td>
                                 <td>${val.modulTittle}</td>
                                <td>${val.modulDesc}</td>
                                 <td>${val.modulContent}</td>
                                <td>${val.courseName}</td>
                            </tr>
                            `;
                $('#tableModul').html(listModuls);
            }); //End of foreach Loop   
            console.log(result);
        }, //End of AJAX Success function  

        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  
    });
});



