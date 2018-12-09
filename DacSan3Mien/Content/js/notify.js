$(document).ready(function () {
    $(function () {
        if ($('#success').val()) {
            displayMessage($('#success').val(), 'success');
        }
        if ($('#error').val()) {
            displayMessage($('#error').val(), 'error');
        }
    });

    var displayMessage = function (message, msgType) {
        toastr.options = {
            "closeButton": true,
            "positionClass": "toast-top-right",
            "onclick": null,
            "fadeIn": 300,
            "fadeOut": 500,
            "timeOut": 4000
        };
        toastr[msgType](message);
        $('.toast-success, .toast-error').css('width', '350');
        $('.toast-info, .toast-error').css('margin-top', '72px');
    };
});