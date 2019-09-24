<?php 
if(isset($_POST['fotoUser'])){
	$foto = $_POST['fotoUser'];
	$id=1;
	$archivo=$id;
	$carpeta = 'img/';
	$data = base64_decode(preg_replace('#^data:image/\w+;base64,#i', '', $foto));	
	$filepath = $carpeta."/".$archivo.".jpg"; 
	file_put_contents($filepath,$data);	
}
?>