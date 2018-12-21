$(document).ready(function () {
    var accessQuantity = $('#access-quantity').val();
    if (accessQuantity == "True") {
        $.ajax({
            type: "POST",
            url: "AccessQuantity/Edit"
        });
    }
})