$(document).ready(function () {
    if (window.location.pathname.includes("User/Details")) {
        if ($('.title-form').html() == " Chi tiết người dùng") {
            $('input').attr('readonly', 'true');
            $('select').attr('disabled', 'true');
        }
        else {
            $('input').removeAttr('readonly');
            $('select').removeAttr('disabled');
        }
    }
});