window.onload = load;
function load() {

}
function cargarModel() {
   /* for (i = 0; i < modelo.length; i++) {
        zonas.push(modelo[i])
    }*/
}
var lat;
var long;
var estaMarcado = false;
var poligono = [];
var nuevaForma = [];
var zonaDibujada;
var model = [];
var zonas = [];
var zonaSeleccionada = {};
var coloresZona = ["#d900ff", "#d900ff", "#d900ff", "#d900ff", "#d900ff", "#d900ff", "#d900ff"];

var idLabelNombre;
var idLabelNumero;

var puntosAdd = [];

var editar = false;
var editando = false;
var borrado = false;
var dibujandoZona = false;
var hayQueDibujar;


//modos Editor,Cliente,Administrador
var cliente = false;
var editor = false;
var administrador = false;


//Ajax

function cargarMapa() {
    setTimeout(cargar, 10);

}

function cargar() {
    try {
        document.getElementById("enviar").addEventListener("click", function () {
            mostrarErrores();
        })
        document.getElementById("nombrezonatxt").addEventListener("keyup", function () {
            mostrarErrores();
        })
    } catch {

    }

        $.ajax({
            contentType: "application/json",
            url: '/Zona/cargarZonasBD',
            type: 'GET',
            success: function (result) {
                zonas = result;
                initMap();
            },
            error: function (err) { console.error(err); }

        });
}

