const EXP_REG_CORREO = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
const EXP_REG_NOMBRE = /^[a-zA-Z\sñÑáéíóúÁÉÍÓÚ]{10,50}$/;
const EXP_REG_NOMBRE_ROL = /^[a-zA-Z\sñÑáéíóúÁÉÍÓÚ]{5,25}$/;
const EXP_REG_DESC_ROL = /^[a-zA-Z\sñÑáéíóúÁÉÍÓÚ]{10,250}$/;
const EXP_REG_ID_ROL = /^[a-zA-Z]{4,6}$/;



const MENSAJESdeErrorEmp = [
    "<b>Nombre</b> no válido. <br> Sólo debe incluir letras y tener entre 10 y 50 caracteres. <hr>",
    "<b>Correo electronico</b> no válido. <br> Se debe respetar el siguiente formato: correoo@ejemplo.com"
];

const MENSAJESdeErrorRol = [
    "<b>ID</b> no válido. <br> Sólo debe incluir letras y tener entre 4 y 6 caracteres. <hr>",
    "<b>Nombre</b> no válido. <br> Sólo debe incluir letras y tener entre 5 y 25 caracteres. <hr>",
    "<b>Descrpción</b> no válida. <br> No puede contener caracteres especiales."
];

