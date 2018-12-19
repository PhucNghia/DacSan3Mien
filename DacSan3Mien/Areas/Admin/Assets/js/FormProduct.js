$(document).ready(function () {
    if (window.location.pathname.includes("Product/Details")) {
        if ($('.title-form').html() == " Chi tiết sản phẩm") {
            $('input').attr('readonly', 'true');
            $('select').attr('disabled', 'true');
        }
        else {
            $('input').removeAttr('readonly');
            $('select').removeAttr('disabled');
        }
    }
});