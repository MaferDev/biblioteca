let listImgResult = []; // Lista de imagenes de resultado

$(document).ready(function () {
    $('.imgResultado input').change(function(){
        let numImg= listImgResult.length
        if (this.files && this.files[0]) {
            var reader = new FileReader()
            reader.onload = function (e) {  
                if(numImg!=3){
                    listImgResult.push(e.target.result)
                    printImg()
                }
            }
            reader.readAsDataURL(this.files[0])  
        }              
    }) 

})
function printImg() {
    $(`.listImagenes`).empty()
    listImgResult.forEach((element,index)=>{
        // console.log(element,index);    
        let img=`<div class="col-12 col-sm-6 col-md-4 text-center">
                    <div class="imagenResultado mb-2 mr-2">
                        <img id="imgResultado${index}" src="${element}" />                        
                    </div>
                    <div><button type="button" class="btnDeleteImg btnGray" data-id="${index}" onclick="EliminarFoto(this)">
                                <span>Eliminar</span>
                    </button></div>
                </div>`;
        $('.listImagenes').append(img)
    })
     
}
function EliminarFoto(element){
    let index=$(element).data('id');    
    listImgResult.splice(index, 1)
    printImg();
}