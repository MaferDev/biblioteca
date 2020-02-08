const dynamic = 'hobbies'

const user = {
    name:"Ed",
    email:"developer@example.com",
    [dynamic]:"sleeping"
}

//console.log(user)

const userArray = Object.keys(user) // Obtienes las llaves del objeto
const userArray2 = Object.values(user) // Obtienes las llaves del objeto
//console.log(userArray2)


/********PERFORMANCES*******/
let startAt = performance.now();

for(let i=0;i<21920;i++){
    console.log(i)
}

let endAt = performance.now();
console.log(`${endAt - startAt} took milliscensds to exouigew`)

//====================
//ASYNC && AWAIT
//Te permite manejar las promesas
let data={};
function resolveAfter2Seconds() {
  return new Promise(resolve => {
    setTimeout(() => {
    	data={name:'fer',lastName:'hs'}
      	resolve('resolved');
    }, 3000);
  });
}

async function asyncCall() {
  console.log('calling');
  var result = await resolveAfter2Seconds();
  console.log(result);
  console.log(data);
  
}

asyncCall();