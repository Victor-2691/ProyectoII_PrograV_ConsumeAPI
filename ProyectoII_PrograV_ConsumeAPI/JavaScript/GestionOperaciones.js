* Esta funcion se encarga de mostrar la pantalla se confirmacion al eliminar un dato * /
function Conformar() {

    /*El objeto confirm de javascrip es quien se encarga de mostrar la venta*/

    if (confirm("Esta seguro que desea eliminar este registro ?") == true) {// true indica yes

        /*.getElementById se encarga de obtener los id html en aspx 
         valor (es el id del HiddenField de c#) */

        /*Se le asigna el valor con value*/
        document.getElementById('valor').value = 'si';
    }
    else {// false incia not
        document.getElementById('valor').value = 'no';
    }
}

function Alertar(mensaje) {
    alert(mensaje)
}

function CambiarDiv() {
    box = document.getElementById('divTabla')[0];
    box.style.width = '100px';
    box.style.height = '100px';
}


