function MostarMensaje(icono, titulo, mensaje) {
    bootbox.alert({
        title: icono + "  " + titulo,
        message: '<div class="row" style="text-align: justify">' +
            '<div class=col-md-12>' +
            '<h3 class=panel-title>' + mensaje + '</h3>' +
            '</div>' +
            '</div>',
        buttons: {
            ok: {
                label: 'Aceptar',
                className: "btn-primary"
            }
        }
    });


}
