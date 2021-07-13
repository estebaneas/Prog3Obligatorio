

function setColRecJava(item) {
    setColRecJava = item;
}


/*function cargarReclamos(colRecjava,targetID, pagActual, cantPorPag, numZona, numCuadrilla, ini, fin, estado) {

    var filtro = [{
        "estado": estado,
        "paginaActual": pagActual,
        "cantPorPag": cantPorPag,
        "numZona": numZona,
        "numCuadrilla": numCuadrilla,
        "ini": ini,
        "fin": fin,
        "targetID": targetID,
        "colReclamos": colRecjava
    }];
    


    $.ajax({
        url: '/Reclamo/mostrarReclamos?targetID=' + targetID + '&pagActual=' + pagActual + '&cantPorPag=' + cantPorPag + '&numZona=' + numZona + '&numCuadrilla=' + numCuadrilla + '&ini=' + ini + '&fin=' + fin + '&estado=' + estado,
        type: 'GET',
        success: function (result) {
            document.getElementById(targetID).innerHTML = result;
        },
        error: function (err) { console.log(err); }

    });

}
*/

function cargarReclamos(colRecjava, targetID, pagActual, cantPorPag, btnTarget, colRecJavVar, numZona, numCuadrilla, ini, fin, estado) {

    var filtro = {
        estado: estado,
        paginaActual: pagActual,
        cantPorPag: cantPorPag,
        numZona: numZona,
        numCuadrilla: numCuadrilla,
        ini: ini,
        fin: fin,
        targetID: targetID,
        colReclamos: colRecjava,
        colRelJavVar: colRecJavVar,
        BtnTarget: btnTarget,
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