//Funcionq ue inicia le mapa
function initMap() {

    var centroMapa = new google.maps.LatLng(39.862754476055386, -4.027336522173998);
    var marcadorEditor = {
        path: "M-20,0a20,20 0 1,0 40,0a20,20 0 1,0 -40,0",
        //fillColor: '#FF0000',
        fillOpacity: 0,
        anchor: new google.maps.Point(0, 0),
        strokeWeight: 1,
        strokeColor: "#FF0000",
        scale: 0.5
    }

    const map = new google.maps.Map(document.getElementById('map'), {
        center: centroMapa,
        zoom: 15,
        scaleControl: false,
        streetViewControl: false,
        rotateControl: false,
        fullscreenControl: false,
        clickableIcons: false,
        styles: styles["default"],
        gestureHandling: 'greedy',
        scrollwheel: false
    });
    map.setTilt(0);

    map.setOptions({ draggableCursor: 'crosshair' });


    //controlles

    const abj = document.getElementById("abj");
    const izq = document.getElementById("izq");
    //CenterControl(centerControlDiv, map);
    map.controls[google.maps.ControlPosition.BOTTOM_CENTER].push(abj);
    map.controls[google.maps.ControlPosition.LEFT_CENTER].push(izq);

    var marcador = new google.maps.Marker({
        position: null,
        map: null,
    });


    

    document.getElementById("ocultar").addEventListener("click", () => {
        map.setOptions({ styles: styles["hide"] });
    });

    document.getElementById("mostrar").addEventListener("click", () => {
        map.setOptions({ styles: styles["default"] });
    });

    var clickeable;

    if (editor || cliente) {
        clickeable = false;
    }
    else if (administrador) {
        clickeable = true;
    }
    var numZona;
    try {
        numZona = document.getElementById("numZona").value
    } catch {
        numZona = null;
    }

    function buscarZona() {
        for (i = 0; i < zonas.length; i++) {
            if (zonas[i].numero == numZona) {
                return zonas[i];
            }
        }
    }

    if (numZona != null) {

        var zona = buscarZona();

        var zonap = new google.maps.Polygon({
            strokeColor: '#737373',
            strokeOpacity: 0.8,
            strokeWeight: 4,
            fillColor: '#737373',
            fillOpacity: 0.35,
            editable: false,
            clickable: false,
            path: colDtoPuntoToLatLng(zona.colDtoPunto),
            map: map,
        });
    }
    else {
        dibujarZonas();
    }

    function dibujarZonas() {
        for (let i = 0; i < zonas.length; i++) {
            var zonap = new google.maps.Polygon({
                strokeColor: zonas[i].color,
                strokeOpacity: 0.8,
                strokeWeight: 2,
                fillColor: zonas[i].color,
                fillOpacity: 0.35,
                editable: false,
                clickable: clickeable,
                path: colDtoPuntoToLatLng(zonas[i].colDtoPunto),
                map: map,
                id: i
            });

            google.maps.event.addListener(zonap, 'click', function (event) {
                console.log(this.id);
                try {
                    cargarZonaSeleccionada(this.id);
                }
                catch (error) {
                    console.error(error);
                }
                try {
                    cargarIdyNombreDeZonaSeleccionada(this.id)
                }
                catch (error) {
                    console.error(error);
                }
            });
        }
    }


    
    // modo editor
    if (editor) {
        hayQueDibujar = true;
        document.getElementById("dibujar").addEventListener("click", () => {
            if (hayQueDibujar) {
                dibujandoZona = true;
                marcador.setIcon(marcadorEditor)
                marcador.setMap(map);
                zonaDibujada = true;
            }
        })

        //btn completar zona
        document.getElementById("completarZona").addEventListener("click", () => {
            if (dibujandoZona) {
                nuevaForma = puntosAdd;
                puntosAdd = [];
                dibujandoZona = false;
                contorno.setPath(puntosAdd);
                poligonoP.setPath(nuevaForma);
                marcador.setMap(null);
                borrado = true;
                hayQueDibujar = false;
                document.getElementById("Puntos").value = JSON.stringify(exportarJsonPunto());
                console.log(JSON.stringify(exportarJsonPunto()));
                mostrarErrores();
            }
        })


        //btn habilitar edicion de zona
        document.getElementById("editarOn").addEventListener("click", () => {
            if (!dibujandoZona && !nuevaForma.length == 0) {
                poligonoP.setEditable(true);
                editando = true;
            }
        })
        //btn que termina la edicion
        document.getElementById("editarOff").addEventListener("click", () => {
            if (editando) {
                var editado = [];
                poligonoP.setEditable(false);
                var poligonoe = poligonoP.getPath().getArray();

                for (i = 0; i < poligonoe.length; i++) {
                    editado.push({
                        "lat": poligonoe[i].lat(),
                        "lng": poligonoe[i].lng()
                    })
                }
                nuevaForma = editado;
                setPuntosForm();
                editando = false;
                mostrarErrores();

            }
        })
        //btn para borrar el poligono correspondiente a la zona
        document.getElementById("borrar").addEventListener("click", () => {
            if (!dibujandoZona && zonaDibujada) {
                // dibujandoZona=true;
                borrarPoligono(poligonoP);
                borrado = true;
                marcador.setPosition(null);
                hayQueDibujar = true;
                setPuntosForm(borrado);
                nuevaForma = [];
                mostrarErrores();
            }


        });
        //btn de prueba que muestra "Zoonas guardadas"
        /*document.getElementById("").addEventListener("click",()=>{
        mostrarZonas(map);
      })*/
    }

    const contentString =
        '<div id="content">' +
        '<div id="siteNotice">' +
        "</div>" +
        '<h1 id="firstHeading" class="firstHeading">Uluru</h1>' +
        '<div id="bodyContent">' +
        "<p><b>Uluru</b>, also referred to as <b>Ayers Rock</b>, is a large " +
        "sandstone rock formation in the southern part of the " +
        "Northern Territory, central Australia. It lies 335&#160;km (208&#160;mi) " +
        "south west of the nearest large town, Alice Springs; 450&#160;km " +
        "(280&#160;mi) by road. Kata Tjuta and Uluru are the two major " +
        "features of the Uluru - Kata Tjuta National Park. Uluru is " +
        "sacred to the Pitjantjatjara and Yankunytjatjara, the " +
        "Aboriginal people of the area. It has many springs, waterholes, " +
        "rock caves and ancient paintings. Uluru is listed as a World " +
        "Heritage Site.</p>" +
        '<p>Attribution: Uluru, <a href="https://en.wikipedia.org/w/index.php?title=Uluru&oldid=297882194">' +
        "https://en.wikipedia.org/w/index.php?title=Uluru</a> " +
        "(last visited June 22, 2009).</p>" +
        "</div>" +
        "</div>";
    const infowindow = new google.maps.InfoWindow({
        content: contentString,
    });



    try {
        let latReclamo = document.getElementById("lat").innerHTML;
        let lngReclamo = document.getElementById("lng").innerHTML;
        var reclamoLtLn = new google.maps.LatLng(latReclamo, lngReclamo);

        var azul = "#0059ff";
        var azulO = "#00328f";
        var rojo = "#ff3300";
        var rojoO = "#991f00";
        var amarillo = "#ffdd00";
        var amarilloO = "#948000";
        var verde = "#91ff00";
        var verdeO = "#508c01";


        const svgMarker = {
            path: "m 14.943832,11.49484 c -3.561759,0 -6.4500663,2.88704 -6.4500663,6.448802 0,3.272544 1.5882903,5.140247 3.1821223,6.734071 3.212825,3.212823 2.168969,5.341817 3.267944,5.341817 1.098976,0 0.05376,-2.17054 3.225034,-5.341817 2.488228,-2.488228 3.22377,-4.95319 3.22377,-6.734071 0,-3.561762 -2.887042,-6.448802 -6.448804,-6.448802 z m 2.711301,6.448802 c 1.71e-4,1.497684 -1.213616,2.712038 -2.711301,2.712563 -1.498177,1.71e-4 -2.712731,-1.214385 -2.71256,-2.712563 4.32e-4,-1.485931 1.196427,-2.694869 2.703088,-2.70282 1.506663,-0.0081 2.720245,1.205631 2.720773,2.70282 z",
            fillColor: azul,
            fillOpacity: 1,
            strokeWeight: 2,
            strokeOpacity: 1,
            strokeColor: azulO,
            rotation: 0,
            scale: 2,
            anchor: new google.maps.Point(15, 30),
        };

        marcador.setIcon(svgMarker);
        marcador.setPosition(reclamoLtLn);
        marcador.setMap(map);
        map.setCenter(reclamoLtLn);

        marcador.addListener("click", () => {
            infowindow.open({
                anchor: marcador,
                map,
                shouldFocus: false,
            });
        });
            
    } catch {

    }

    // funcion encargada de tomar la long y la lati del mapa y de colocar un marcador
    google.maps.event.addListener(map, 'click', function (e) {
        //Toma de punto (longitud latitud)
        lat = e.latLng.lat();
        long = e.latLng.lng();
        let posicion = new google.maps.LatLng(lat, long);

        colocarMarcador(posicion, map, marcador);

        //para probar muestra la long y lat en un label
        try {
            var latLongTest = document.getElementById("latlong")
            latLongTest.textContent = "Latitud= " + lat + " Longitud= " + long;
        } catch (error) {
            console.error(error);
        }
        try {
            var latHTML = document.getElementById("latitud");
            var lonHtml = document.getElementById("longitud");
            latHTML.value = lat;
            lonHtml.value = long;
        }
        catch (error) {
            console.error(error);
        }

        //probarAgregarPuntos en un array
        if (dibujandoZona) {
            puntosAdd.push({ lat: lat, lng: long });
            contorno.setPath(puntosAdd);
        }
    });

    const contorno = new google.maps.Polyline({
        path: puntosAdd,
        editable: false,
        strokeColor: "#FF0000",
        strokeOpacity: 1.0,
        strokeWeight: 2,
        map: map,
    });

    contorno.setMap(map);

    const poligonoP = new google.maps.Polygon({
        strokeColor: "#FF0000",
        strokeOpacity: 0.8,
        strokeWeight: 2,
        fillColor: "#FF0000",
        fillOpacity: 0.35,
        editable: false,
        clickable: true,

    });
    poligonoP.setMap(map);
}



