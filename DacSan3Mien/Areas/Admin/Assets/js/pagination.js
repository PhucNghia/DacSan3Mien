$(document).ready(function () {
    if ($('.pagination li').length == 1) {
        $('.pagination').css('display', 'none');
    }
    else {
        $('.pagination').css('display', '');
    }
})
