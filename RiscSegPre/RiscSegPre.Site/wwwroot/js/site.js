$(document).ready(function () {

    $('.edit').click(function () {
        goToEdit(this.id);
    });

    $(".cep").mask('00000-000', { reverse: false });

    var valores = $(".nota");
    //  valores.mask('000.000,00', { reverse: true });
    valores.mask('000', { reverse: true });
    valores.removeAttr('data-val-number');


});

toastr.options = { "positionClass": "toast-top-center", "progressBar": true, "preventDuplicates": true, "timeOut": "3000" };

function showCookieMessage(cookieName, type) {

    var message = Cookies.get(cookieName);

    if (message !== undefined) {

        var systemMessage = JSON.parse(message);

        showMessage(systemMessage, type);
    }
    Cookies.remove(cookieName);
}

function showMessage(message, type) {
    var options = {
        "positionClass": "toast-top-center",
        "closeButton": false,
        "debug": false,
        "newestOnTop": false,
        "progressBar": true,
        "preventDuplicates": true,
        "onclick": null,
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "10000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    };

    if (type === undefined) {
        if (message !== undefined)
            toastrEx(message.Type, message.Content, "Mensagem do Sistema", options);
    }
    else
        toastrEx(type, message, "Mensagem do Sistema", options);
}

function toastrEx(messageType, content, title, options) {
    toastr.remove();

    switch (messageType) {
        case 0:
            toastr.info(content, title, options);
            break;
        case 1:
            toastr.success(content, title, options);
            break;
        case 2:
            toastr.warning(content, title, options);
            break;
        case 3:
            toastr.error(content, title, options);
            break;
    }
}

