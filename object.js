//ASSIGN 
//Te permite unir ubjetos a uno solo para poder acceder a ellos
const cuentas={cliente:'Fernanda'}
const alimentos={nombre:'ceviche',cantidad:2}
Object.assign(cuentas,alimentos)
console.log(cuentas)


//Metodos estáticos
// Ya no es necesario crear el objeto new Operaciones()
class Operaciones{
	static sumar(x,y){
		return x+y;
	}
	static restar(x,y){
		return x-y;
	}
}
console.log("Sumar: ",Operaciones.sumar(10,20))
console.log("Restar: ",Operaciones.restar(50,20))
//==============================================
//Clases + herencias
class Persona{
	constructor(nombre,edad){
		this.nombre=nombre
		this.edad=edad
	}

	getNombre(){
		return this.nombre
	}

	getEdad(){
		return this.edad
	}

	setNombre(nom){
		this.nombre=nom
	}

	setEdad(edad){
		this.edad=edad
	}
}

class Profesor extends Persona{
	constructor(nombre,edad,codigo){
		super(nombre,edad)
		this.codigo=codigo
	}
}

let profesor1=new Profesor('Andres',28,'65875')
console.log(profesor1)
console.log("Nombre del profesor: ",profesor1.getNombre())

//=====================================================
let obUser={
    dni:25898875,
    nombre:'juan',
    sexo:'M',
    edad:20
  }
  
  c(obUser)
  
  delete obUser.edad // Elimina una propiedad  - true
  
  c(obUser)
  
  obUser['estado'] = 'feliz'  // se agrega propiedades