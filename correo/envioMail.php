<?php

	require('conexion/conexion.php');
    
    if(isset($_GET['Reclamaciones'])){	

        $estado = 0;

    	$UsuarioTipoDocumento = $_POST['UsuarioTipoDocumento'];
    	$UsuarioNumeroDocumento = $_POST['UsuarioNumeroDocumento'];
    	$UsuarioApePaterno = $_POST['UsuarioApePaterno'];
    	$UsuarioApeMaterno = $_POST['UsuarioApeMaterno'];
    	$UsuarioNombre = $_POST['UsuarioNombre'];
    	$UsuarioDireccion = $_POST['UsuarioDireccion'];
    	$UsuarioTelefono = $_POST['UsuarioTelefono'];
    	$UsuarioEmail = $_POST['UsuarioEmail'];
        $DetalleIncidente = $_POST['DetalleIncidente'];	 
        $RespuestaReclamo = $_POST['EnviarQueja'];	     
        
    	$UsuarioTerceroTipoDocumento = $_POST['UsuarioTipoDocumento'];
    	$UsuarioTerceroNumeroDocumento = $_POST['UsuarioNumeroDocumento'];
    	$UsuarioTerceroApePaterno = $_POST['UsuarioApePaterno'];
    	$UsuarioTerceroApeMaterno = $_POST['UsuarioApeMaterno'];
    	$UsuarioTerceroNombre = $_POST['UsuarioNombre'];
    	$UsuarioTerceroDireccion = $_POST['UsuarioDireccion'];
    	$UsuarioTerceroTelefono = $_POST['UsuarioTelefono'];
        $UsuarioTerceroEmail = $_POST['UsuarioEmail'];
        
		$sql = "INSERT INTO `Libro_reclamaciones`(`ApePatUsuarioReclamo`, `ApeMatUsuarioReclamo`, `NombreUsuarioReclamo`, `TipoDocUsuarioReclamo`, `NroDocumentoUsuarioReclamo`, `DomicilioUsuarioReclamo`, `TelefonoUsuarioReclamo`, `EmailUsuarioReclamo`, `FechaReclamo`, `ApePatUsuarioTercero`, `ApeMatUsuarioTercero`, `NombreUsuarioTercero`, `TipoDocUsuarioTercero`, `NroDocumentoUsuarioTercero`, `DomicilioUsuarioTercero`, `TelefonoUsuarioTercero`, `EmailUsuarioTercero`, `DescripcionReclamo`, `RespuestaReclamo`) VALUES ('$UsuarioApePaterno','$UsuarioApeMaterno','$UsuarioNombre','$UsuarioTipoDocumento','$UsuarioNumeroDocumento','$UsuarioDireccion','$UsuarioTelefono','$UsuarioEmail',now(),'$UsuarioTerceroApePaterno','$UsuarioTerceroApeMaterno','$UsuarioTerceroNombre','$UsuarioTerceroTipoDocumento','$UsuarioTerceroNumeroDocumento','$UsuarioTerceroDireccion','$UsuarioTerceroTelefono','$UsuarioTerceroEmail','$DetalleIncidente','$RespuestaReclamo')";
                         
        $resultado=consultaBD_Ud($sql,'insert');
        
		if($resultado=='successfully')  {
			$estado='ok';
		}

		if($estado=='ok'){
            //================================================================
            //===================== Envio de Mail        =====================
            //================================================================
            // Definir el correo de destino:
            $Nombre_completo_cliente=$UsuarioNombre." ".$UsuarioApePaterno." ".$UsuarioApeMaterno;

            $dest_nombre = "Silvia Zambrano";
            $dest = "disenador.web@suizalab.com";

            // Estas son cabeceras que se usan para evitar que el correo llegue a SPAM:
            $headers = "From: $Nombre_completo_cliente <$UsuarioEmail>\r\n";  
            $headers .= "X-Mailer: PHP5\n";
            $headers .= 'MIME-Version: 1.0' . "\n";
            $headers .= 'Content-type: text/html; charset=UTF-8' . "\r\n";

            // Aqui definimos el asunto y armamos el cuerpo del mensaje
            $asunto = "Una persona acaba de registrar un reclamo mediante el Libro de Reclamaciones";    
            $cuerpo = "Nombre: ".$Nombre_completo_cliente."<br>";
            $cuerpo .= "Tipo de Documento: ".$UsuarioTipoDocumento."<br>";
            $cuerpo .= "Documento: ".$UsuarioNumeroDocumento."<br>";
            $cuerpo .= "Direccion: ".$UsuarioDireccion."<br>";	
            $cuerpo .= "Telefono: ".$UsuarioTelefono."<br>";
            $cuerpo .= "Email: ".$UsuarioEmail."<br>";
            $cuerpo .= "Mensaje: ".$DetalleIncidente."<br>";
            $cuerpo .= "Desea respuesta de reclamo: ".$RespuestaReclamo; 
           
            if($UsuarioEmail==''){
                header('Location:index.php');		
            }else{
                mail($dest,$asunto,$cuerpo,$headers); //ENVIAR!	
            }
		}
		echo $estado;
	}    
    
    function consultaBD_Ud($consulta,$tipeConsulta){
        global $mysqli,$errors;
        if ($mysqli->connect_errno) {
            return "Lo sentimos, este sitio web está experimentando problemas";
        }
        if (!$resultado = $mysqli->query($consulta)) {
            return "¡Oh, no! La consulta falló.";
        }else{
            if($tipeConsulta=='update'){
                return "successfully";
            }	
            if($tipeConsulta=='insert'){
                return "successfully";
            }
            if($tipeConsulta=='delete'){
                return "successfully";
            }			
        }
        $resultado->free();
        $mysqli->close();
    }

?>