
$(document).ready(function () {
    getDetailModul(dataID);
});

function getDetailModul(modulId) {
    console.log(modulId)
    $.ajax({
        url: "https://localhost:44307/API/Moduls/GetIdModulContent/" + modulId,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            console.log(result);
            $("#modulTitle").html(result[0].modulTittle);
            $("#modulDesc").html(result[0].modulDesc);
            var video = ""
            $.each(result, function (key, val) {
                video = `<iframe style="position:relative;" width="100%" height="100%"
            src = "${result[0].modulContent}">
            </iframe >`
            });
            $('#modulContent').html(video);
        },
        error: function (errormessage) {
            /*alert(errormessage.responseText);*/
            swal.fire({
                title: "Failed",
                text: "Data not found",
                icon: "error"
            })
        }
    });
    return false;
};