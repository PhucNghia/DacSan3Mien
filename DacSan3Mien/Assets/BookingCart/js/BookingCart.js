$(document).ready(function () {
    $('.add_to_cart_button').on('click', function () {
        $(this).parent('form').submit();
    });

    $('.remove-product').on('click', function (e) {
        var productId = $(this).attr('data-productId');
        e.preventDefault();
        $.ajax({
            type: "POST",
            url: "BookingCart/Delete",
            data: {
                productId: productId
            },
            success: function (result) {
                if ($('#cart tr').length == 1)
                    window.location = '/'
                else
                location.reload(result);
            }
        });
    });

    $('.product-quantity').on('change', function (e) {
        var productId = $(this).attr('data-productId');
        var quantity = $(this).val();
        e.preventDefault();
        $.ajax({
            type: "POST",
            url: "BookingCart/Edit",
            data: {
                productId: productId,
                quantity: quantity
            },
            success: function (result) {                
                location.reload(result);
            }
        });
    });
});