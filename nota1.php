<!DOCTYPE html>
<html lang="es">
<head>
	
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
<link rel="icon" type="image/png" href="<?php echo $typeDomain.$domain; ?>/assets/img/icon.png" />

<title><?php echo $namePage." : "._MESSAGE_TITLE; ?></title>

<!-- ESTILO -->
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
<!-- JAVASCRIPT -->
<script src="https://ajax.googleapis.com/ajax/libs/jquery/2.2.4/jquery.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
</head>
<body>

<!-- Overlay: aparece cuandos se pone encima -->
<script type="text/javascript">
</script>

<style type="text/css">	
	 .overlay{
		  position: absolute;
		  top:0;
		  bottom: 0;
		  left: 0;
		  right: 0;
		  opacity: 0;
		  background-color: #ffffffb5;
		  width: 100%;
		  height: 100%;
		  transition: .5s ease;		  
	}
	.overlay .overlay-text{
		  white-space: nowrap; 
		  background-color: #000;
		  padding: 5px;
		  border-radius: 10px;
		  color: #fff;
		  font-weight: bold;
		  font-size: 15px;
		  position: absolute;
		  top: 50%;
		  left: 50%;
		  text-align: center;
		  transform: translate(-50%, -50%);
		  -webkit-transform: translate(-50%, -50%);
		  -ms-transform: translate(-50%, -50%);
	}
	.divPadre:hover .overlay{
		opacity: 1;
	}
</style>
<div class="divPadre">
	<div class="overlay">
		<div class="overlay-text">TEXTO</div>
	</div>
</div>

<!-- Overlay, que aparece desde abajo -->
<style type="text/css" media="screen">

	.promotor-item{ 
	  margin-top: 10px;
	}
	.promotor-item a{
	  color: #343a40;     
	}
	.promotor-item a .promotor-item-img{
	  position: relative;
	  overflow: hidden;
	  border-radius: 50%;
	  max-width: 200px;
	  margin: 0 auto;
	}
	.promotor-item > a >.promotor-item-img > .img-promotor{
	  width: 100%;
	  display: block;
	  height: auto;
	}

	.promotor-item .promotor-item-img>.overlay {
	  position: absolute;
	  bottom: 0;
	  left: 0;
	  right: 0;
	  background-color: #000;
	  overflow: hidden;
	  width: 100%;
	  height: 0;
	  transition: .5s ease;
	  border-radius: 10px;
	}

	.promotor-item .promotor-item-img>.overlay > .ver-promotor {
	  white-space: nowrap; 
	  color: white;
	  font-weight: bold;
	  font-size: 20px;
	  position: absolute;
	  top: 50%;
	  left: 50%;
	  transform: translate(-50%, -50%);
	  -ms-transform: translate(-50%, -50%);
	}   

	.promotor-item> a:hover .overlay {
	  height: 100%;
	}	
</style>
<div class="promotor-item-img">
	<img class="img-promotor" src="assets/img/user_img_default.jpg" alt="">
	<div class="overlay">
		<div class="ver-promotor">Ver Promotor</div>
	</div>
</div>	

<!-- Overlay button abajo -->
<style type="text/css" media="screen">
.btm-carousel{
	transition: .5s ease;
	opacity: 0;
	position: absolute;
	bottom: 7%;
	left: 50%;
	transform: translate(-50%, -50%);
	-ms-transform: translate(-50%, -50%);
	cursor: pointer;
}	
.btm-carousel>.text {
	background-color: #000;
	color: white;
	font-weight: bold;
	font-size: 18px;
	padding: 10px 15px;
	border-radius: 21px;
	box-shadow: 2px 2px 8px 0 rgba(0, 0, 0, 0.46);
}
.carousel-item:hover .btm-carousel{
  opacity: 1;
}	
</style>
<div class="btm-carousel"><div class="text">TEXTOO</div></div>
</body>