const styles = {
    default: [
        {
            "featureType": "landscape.man_made",
            "elementType": "geometry",
            "stylers": [
                {
                    "visibility": "off"
                }
            ]
        },
        {
            "featureType": "poi.attraction",
            "stylers": [
                {
                    "visibility": "on"
                }
            ]
        },
        {
            "featureType": "poi.business",
            "stylers": [
                {
                    "visibility": "on"
                }
            ]
        },
        {
            "featureType": "poi.government",
            "elementType": "geometry",
            "stylers": [
                {
                    "color": "#adbfff"
                }
            ]
        },
        {
            "featureType": "poi.government",
            "elementType": "labels",
            "stylers": [
                {
                    "visibility": "on"
                }
            ]
        },
        {
            "featureType": "poi.government",
            "elementType": "labels.icon",
            "stylers": [
                {
                    "color": "#5c7fff"
                }
            ]
        },
        {
            "featureType": "poi.government",
            "elementType": "labels.text.fill",
            "stylers": [
                {
                    "color": "#5c7fff"
                }
            ]
        },
        {
            "featureType": "poi.medical",
            "elementType": "geometry",
            "stylers": [
                {
                    "color": "#ff7575"
                }
            ]
        },
        {
            "featureType": "poi.medical",
            "elementType": "labels",
            "stylers": [
                {
                    "visibility": "on"
                }
            ]
        },
        {
            "featureType": "poi.medical",
            "elementType": "labels.icon",
            "stylers": [
                {
                    "color": "#fe2020"
                }
            ]
        },
        {
            "featureType": "poi.medical",
            "elementType": "labels.text.fill",
            "stylers": [
                {
                    "color": "#fe2020"
                }
            ]
        },
        {
            "featureType": "poi.park",
            "elementType": "geometry",
            "stylers": [
                {
                    "color": "#dbffbd"
                }
            ]
        },
        {
            "featureType": "poi.park",
            "elementType": "labels",
            "stylers": [
                {
                    "visibility": "on"
                }
            ]
        },
        {
            "featureType": "poi.park",
            "elementType": "labels.icon",
            "stylers": [
                {
                    "color": "#6acb1a"
                }
            ]
        },
        {
            "featureType": "poi.park",
            "elementType": "labels.text.fill",
            "stylers": [
                {
                    "color": "#6acb1a"
                }
            ]
        },
        {
            "featureType": "poi.place_of_worship",
            "stylers": [
                {
                    "visibility": "on"
                }
            ]
        },
        {
            "featureType": "poi.school",
            "elementType": "geometry",
            "stylers": [
                {
                    "color": "#ffda8a"
                }
            ]
        },
        {
            "featureType": "poi.school",
            "elementType": "labels",
            "stylers": [
                {
                    "visibility": "on"
                }
            ]
        },
        {
            "featureType": "poi.school",
            "elementType": "labels.icon",
            "stylers": [
                {
                    "color": "#ff8e24"
                }
            ]
        },
        {
            "featureType": "poi.school",
            "elementType": "labels.text.fill",
            "stylers": [
                {
                    "color": "#ff8e24"
                }
            ]
        },
        {
            "featureType": "poi.sports_complex",
            "stylers": [
                {
                    "visibility": "on"
                }
            ]
        },
        {
            "featureType": "transit",
            "stylers": [
                {
                    "visibility": "on"
                }
            ]
        }
    ],
    hide: [
        {
            "featureType": "landscape.man_made",
            "elementType": "geometry",
            "stylers": [
                {
                    "visibility": "off"
                }
            ]
        },
        {
            "featureType": "poi.attraction",
            "stylers": [
                {
                    "visibility": "off"
                }
            ]
        },
        {
            "featureType": "poi.business",
            "stylers": [
                {
                    "visibility": "off"
                }
            ]
        },
        {
            "featureType": "poi.government",
            "elementType": "geometry",
            "stylers": [
                {
                    "color": "#adbfff"
                }
            ]
        },
        {
            "featureType": "poi.government",
            "elementType": "labels",
            "stylers": [
                {
                    "visibility": "off"
                }
            ]
        },
        {
            "featureType": "poi.government",
            "elementType": "labels.icon",
            "stylers": [
                {
                    "color": "#5c7fff"
                }
            ]
        },
        {
            "featureType": "poi.government",
            "elementType": "labels.text.fill",
            "stylers": [
                {
                    "color": "#5c7fff"
                }
            ]
        },
        {
            "featureType": "poi.medical",
            "elementType": "geometry",
            "stylers": [
                {
                    "color": "#ff7575"
                }
            ]
        },
        {
            "featureType": "poi.medical",
            "elementType": "labels",
            "stylers": [
                {
                    "visibility": "off"
                }
            ]
        },
        {
            "featureType": "poi.medical",
            "elementType": "labels.icon",
            "stylers": [
                {
                    "color": "#fe2020"
                }
            ]
        },
        {
            "featureType": "poi.medical",
            "elementType": "labels.text.fill",
            "stylers": [
                {
                    "color": "#fe2020"
                }
            ]
        },
        {
            "featureType": "poi.park",
            "elementType": "geometry",
            "stylers": [
                {
                    "color": "#dbffbd"
                }
            ]
        },
        {
            "featureType": "poi.park",
            "elementType": "labels",
            "stylers": [
                {
                    "visibility": "off"
                }
            ]
        },
        {
            "featureType": "poi.park",
            "elementType": "labels.icon",
            "stylers": [
                {
                    "color": "#6acb1a"
                }
            ]
        },
        {
            "featureType": "poi.park",
            "elementType": "labels.text.fill",
            "stylers": [
                {
                    "color": "#6acb1a"
                }
            ]
        },
        {
            "featureType": "poi.place_of_worship",
            "stylers": [
                {
                    "visibility": "off"
                }
            ]
        },
        {
            "featureType": "poi.school",
            "elementType": "geometry",
            "stylers": [
                {
                    "color": "#ffda8a"
                }
            ]
        },
        {
            "featureType": "poi.school",
            "elementType": "labels",
            "stylers": [
                {
                    "visibility": "off"
                }
            ]
        },
        {
            "featureType": "poi.school",
            "elementType": "labels.icon",
            "stylers": [
                {
                    "color": "#ff8e24"
                }
            ]
        },
        {
            "featureType": "poi.school",
            "elementType": "labels.text.fill",
            "stylers": [
                {
                    "color": "#ff8e24"
                }
            ]
        },
        {
            "featureType": "poi.sports_complex",
            "stylers": [
                {
                    "visibility": "off"
                }
            ]
        },
        {
            "featureType": "transit",
            "stylers": [
                {
                    "visibility": "off"
                }
            ]
        }
    ],
};

