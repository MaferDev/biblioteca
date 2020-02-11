const users=[
    "User1",
    "User2",
    "User3",
    "User4",
    "User5",
    "User6",
    "User5"
]

// Copia valores del array sin duplicado
const unique = Array.from(new Set(users)) 
const c = (val)=> console.log(val)

c(unique)


//===============================================
//AGREGAR Y QUITAR ELEMENTOS DE UN ARRAY
//===============================================

// Agrega un elemento en la ultima posición
array.push(6)

// Elimina el ultimo elemento
array.pop() 

//Agrega un elemento en la primera posición del array
array.unshift('Nuevo') 

// Elimina el primer elemento
array.shift() 

// Elimina el primer elemento
// splice (posición, item a eliminar, 'item a agregar')
array.splice(2,1,'Hola') 

// Obtiene un nuevo array con los datos obtenidos
// slice (posición inicial, posición final)
c(array.slice(2,5) )

//Obtiene los ultimos 3 valores del array
c(unique.slice(-3)) 

//===============================================
//RECORRER ARRAY
//===============================================
// La funcion trabaja por par:
//.reduce()  -> Reduce los elementos a un solo valor

c('Reduce:')
let arrayR=[0,2,5,6,7]
let sumaArray = arrayR.reduce((acumulador,valor)=>acumulador+valor)
c('suma:',sumaArray)

//========================================================
// include verifica si el elemento existe en el arreglo
let arr=[2,5,7,9];
let ExisteEnArray = arr.includes(5)
c("Existe en Array: ",ExisteEnArray) // true/false

//========================================================
//concat: concatena dos arrays
const array1=[1,2,3]
const array2=['a','b','c']
const Array12=array1.concat(array2)
c("Array concatenado: ",Array12)

//========================================================
//.entries() retorna un nuevo objeto con clave/valor
const array=[0,2,5,6,7]
const iterator=array.entries()
c("Array para iterador:",array)
c(iterator.next().value)
c(iterator.next().value)
c(iterator.next().value)

//========================================================
//.map()  -> transforma todos los elementos de un array en base a una condición
const arrayCambiado = ar1.map(el=>2*el)

//========================================================
//.filter()  -> Filtra los elementos que cumplan con la condición
const arrayfiltrado = ar1.filter(el=>el>5)


//===============================================
//OBTENER UN OBJETO NUEVO CON VALORES ÚNICOS DEL ARRAY
//===============================================
const removeDuplicate = arr=>[...new Set(arr)] // Remueve duplicado

const ar1 = ['juan','sandro','Daniela','Lidia','Carlos']

//Buscar si por lo menos un elemento cumple con una condición 
c(ar1.some(el=>el=='Luis')) // true
c(ar1.some(el=>el=='Fer')) // false

//========================================================
//every() verifica si todos los valores cumplen una condición true/false
isBelowTheshold = (val) => val<40;
let arrayEveryTrue = [1,30,35,39];
let arrayEveryFalse = [5,50]
c("Los valores que cumplen la función: ",arrayEveryTrue.every(isBelowTheshold))//true
c(arrayEveryFalse.every(isBelowTheshold))//false

//========================================================
//filter() crea un array solo con valores que cumplan la condición
esMayorTres=(val)=>val>3
const arrayTemp=[0,2,5,6,7]
const result=arrayTemp.filter(val=>val<5)
const result2=arrayTemp.filter(esMayorTres)
c(result) // [0,2]
c(result2) // [5,6,7]


//===============================================
//BUSCAR ELEMENTOS
//===============================================

//========================================================
//Find, busqueda en un array o objeto
const cursos=['java','c#','php','go'];

const persona = [
	{
		nombre:'ana',
		edad:15
	},
	{
		nombre:'Andres',
		edad:20
	}
]
let BuscarPersona = persona.find(per=>per.nombre=='Andres')
let BuscarCurso = cursos.find(curso=>curso=='java')
c(BuscarPersona)
c(BuscarCurso)
//========================================================
//PADEND && PADSTAR
let example ='Dyland';
//padStar : completa con los caracteres a, hasta llegar al 10 en total
c(example.padStart(10,'abc'));
//padEnd: completa al final
c(example.padEnd(8,"xs"));

//========================================================
//SET: te permite almacenar valores únicos de cualquier tipo
const variable=new Set([1,2,3,3,3,3])
variable.add(6)
variable.delete(1)
c(variable.size)
c(variable)

//========================================================
//FUNCIONES CON PARAMETRO SPREAD (Distribuido)
function ComprarCursos(nombre, precio, cantidad){
	c(nombre,precio,cantidad)
}

let curso=['java',150,2]
ComprarCursos(...curso)

//FUNCIONES CON PARAMETRO AGRUPADO
function MostrarCursos(...curso){
	c(curso)
}

MostrarCursos('c++','java','go','php')

//========================================================
yepnope
//===========================================

yepnope({
  // permite cargar directamente un recurso(s) independientemente de los tests.
  load : 'http:/­/code.jquery.com/jquery-1.5.0.js',
 
  // la condición, el objeto que evaluamos.
  test : window.JSON,
 
  // si la condición no se cumple. cargamos la alternatica.
  nope : 'json2.js',
 
  // When json2.js is loaded => función que se ejecuta una vez que los recursos han sido cargados.
  callback : function(){
    console.log( 'JSON not present by default but now is ready to use' );
  },
 
  // When the test is complete (both true or false) 
  //(función que se ejecuta una vez la evaluación ha finalizado sin que necesariamente se haya cargado un recurso.)
  complete : function(){
    var data = window.JSON.parse( '{ "foo" : "Hello World" }' );
  }
});


– test: la condición, el objeto que evaluamos.
– yep: si la condición se cumple, cargamos el recurso(s) asociado.
– nope: si la condición no se cumple. cargamos la alternatica.


//========================================================

//========================================================

//========================================================
//========================================================

//========================================================
//========================================================

//========================================================



