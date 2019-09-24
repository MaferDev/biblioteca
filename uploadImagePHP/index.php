<!DOCTYPE html>
<html>
<head>
	<title>websoquest</title>	
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
<script src="https://ajax.googleapis.com/ajax/libs/jquery/2.2.4/jquery.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>

<style type="text/css">
.img-user{
	text-align: center;
    margin-top: 40px;
}
.img-user .foto{
    display: inline-block;
    overflow: hidden;
	width: 180px;	
    height: 180px;
	border-radius: 15px;    
}	

#input-foto{
 width: 0.1px;
 height: 0.1px;
 opacity: 0;
 overflow: hidden;
 position: absolute;
 z-index: -1;
 }

label[for="input-foto"] {
	height: 38px;
    font-weight: bold;
    color: #fff;
    background-color: #007bff;
    display: inline-block;
    transition: all .5s;
    cursor: pointer;
    padding: 5px 11px !important;
    width: fit-content;
    text-align: center;
    border-radius: 5px;
}

</style>	

<script type="text/javascript">
	let url="http://localhost/prueba/foto/";
$(document).ready(function(){ 
	$('#input-foto').change(function(){
		addFoto(this); 
	});
});
function addFoto(input) {
	if (input.files && input.files[0]) {
		var reader = new FileReader();
		reader.onload = function (e) {
			$('#foto-user').attr('src', e.target.result);
		}
		reader.readAsDataURL(input.files[0]);
		$('#btn-cambiar-foto').prop('disabled', false);
	}
}
	
function guardarFoto(){
	var canvas = document.createElement("canvas");
	var imageUser = document.getElementById("foto-user");
	canvas.width = 200;
	canvas.height = 200;
	var ctx = canvas.getContext("2d");
	ctx.drawImage(imageUser, 0, 0,200,200);
	var dataURL = canvas.toDataURL("image/jpeg");

    $.ajax({
		 url:"uploadImg.php",
		 data:{ fotoUser: dataURL },
		 type:"post",
		 complete:function(){
			console.log("Todo en orden");
			$('#btn-cambiar-foto').prop('disabled', true);
		 }
    });
}	
</script>

</head>
<body>
				<div class="img-user">
					<div class="foto">
						<img class="w-100 h-100" id="foto-user" src="http://localhost/revikitV1/images/user/0.jpg" />
					</div>
					<div class="goup-img-user">
						<span>
							<input name="input-foto" class="form-control-file" id="input-foto" type="file" accept=".jpg, .jpeg, .png">
						</span>
						<label for="input-foto">
							<span>...</span>
						</label>
						<button type="button" class="btn btn-primary" id="btn-cambiar-foto" onclick="guardarFoto()" disabled="true">Guardar Foto</button>
					</div>						
				</div>	

<script type="application/javascript">
jQuery('input[type=file]').change(function(){
 var filename = jQuery(this).val().split('\\').pop();
 var idname = jQuery(this).attr('id');
 console.log(jQuery(this));
 console.log(filename);
 console.log(idname);
 jQuery('span.'+idname).next().find('span').html(filename);
});
</script>
</body>
</html>