function mostrarZonas(mapa) {

}

function borrarPoligono(poligono) {
    nuevaForma = [];
    poligono.setPath(nuevaForma);
}


function colocarMarcador(posicion, map, marcador) {
    if (cliente) {
        marcador.setIcon(null);
        marcador.setPosition(posicion)
        marcador.setMap(map)
        estaMarcado = true;
    }
    else {
        if (borrado && dibujandoZona) {
            marcador.setMap(map);
            marcador.setPosition(posicion)
            borrado = false;
        }
        else if (dibujandoZona) {
            marcador.setPosition(posicion)
        }

    }
}

function pasarPath_Array(path) {
    var puntosPath = []
    for (i = 0; i < path.length; i++) {
        let putno = path.getAt(i);
        puntosPath.push({ "lat": putno.lat(), "lng": putno.lng() })
    }
    return puntosPath;
}

function colDtoPuntoToLatLng(puntos) {
    let long;
    let lati;
    let latLng = [];
    for (e = 0; e < Object.keys(puntos).length; e++) {
        long = puntos[e].longitud;
        lati = puntos[e].latitud;
        latLng.push({ "lat": lati, "lng": long })
    }
    return latLng;
}

function cargarZonaSeleccionada(numeroZona) {
    zonaSeleccionada = zonas[numeroZona - 1]
    let numeroZ = document.getElementById(idLabelNumero);
    let nombreZ = document.getElementById(idLabelNombre);
    numeroZ.innerHTML = zonaSeleccionada.numero;
    nombreZ.innerHTML = zonaSeleccionada.nombre;
}

