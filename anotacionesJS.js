 // =============================================================================================
// 											ANIMACION
// =============================================================================================

// ---------------------------------- TOGGLE -----------------------------------------------
// El TOGGLE te permite mostrar u ocultar un div al hacer clic en el div
// fadeIn () se usa para mostrar en un elemento oculto de modo desvanecer .
// fadeOut () se usa para ocultar un elemento visible de modo desvanecer.
$("#idDiv").toggle(
	// el primer parametro es cuando se da el primer clic y e segundo al segundo click
	function(){
		$(".divmostrar").slideDown(300); //Se mostrara el div en modo deslizamiento en 0.3 segundos
		$(this).addClass('clase-agregada');// se agrega una clase clase-agregada a el #idDiv
	},
	function(){
		$(".divmostrar").fadeOut(600); //Se ocultara el div en modo desvanecer en 0.6 segundos
		$(this).removeClass('clase-agregada');// se  elimina la clase clase-agregada a el #idDiv
	}
);

// ---------------------------------- ANIMATE -----------------------------------------------
// La funcion ANIMATE te permite animar cualquier propiedad CSS que admita valores numéricos
$("#imagen").mouseover(function(){ // al ponel el mouse sobre la imagen, este tendra una opacidad de 100%
	$(this).animate({
		opacity: 1
	},250);
}).mouseout(function(){
	$(this).animate({
		opacity: 0.75
	},250);
});

$("#idDiv").toggle(
	// uniendo las dos funciones para asi poder utilizar en un menu
	function(){
		$('#menu').animate({
			left: 0
		});
	},
	function(){
		$('#menu').animate({
			left: -100
		});
	}
);

// Animate y funciones anidadas
// animate({'css a modificar'},'tiempo en milesegundos',funcion(){'se ejecuta cuando termina la animación'});

$("#foto").click(function(){
	$(this).animate({
			marginLeft : '150px',
			width : '300px',
			height :'300px;'
		},1500,function(){
			// El titulo saldra después de la animacion de la imagen, 
			//luego estará en pantalla por 1 seg y en seguida se ocultará
			// delay() es una pausa
			$('.titulo').fadeIn(1000).delay(1000).fadeOut(1000); 
		}
	); //termina animate
}); //termima la funcion click



// ----------------------------------  Animacion con el plugin easing(movimientos de animación) -----------------------
// hover(function(){
// 	'funcion que se ejecuta cuando el mouse esta sobre el objeto'
// },
// function(){
// 	'funcion que se ejecuta cuando el mouse deja el objeto'
// });
// stop() te permite parar una animación al culiminar esta, y asi que no sea acumulativos al pasar el mouse. $(this).stop().animate();

// ---------------------------------- Preloader imágenes rollover -----------------------------------------------
// Te permite programar una acción, hasta que las imagenes q necesites cargar, realmente esten cargadas en la pagina.
//each te permite ejecutar esa funcion para cada elemento img que exista en el body
$('img').each(function(){
	$(this).hover(cambiar, restaurar);
});
function cambiar(e){

}
function restaurar(e){

}


// ---------------------------------- OTROS -----------------------------------------------
// blur(function(){}); te permite gestionar el evento cuando se pierde el foco

$('#id').attr('src', 'newImage.jpg'); //Modificar un atributo

$('#logo').attr({src: 'logo.gif', alt: 'Logo de la empresa', width: '200px'});

let datoUpdate = dato.getAttribute("data-update");
document.getElementsByTagName("H1")[0].getAttribute("class");	
$(document).ready(function(){
  $("input").focus(function(){
    $("span").css("display", "inline").fadeOut(2000);
  });
});

$('input[type=checkbox]:checked').each(function() {	
	selectedItems.push($(this).val());	
});	


/*	animation: modal 2s 5s forwards;
	visibility: hidden;
	opacity: 0;   */
window.onresize = function() {
}	



// OTROS APUNTES
var selectCarousel = $('#carousel-1');
var selectInner = selectCarousel.find('.carousel-inner');

$('#btn-1').click( function() {
  selectInner.children('.item').remove();
  selectInner.append('<div class="item active"><img src="esika/img-pub.jpg" alt=""></div>');
  selectInner.append('<div class="item"><img src="natura/img-pub.jpg" alt=""></div>');

  selectCarousel.carousel();
})

// mdoificar url {} data
window.history.pushState({}, "Panel de Usuario", URLactual);

//eg 6 ``   or alt+96
//funciones basicas PHP
strtolower() // minúsculas
ucfirst() //primer caracter mayúsculas
ucwords() // Convierte a mayúsculas el primer caracter de cada palabra de una cadena
mb_strtoupper() // mayúsculas



//----------JS ------
parseInt()	//convertir a entero
.toFixed(2) //imprimir con 2 decimas un float
.splice(index, 1) // Eliminar el index del array
.toFixed(); // solo el entero
JSON.parse(text) // analiza una cadena de texto como JSON
JSON.stringify(obj) // convierte un objeto o valor de JavaScript en una cadena de texto JSON

test.toLowerCase()// convierte a minuscula
.toUpperCase() //convierte a mayuscula
td[name=col] // que sea igua
td[name^=col] // inicie
td[name$=col] //finalice
td[name*=col]  // contenga


prop('disabled',false)  // attr disabled