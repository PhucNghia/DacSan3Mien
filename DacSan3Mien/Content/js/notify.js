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
            "showDuration": 1000,
            "timeOut": 5000
        };
        toastr[msgType](message);
        $('.toast-success, .toast-error').css('width', '350');
        $('.toast-success, .toast-error').css('margin-top', '72px');
    };
});