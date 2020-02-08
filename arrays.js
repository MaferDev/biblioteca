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
console.log(unique)

//========================================================

//Obtiene los ultimos 3 valores del array
console.log(unique.slice(-3)) 
//========================================================

// La funcion trabaja por par:
console.log('Reduce:')
let arrayR=[0,2,5,6,7]
let suma = arrayR.reduce((acumulador,valor)=>acumulador+valor)
console.log('suma:',suma)

//========================================================
// include verifica si el elemento existe en el arreglo
let arr=[2,5,7,9];
let ExisteEnArray = arr.includes(5)
console.log("Existe en Array: ",ExisteEnArray) // true/false

//========================================================
//concat: concatena dos arrays
const array1=[1,2,3]
const array2=['a','b','c']
const Array12=array1.concat(array2)
console.log("Array concatenado: ",Array12)

//========================================================
//.entries() retorna un nuevo objeto con clave/valor
const array=[0,2,5,6,7]
const iterator=array.entries()
console.log("Array para iterador:",array)
console.log(iterator.next().value)
console.log(iterator.next().value)
console.log(iterator.next().value)

//========================================================
//every() verifica si todos los valores cumplen una condición true/false
isBelowTheshold = (val) => val<40;
let arrayEveryTrue = [1,30,35,39];
let arrayEveryFalse = [5,50]
console.log("Los valores que cumplen la función: ",arrayEveryTrue.every(isBelowTheshold))//true
console.log(arrayEveryFalse.every(isBelowTheshold))//false

//========================================================
//filter() crea un array solo con valores que cumplan la condición
esMayorTres=(val)=>val>3
const arrayTemp=[0,2,5,6,7]
const result=arrayTemp.filter(val=>val<5)
const result2=arrayTemp.filter(esMayorTres)
console.log(result) // [0,2]
console.log(result2) // [5,6,7]

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
console.log(BuscarPersona)
console.log(BuscarCurso)
//========================================================
//PADEND && PADSTAR
let example ='Dyland';
//padStar : completa con los caracteres a, hasta llegar al 10 en total
console.log(example.padStart(10,'abc'));
//padEnd: completa al final
console.log(example.padEnd(8,"xs"));

//========================================================
//SET: te permite almacenar valores únicos de cualquier tipo
const variable=new Set([1,2,3,3,3,3])
variable.add(6)
variable.delete(1)
console.log(variable.size)
console.log(variable)

//========================================================
//FUNCIONES CON PARAMETRO SPREAD (Distribuido)
function ComprarCursos(nombre, precio, cantidad){
	console.log(nombre,precio,cantidad)
}

let curso=['java',150,2]
ComprarCursos(...curso)

//FUNCIONES CON PARAMETRO AGRUPADO
function MostrarCursos(...curso){
	console.log(curso)
}

MostrarCursos('c++','java','go','php')

//========================================================

//========================================================
//========================================================

//========================================================
//========================================================

//========================================================
//========================================================

//========================================================



