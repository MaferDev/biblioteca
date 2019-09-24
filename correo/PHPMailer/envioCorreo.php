<?php
require ('class.phpmailer.php');
include("class.smtp.php");

class Email  extends PHPMailer{

    //datos de remitente
    var $tu_email;
    var $tu_nombre;
    var $tu_password;

    /**
 * Constructor de clase
 */
    public function __construct($tu_nombre,$tu_email,$tu_password)
    {
      //configuracion general
     $this->IsSMTP(); // protocolo de transferencia de correo
     $this->Host = 'smtp.gmail.com';  // Servidor GMAIL
     $this->Port = 465; //puerto
     $this->SMTPAuth = true; // Habilitar la autenticación SMTP
     $this->Username = $this->tu_email=$tu_email;
     $this->Password = $this->tu_password=$tu_password;
     $this->SMTPSecure = 'ssl';  //habilita la encriptacion SSL
     //remitente
     $this->From = $this->tu_email;
     $this->FromName = $this->tu_nombre=$tu_nombre;
     $this->CharSet='UTF8';
    }

    /**
 * Metodo encargado del envio del e-mail
 */

    public function enviar($asunto , $contenido)
    {
      //$this->AddAddress($para,$nombre );  // Correo y nombre a quien se envia
    //$this->addCC("correo@hotmail.com",'nombre');
    //$this->addBCC("correo2@hotmail.com",'nombre'); 
       $this->WordWrap = 50; // Ajuste de texto
       $this->IsHTML(true); //establece formato HTML para el contenido
       $this->Subject =$asunto;
       $this->Body    =  $contenido; //contenido con etiquetas HTML
       $this->AltBody =  strip_tags($contenido); //Contenido para servidores que no aceptan HTML
    //$this->addAttachment("archivoadjunto.pdf",'Prueba 1.pdf');
    //$this->addAttachment("archivoadjunto.pdf",'Prueba 2.pdf');
       //envio de e-mail y retorno de resultado
    $this->SMTPOptions = array( 'ssl' => array( 'verify_peer' => false, 'verify_peer_name' => false, 'allow_self_signed' => true ) );

       return $this->Send() ;
   }
   
   public function agregar($correo,$nombre = ''){
     $this->addAddress($correo,$nombre);
  }

}//--> fin clase
?>