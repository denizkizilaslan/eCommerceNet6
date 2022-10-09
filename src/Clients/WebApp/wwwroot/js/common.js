
$(".addBasket").click(function () {
    var id = $(this).attr('data-id');
    $.ajax({
        url: "/Home/AddtoBasket",
        method: "POST",
        data: { id: id },
        success: function (data) {

            console.log(data);
            alert("Ürün sepete eklendi");
        }, error: function () {
            location.href = "/Home/Login";
        }
    });
});


$("#orderPost").click(function () {
    $.ajax({
        type: "GET",
        url: "/Auth/CheckLogin",
        contentType: false,
        cache: false,
        processData: false,
        success: function (response) {
            if (response == "") {
                location.href = "/Home/Login";
            }
            else {
                $.post('/Home/PostOrder', null, function (response) {
                });
            }
        },
        error: function (d) {
            alert("İşlem Başarısız");
        }
    });
});

$("#loginForm").submit(function (e) {
    e.preventDefault();
    var formData = new FormData(this);
    formData.append('Email', $("#Email").val());
    formData.append('password', $("#password").val());
    $.ajax({
        type: "POST",
        url: "/Auth/Check",
        data: formData,
        contentType: false,
        cache: false,
        processData: false,
        success: function (response) {
            if (response.status) 
                location.href = "/Home/Shop";
            else 
                alert(response.message);
            
        },
        error: function (d) {
            alert("İşlem Başarısız");
        }
    });
});