function exportarJsonPunto() {
    let lon, lat;
    let exportar = [];
    for (i = 0; i < nuevaForma.length; i++) {
        lon = nuevaForma[i].lng;
        lat = nuevaForma[i].lat;
        exportar.push({ "longitud": lon, "latitud": lat });
    }

    return exportar;
}

function cargarIdyNombreDeZonaSeleccionada(numeroZona) {
    try {
            let nombreZonaHTML = document.getElementById("nombreZona");
            nombreZonaHTML.value = zonas[numeroZona].nombre;
        try {
            let numeroZonaHTML = document.getElementById("numeroZona");
            numeroZonaHTML.value = zonas[numeroZona].numero;
        } catch (error) {
            console.error(error);
        }
    } catch (error) {
        console.error(error);
    }
    
}

function setIdsLatLong(idNombre, idNumero) {
    idLabelNombre = idNombre;
    idLabelNumero = idNumero;
}

function setCliente() {
    cliente = true;
}

function setPuntosForm(borrado) {
    if (borrado) {
        document.getElementById("Puntos").value ="";
    } else {
        document.getElementById("Puntos").value = JSON.stringify(exportarJsonPunto());
        console.log(JSON.stringify(exportarJsonPunto()));
    }
   
}



function mostrarErrores() {
    var form = $("#formulario");
    form.valid();
    setTimeout(validar, 20);
      function validar() {
        if (!form.valid()) {
            $("#errores").show();
        }
        else {
            $("#errores").hide();
        }
    }
}



