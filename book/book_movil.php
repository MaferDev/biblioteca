<?php include('pages/configcat.php'); 

if(!isset($_GET['Ancho']) && !isset($_GET['Alto'])){
    echo "<script language=\"JavaScript\">
    <!-- 
    document.location=\"$PHP_SELF?Ancho=\"+screen.width+\"&Alto=\"+screen.height;
    //-->
    </script>";
} else {
    if(isset($_GET['Ancho']) && isset($_GET['Alto'])) {
        // Resolución de pantalla detectada
        echo "Esta es tu resolucion de pantalla: Ancho= ".$_GET['Ancho']." y Alto= ".$_GET['Alto'];
    } else {
        // error en la detección de resolución de pantalla
        echo "No se ha podido detectar la resolución de pantalla";
    }
}

?>
<!doctype html>
<html>
<head>
<script type="text/javascript" src="http://code.jquery.com/jquery-1.7.1.min.js"></script>
<script type="text/javascript" src="hash.js"></script>
<script src="http://localhost/revikitV1/assets/js/global-function.js"></script>
<link rel="stylesheet" type="text/css" href="http://localhost/revikitV1/view/view-cat/css/bookPc.css">

<style type="text/css">
#magazine .turn-page{
	background-color:#ccc;
	background-size:100% 100%;
}
</style>
</head>
<body>

<div id="magazine"></div>

<img src="pages/1-large.jpg" style="width: 100%" class="img-test">

<script type="text/javascript">
let url_view=domainWeb+"/view/view-cat/";
let titleCatalogo="<?php echo $_GET['name']; ?>";
let campania="<?php echo $_GET["campania"]; ?>";
let tipoCatalogo="<?php echo $_GET["tipo"]; ?>"; // 0=belleza 1=casa
let url_pages_cat=domainWeb+"/catalogo/"+titleCatalogo+"/"+campania+"/"+tipoCatalogo+"/";
let numPage_Catalogo="<?php echo $cat_paginas; ?>";
let pageActive="1";
let textInput="";
let tipo_imagen="<?php echo $tipo_imagen; ?>";
let totalPage=<?php echo $cat_paginas; ?>;
let alto_large="";
let ancho_large="";
let InitPage=1;
let contView=1; // 1=abierto 0= oculto menu principal
let contViewSubMenu=1; // 1=abierto 0= oculto menu share

$(window).ready(function() {
    let img = document.querySelector('.img-test');
	configBook(img);
	$('.menu nav ul li .more-cat').css('background-image','url('+domainWeb+'/assets/icons/icon-libro.png)');
	$('.menu nav ul li .share-cat').css('background-image','url('+domainWeb+'/assets/icons/icon-share.png)');
	$('.menu nav ul li .return-cat').css('background-image','url('+domainWeb+'/assets/icons/icon-home.png)');
	$('.children > li .share-facebook').css('background-image','url('+domainWeb+'/assets/icons/icon-fb.png)');
	$('.children > li .share-twitter').css('background-image','url('+domainWeb+'/assets/icons/icon-tw.png)');


	$('.magazine-viewport .previous-button-down').css('background-image','url('+domainWeb+'/assets/icons/icon-arrows.png)');	
	$('.magazine-viewport .next-button-down').css('background-image','url('+domainWeb+'/assets/icons/icon-arrows.png)');	

    cargarValores();
    $('.btn_menu_movil').click(function(){
      if(contView==1){
        $('nav').animate({
          left:'0'            
        });
        $("#icon-menu").removeClass('glyphicon-menu-hamburger').addClass('glyphicon-remove');
        document.getElementById('btn_menu').style.color = 'white';
        document.getElementById('btn_menu').style.background = 'black';
        contView=0;
      }else{
        $('.children').animate({
          left:'-100%',
          right:'100%'

        }); 
        $('nav').animate({
          left:'-100%'
        });
        $("#icon-menu").removeClass('glyphicon-remove').addClass('glyphicon-menu-hamburger');
        document.getElementById('btn_menu').style.color = 'black';
        document.getElementById('btn_menu').style.background = 'white';
        contView=1;
      }
    });

	$('#magazine').turn({
		display: 'single',
		acceleration: true,
		gradients: !$.isTouch,
		elevation:50,
		when: {
			turned: function(e, page) {
				let pageActive=$(this).turn('view')[0];
				console.log('Current view: ', pageActive);
			}
		}
	});
});

function configBook(img){   
	alto_large = img.height; 
    ancho_large = img.width; 
	$('.img-test').hide();
	$('#magazine').css({
		"height":alto_large,
		"width":ancho_large
	})
	for(let i=InitPage;i<totalPage;i++){
		$("#magazine").append('<div style="background-image:url(pages/'+i+'-large.'+tipo_imagen+');"></div>');
	}
}	

$(window).bind('keydown', function(e){		
	if (e.keyCode==37)
		$('#magazine').turn('previous');
	else if (e.keyCode==39)
		$('#magazine').turn('next');		
});

</script>
<script type="text/javascript" src="turn-movil.js"></script>
</body>
</html>