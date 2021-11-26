function InsertDataUserIndex() {
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
    obj.Address = $('#address').val();
    obj.BirthDate = $('#birthDate').val();
    obj.password = $('#password').val();
    obj.RegistDate = today;
    obj.RoleId = 2;
    console.log(obj);
    $.ajax({
        url: "/Users/RegisterUser",
        'type': 'POST',
        'data': { entity: obj }, //objek kalian
        'dataType': 'json',
    }).done((result) => {
        Swal.fire({
            icon: 'success',
            title: 'Success!',
            text: 'Register Successful!'
        }).then(function () {
            window.location = "https://localhost:44344/Home/LoginPage";
        });
    }).fail((error) => {
        Swal.fire({
            icon: 'error',
            title: 'Oops..',
            text: 'Failed to Add Data'
        });
    });
};