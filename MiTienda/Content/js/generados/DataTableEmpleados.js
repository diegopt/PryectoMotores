$("#TablaEmpleados").ready(function () {
    /////////////////////// LA TABLA DE ROLES ///////////////////////   
    var TablaEmpleados = $("#TablaEmpleados").DataTable({
        "scrollCollapse": true,
        "paging": false,
        "info": false,
        "order": false,
        "language": {
            "search": "Buscar",
            "zeroRecords": "Sin resultados",
            "infoEmpty": "Sin registros"
        }
    });
    $("#TablaR_filter").css('padding-right', 20);
});

