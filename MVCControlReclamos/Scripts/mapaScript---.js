
var lat;
var long;
var estaMarcado=false;
var marcador;
const mapaLimpio = 'afc5ac7bc0ab337';
const mapaSinIconos = '76a7bcf0ace62c6d';
var idDeMapa=mapaLimpio;
var poligono=[];
var nuevaForma=[];
var editando = false;
var puntosAdd=[];
var dibujandoZona=true;

function initMap() {
  const mapaSiniconos = new google.maps.StyledMapType(
    [
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
    { name: "Limpiar" }
  )
  const mapaLimpio = new google.maps.StyledMapType(
    [
      {
        "featureType": "landscape.man_made",
        "elementType": "geometry",
        "stylers": [
          {
            "visibility": "on"
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
    { name: "Mapa" }
  );
  var centroMapa = new google.maps.LatLng(39.862754476055386, -4.027336522173998);

  const map = new google.maps.Map(document.getElementById('map'), {
    center: centroMapa,
    zoom: 15,
    scaleControl: false,
    streetViewControl: false,
    rotateControl: false,
    fullscreenControl: false,
    clickableIcons: false,
    styles: styles["default"],
 });

  document.getElementById("ocultar").addEventListener("click", () => {
    map.setOptions({ styles: styles["hide"] });
  });

  document.getElementById("mostrar").addEventListener("click", () => {
    map.setOptions({ styles: styles["default"] });
  });

  document.getElementById("completarZona").addEventListener("click",()=>{
    nuevaForma=puntosAdd;
    puntosAdd=[];
    dibujandoZona=false;
    contorno.setPath(puntosAdd);
    poligonoP.setPath(nuevaForma);
  })
  
  document.getElementById("editarOn").addEventListener("click",()=>{
    poligonoP.setEditable(true);
    editando=true;
  })

  document.getElementById("editarOff").addEventListener("click",()=>{
    poligonoP.setEditable(false);
    poligono=poligonoP.getPath().getArray();
    editando= false;
  })

 google.maps.event.addListener(map, 'click', function(e) {
    lat = e.latLng.lat();
    long = e.latLng.lng();
    let posicion = new google.maps.LatLng(lat,long);
    colocarMarcador(posicion,map,estaMarcado);
    //para probar muestra la long y lat en un label
    document.getElementById("txt").textContent="latitud= "+lat+" Longitud= "+long;
    //probarAgregarPuntos en un array
    /**/ 
    if(dibujandoZona)
    {
      puntosAdd.push({lat:lat,lng:long});
      contorno.setPath(puntosAdd);
    }

  });

  const puntos = [
    { lat: 39.86755956411949, lng: -4.027223255719954 },
    { lat: 39.86884416285331, lng: -4.0212151075265945 },
    { lat: 39.8738176387755, lng: -4.028510716047102 },
  ];

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
    editable:  false,
    clickable:true,
    
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

function agregarpunto()
{

}

function colocarMarcador(pocision, map, marcado) {
 if(!marcado){
    marcador = new google.maps.Marker({
    position: pocision,
    map: map
  });
  estaMarcado = true;
}
  else{
    marcador.setPosition(pocision)
  }  
}