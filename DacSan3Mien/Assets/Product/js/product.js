$(document).ready(function () {
    if ($('.pagination-product li').length == 1) {
        $('.pagination-product').css('display', 'none');
    }
    else {
        $('.pagination-product').css('display', '');
    }
})