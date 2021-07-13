

function setColRecJava(item) {
    setColRecJava = item;
}

function cargarReclamos(colRecjava, targetID, pagActual, cantPorPag, btnTarget, colRecJavVar, numZona, numCuadrilla, ini, estado,tipo,buscador) {

    if (buscador) {
        try {
            ini = document.getElementById("fecha").value;
            estado = document.getElementById("Estado").value;
            numZona = document.getElementById("Zona").value;
            numCuadrilla = document.getElementById("Cuadrilla").value;
            tipo= document.getElementById("TipoReclamo").value;
            cantPorPag = document.getElementById("paginas").value;

            document.getElementById("PaginasRes").value = document.getElementById("paginas").value;
            document.getElementById("FechaRes").value = document.getElementById("fecha").value;
            document.getElementById("EstadoRes").value = document.getElementById("Estado").value;
            document.getElementById("TipoReclamoRes").value = document.getElementById("TipoReclamo").value;
            document.getElementById("ZonaRes").value = document.getElementById("Zona").value;
            document.getElementById("CuadrillaRes").value = document.getElementById("Cuadrilla").value;
        } catch {

        }
    }
    else {
        ini = document.getElementById("FechaRes").value;
        estado = document.getElementById("EstadoRes").value;
        tipo = document.getElementById("TipoReclamoRes").value;
        numZona = document.getElementById("ZonaRes").value;
        numCuadrilla = document.getElementById("CuadrillaRes").value;
    }

    if (!buscador && cantPorPag==null) {
        cantPorPag = document.getElementById("PaginasRes").value;
    }


    var filtro = {
        estado: estado,
        paginaActual: pagActual,
        cantPorPag: cantPorPag,
        numZona: numZona,
        numCuadrilla: numCuadrilla,
        ini: ini,
        targetID: targetID,
        colReclamos: colRecjava,
        colRelJavVar: colRecJavVar,
        BtnTarget: btnTarget,
        tipo: tipo
    };



    $.ajax({
        url: '/Reclamo/mostrarReclamos',
        type: 'POST',
        data: filtro,
        success: function (result) {
            document.getElementById(targetID).innerHTML = result;
           
        },
        error: function (err) { console.log(err); }

    });

}
