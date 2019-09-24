<?php
	$correos=$_POST['correos'];

	$array_correos=explode(";",$correos);
	$correctos=0;
	$incorrectos=0;
	$cantidad=count($array_correos);
	
	for($i=0;$i<$cantidad;$i++){
		if (comprobar_email($array_correos[$i])){
      		//echo 'El email introducido es correcto!'.$array_correos[$i]."<br>";
			$correctos1[]=$array_correos[$i];
			$correctos++;
			
		}else{
      		//echo 'El email introducido NO es correcto!'.$array_correos[$i]."<br>";
			$incorrectos1[]=$array_correos[$i];
			$incorrectos++;
		}
	}
	
	if($cantidad==$correctos){
		echo "Enviando notificacion a $correctos correos<br><br>";
		for($i=0;$i<$correctos;$i++){
			echo $correctos1[$i]."<br>";
		}
	}
	else{
		echo "Confirmar envio<br>Los siguientes correos no son validos:<br>";
		for($i=0;$i<$incorrectos;$i++){
			echo $incorrectos1[$i]."<br>";
		}
	}



	function comprobar_email($email) {
    	return (filter_var($email, FILTER_VALIDATE_EMAIL)) ? 1 : 0;
	}

?>