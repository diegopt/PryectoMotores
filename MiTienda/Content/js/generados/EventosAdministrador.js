//////////////////////// VARIABLES PANTALLA ALUMNOS ////////////////////////
    let DatosEmpleado=[];
    let DatosRol=[];
    let TituloMensaje;
    let Mensaje;
    let iconoCorrecto='<i class=\"fa fa-check-circle fa-lg iconoCorrecto\"></i>';
    let iconoError='<i class=\"fa fa-times-circle fa-lg iconoError\"></i>';
    let iconoInfo='<i class=\"fa fa-info-circle fa-lg iconoInfo\"></i>';
    
    
//////////////////////// FORMULARIO DATOS EMPLEADO ////////////////////////
$("#bodyAdmin").on("click","#btnGuardarEmpleado", function (evento) {
    evento.preventDefault();
    // alert($("#nombreEmpleado").val() + " | " + $("#correoEmpleado").val() + " | " +$("#rolEmpleado").val())
    Datos = [$("#nombreEmpleado").val(), $("#correoEmpleado").val(), $("#rolEmpleado").val()];
       
        let InputsConError;
        let CampoVacio=BuscarVacioFormEmp(Datos);
        if (CampoVacio) {
            InputsConError = ValidarInputsFormEmp(Datos);
            if (InputsConError.length === 0) {
                $("#btnSubmitEmpleado").trigger("click");  
                //MostarMensaje(iconoCorrecto, "TODO BIEN", "DATOS CORRECTOS");
            } else {
                TituloMensaje = "<b>Datos Incorrectos</b>";
                Mensaje = "Los siguientes datos no son correctos: <br><br> " +
                        "<ul>";
                $.each(InputsConError, function (indice, elemento) {
                    Mensaje += "<li>" + MENSAJESdeErrorEmp[elemento] + "</li>";
                });
                Mensaje += "</ul>";
                MostarMensaje(iconoError, TituloMensaje, Mensaje);
            }
           
        }else {
            TituloMensaje = "<b>Campo Vacio</b>";
            Mensaje = "Hay un campo vacio, debe llenar todos los campos para poder continuar";
            MostarMensaje(iconoInfo,TituloMensaje,Mensaje);
        }
       
});   

//////////////////////// FORMULARIO DATOS ROL ////////////////////////
$("#bodyAdmin").on("click", "#btnGuardarRol", function (evento) {
    evento.preventDefault();
    // alert($("#nombreEmpleado").val() + " | " + $("#correoEmpleado").val() + " | " +$("#rolEmpleado").val())
    Datos = [$("#idRol").val(), $("#nombreRol").val(), $("#descripcionRol").val()];

    let InputsConError;
    let CampoVacio = BuscarVacioFormRol(Datos);
    if (CampoVacio) {
        InputsConError = ValidarInputsFormRol(Datos);
        if (InputsConError.length === 0) {
            $("#btnSubmitRol").trigger("click");  
            //MostarMensaje(iconoCorrecto, "TODO BIEN", "DATOS CORRECTOS");
        } else {
            TituloMensaje = "<b>Datos Incorrectos</b>";
            Mensaje = "Los siguientes datos no son correctos: <br><br> " +
                "<ul>";
            $.each(InputsConError, function (indice, elemento) {
                Mensaje += "<li>" + MENSAJESdeErrorRol[elemento] + "</li>";
            });
            Mensaje += "</ul>";
            MostarMensaje(iconoError, TituloMensaje, Mensaje);
        }

    } else {
        TituloMensaje = "<b>Campo Vacio</b>";
        Mensaje = "Hay un campo vacio, debe llenar todos los campos para poder continuar";
        MostarMensaje(iconoInfo, TituloMensaje, Mensaje);
    }

});

$("#bodyAdmin").on("click", "#btnActualizarRol", function (evento) {
    evento.preventDefault();
    // alert($("#nombreEmpleado").val() + " | " + $("#correoEmpleado").val() + " | " +$("#rolEmpleado").val())
    Datos = ["IDROL", $("#ActNombreRol").val(), $("#ActDescripcionRol").val()];

    let InputsConError;
    let CampoVacio = BuscarVacioFormRol(Datos);
    if (CampoVacio) {
        InputsConError = ValidarInputsFormRol(Datos);
        if (InputsConError.length === 0) {
            $("#btnSubmitRol").trigger("click");  
            //MostarMensaje(iconoCorrecto, "TODO BIEN", "DATOS CORRECTOS");
        } else {
            TituloMensaje = "<b>Datos Incorrectos</b>";
            Mensaje = "Los siguientes datos no son correctos: <br><br> " +
                "<ul>";
            $.each(InputsConError, function (indice, elemento) {
                Mensaje += "<li>" + MENSAJESdeErrorRol[elemento] + "</li>";
            });
            Mensaje += "</ul>";
            MostarMensaje(iconoError, TituloMensaje, Mensaje);
        }

    } else {
        TituloMensaje = "<b>Campo Vacio</b>";
        Mensaje = "Hay un campo vacio, debe llenar todos los campos para poder continuar";
        MostarMensaje(iconoInfo, TituloMensaje, Mensaje);
    }

});  
    

//////////////////////// VALIDACIÓN DE TECLAS EN LOS INPUTs FORMULARIO EMPLEADOS ////////////////////////    
 
$("#bodyAdmin").on("keypress","#nombreEmpleado",function (evento) {
            let tecla = String.fromCharCode(evento.which);

    if (!/^[a-zA-Z\sñÑáéíóúÁÉÍÓÚ]$/.test(tecla)) {
                evento.preventDefault();
            }     
    });

//////////////////////// VALIDACIÓN DE TECLAS EN LOS INPUTs FORMULARIO ROLES ////////////////////////
 
$("#bodyAdmin").on("keypress", "#idRol #nombreRol #descripcionRol",function (evento) {
            let tecla = String.fromCharCode(evento.which);

    if (!/^[a-zA-Z\sñÑáéíóúÁÉÍÓÚ]$/.test(tecla)) {
                evento.preventDefault();
            }     
    });



    


