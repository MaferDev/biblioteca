<?php
    ini_set( 'display_errors', 1 );
    error_reporting( E_ALL );
    $from = "revikit@gmail.com";
    $to = "fer.hs19@gmail.com";
    $subject = "Bienvenido a REVIKIT2";
    $message = 'Bienvenid@ a REVIKIT, \n\nGracias por unirte a nuestra comunidad \n\n <a href="https://revikit.com">Click Here!</a>';
    $headers = "From:" . $from;
    mail($to,$subject,$message, $headers);
    echo "Mensaje Enviado";
?>