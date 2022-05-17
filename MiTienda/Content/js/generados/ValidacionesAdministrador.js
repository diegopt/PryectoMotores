
function BuscarVacioFormEmp(Datos) {
    let X = 0;
    $.each(Datos, function (indice, elemento) {
        if (elemento.length === 0) {
            X++;
        }
    });
    if (X === 0) {
        return true;
    } else {
        return false;
    }
}
function ValidarInputsFormEmp(Datos) {
    let Indices_InputsConErrorFormEmp=[];
    $.each(Datos, function (indice, elemento) {

        if (!ValidaDatosFormEmp(indice, elemento)) {
            Indices_InputsConErrorFormEmp.push(indice);
        }

    });
    return Indices_InputsConErrorFormEmp;
}

function ValidaDatosFormEmp(indice, dato) {
    let valido;
    switch (indice) {
        case 0:
            valido = EXP_REG_NOMBRE.test(dato);
            ModificaInputsFormEmp(valido, $("#nombreEmpleado"));
            break;
        case 1:
            valido = EXP_REG_CORREO.test(dato);
            ModificaInputsFormEmp(valido, $("#correoEmpleado"));
            break;
        case 2:
            valido = true;
            ModificaInputsFormEmp(valido, $("#rolEmpleado"));
            break;

    }
    return valido;
}


function BuscarVacioFormRol(Datos) {
    let X = 0;
    $.each(Datos, function (indice, elemento) {
        if (elemento.length === 0) {
            X++;
        }
    });
    if (X === 0) {
        return true;
    } else {
        return false;
    }
}
function ValidarInputsFormRol(Datos) {
    let Indices_InputsConErrorFormRol=[];
    $.each(Datos, function (indice, elemento) {

        if (!ValidaDatosFormRol(indice, elemento)) {
            Indices_InputsConErrorFormRol.push(indice);
        }

    });
    return Indices_InputsConErrorFormRol;
}

function ValidaDatosFormRol(indice, dato) {
    let valido;
    switch (indice) {
        case 0:
            valido = EXP_REG_ID_ROL.test(dato);
            ModificaInputsFormEmp(valido, $("#idRol"));
            break;
        case 1:
            valido = EXP_REG_NOMBRE_ROL.test(dato);
            ModificaInputsFormEmp(valido, $("#nombreRol"));
            break;
        case 2:
            valido = EXP_REG_DESC_ROL.test(dato);
            ModificaInputsFormEmp(valido, $("#descripcionRol"));
            break;

    }
    return valido;
}





function ModificaInputsFormEmp(valido, elemento){
    if(valido){
    elemento.parent("div").removeClass("has-error");    
    }else{
    elemento.parent("div").addClass("has-error");    
    }
    
}