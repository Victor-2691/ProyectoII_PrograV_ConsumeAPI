


function Alertar(mensaje) {
    alert(mensaje)
}

function CambiarDiv() {
    box = document.getElementById('divTabla')[0];
    box.style.width = '100px';
    box.style.height = '100px';
}


function Confirmar() {


    if (confirm("Esta seguro que desea eliminar este registro ?") == true) {// true indica yes

        /*.getElementById se encarga de obtener los id html en aspx 
         valor (es el id del HiddenField de c#) */

        /*Se le asigna el valor con value*/
        document.getElementById('Codi').value = 'si';
    }
    else {// false incia not
    }
}

function regresar() {

    window.location("~/Paginas/Cursos.aspx")
}
