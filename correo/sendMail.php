<?php
    $mensaje="";
    if(isset($_POST["sendMailWelcome"])){
            include("PHPMailer/envioCorreo.php");
            $email_to=$_POST["email"];
            $name_to=$_POST["nombre"];
            $type_user=2;
            $title_email='Bienvenida(o) a REVIKIT';
            if($type_user==2){
               $contenido_html =  '<div class="content-mail">
                                    <div style="text-align: center; max-width: 730px; margin: auto; background-color: rgba(224, 224, 224, 0.11); padding: 15px;">
                                        <h3>Estimada(o) '.$name_to.'</h3>
                                        <p>Bienvenido(a) a <b>REVIKIT</b></p>
                                        <p>Desde ahora te estaremos comunicando cuando haya nuevas solicitudes para ser parte de tu red de consultoras o cuando los clientes deseen adquirir alguno de tus productos de stock.</p>
                                        <p style="margin-top: 10px">Por ello si aún no te haz subido a la plataforma tus productos que tienes en stock, te recomendamos subirlos <a href="https://revikit.com/panel-de-usuario/0/" style="color: #000; font-weight: bold;">Subir mis productos</a>.</p>     
                                        <p style="margin-top: 30px">Gracias por registrar con nosotros.</p>
                                        <p style="font-weight: bold;">Nota: Si El correo esta marcado como spam, le recomendamos confirmar que no lo es, para que así pueda recibir todas las notificaciones que le enviaremos. Nos comprometemos a no enviar spams.</p>
                                        <div style="font-weight: bold;margin-top: 30px">REVIKIT</div>
                                        <div style="font-size: small;">Todos tus catálogos en un solo lugar</div>
                                    </div>
                                </div>';
            }else{
               $contenido_html =  '<div class="content-mail">
                                    <div style="text-align: center; max-width: 730px; margin: auto; background-color: rgba(224, 224, 224, 0.11); padding: 15px;">
                                        <h3>Estimada(o) '.$name_to.'</h3>
                                        <p>Bienvenido(a) a <b>REVIKIT</b></p>
                                        <p>Desde ahora te estaremos comunicando cuando haya nuevas novedades y productos de catálogos cerca de ti.</p>  
                                        <p style="margin-top: 30px">Gracias por registrar con nosotros.</p>
                                        <p style="font-weight: bold;">Nota: Si El correo esta marcado como spam, le recomendamos confirmar que no lo es, para que así pueda recibir todas las notificaciones que le enviaremos. Nos comprometemos a no enviar spams.</p>
                                        <div style="font-weight: bold;margin-top: 30px">REVIKIT</div>
                                        <div style="font-size: small;">Todos tus catálogos en un solo lugar</div>
                                    </div>
                                </div>';
            }
            
            $email = new email("Revikit","revikitcompany@gmail.com","fer9667766m");
            $email->agregar($email_to,$name_to);                        
            if ($email->enviar($title_email,$contenido_html)){                          
                $mensaje= 'Mensaje enviado';            
            }else{                         
               $mensaje= 'El mensaje no se pudo enviar';
               $email->ErrorInfo;
            }
   }
?>
<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>Email</title>
<link rel="stylesheet" href="css/style.css"/>
</head>

<body>
    <header>
     <div id="logo"><img src="logo-php.png"/></div>
    </header>
    <div id="pagina">
        <section>
            <div>
                <form action="<?php echo $_SERVER['PHP_SELF']; ?>" method="post" enctype="application/x-www-form-urlencoded">
                    <table>
                        <tr>
                            <td>
                                <label for="email">Email</label>
                            </td>
                            <td>
                                <input type="text" name="email" id="email" placeholder="ejemplo@dominio.com" autofocus maxlength="50" size="20">
                            </td>
                            <td>
                                <label for="nombre">Nombre</label>
                            </td>
                            <td>
                                <input type="text" name="nombre" id="nombre" placeholder="Tu nombre" autofocus maxlength="50" size="20">
                                <input name="envio" value="si" hidden="hidden">
                            </td>
                            <td>
                                <button type="submit" name="sendMailWelcome">Enviar</button>
                            </td>
                        </tr>
                    </table>
                </form>
            </div>
            <?php
                echo $mensaje;
            ?>
        </section>
        <aside>
        
        </aside>
    </div>
    <footer>
    
    </footer>
</body>
</html>