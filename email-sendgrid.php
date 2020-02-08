<?php
// require 'vendor/autoload.php'; // If you're using Composer (recommended)
// Comment out the above line if not using Composer
require ("include/sendgrid-php/sendgrid-php.php");
// If not using Composer, uncomment the above line and
// download sendgrid-php.zip from the latest release here,
// replacing <PATH TO> with the path to the sendgrid-php.php file,
// which is included in the download:
// https://github.com/sendgrid/sendgrid-php/releases

$email = new \SendGrid\Mail\Mail(); 
$email->setFrom("servicio-cliente@revikit.com", "Revikit");
$email->setSubject("Enviar Emails es divertido :)");
$email->addTo("mary_18f@hotmail.com", "Fernanda Huaman");
$email->addContent("text/plain", "Revikit.com");
$email->addContent(
    "text/html", "<strong>Gracias por registrarte en revikit</strong>"
);
$sendgrid = new \SendGrid('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');
try {
    $response = $sendgrid->send($email);
    print $response->statusCode() . "\n";
    print_r($response->headers());
    print $response->body() . "\n";
} catch (Exception $e) {
    echo 'Caught exception: '. $e->getMessage() ."\n";
}
?>