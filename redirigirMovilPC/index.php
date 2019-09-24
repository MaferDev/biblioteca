<!DOCTYPE html>
<html lang="es">
<head>
	<meta charset="UTF-8">
	<title>Document</title>
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/2.2.4/jquery.min.js"></script>
	<script type="text/javascript">
		//Detección y redireccionamiento de dispositivos móviles
		var device = navigator.userAgent;
		var device = navigator.userAgent;
		let url=getAbsolutePath();
		if (device.match(/Iphone/i)|| device.match(/Ipod/i)|| device.match(/Android/i)|| device.match(/J2ME/i)|| device.match(/BlackBerry/i)|| device.match(/iPhone|iPad|iPod/i)|| device.match(/Opera Mini/i)|| device.match(/IEMobile/i)|| device.match(/Mobile/i)|| device.match(/Windows Phone/i)|| device.match(/windows mobile/i)|| device.match(/windows ce/i)|| device.match(/webOS/i)|| device.match(/palm/i)|| device.match(/bada/i)|| device.match(/series60/i)|| device.match(/nokia/i)|| device.match(/symbian/i)|| device.match(/HTC/i)){
			
			window.location = url+'movil.php';
		}else{
			window.location = url+'pc.php';
		}	
		function getAbsolutePath() {
		    var loc = window.location;
		    var pathName = loc.pathname.substring(0, loc.pathname.lastIndexOf('/') + 1);
		    return loc.href.substring(0, loc.href.length - ((loc.pathname + loc.search + loc.hash).length - pathName.length));
		}	
	</script>
</head>
<body>
	<h1><?php echo $_SERVER['REQUEST_URI']; ?></h1>
</body>
</html>