
<!DOCTYPE html>
<html>
  <head>
    <meta http-equiv='content-type' content='text/html; charset=utf-8' />
    <meta name='viewport' content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no'>
    <title>DOM panzoom demo</title>
	<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>

<style type="text/css" media="screen">
	#zoomable{
		position: absolute; 
		top: 0; 
		left: 0; 
		bottom: 0; 
		right: 0; 
		margin: auto;
		overflow: hidden;
		background-color: #ccc;
    	background-size: 100% 100%;
    	background-image: url('http://localhost/revikitV1/catalogo/lebel/08-2019/0/2.jpg');
    	width: 360px; 
    	height: 470px;
	}
	.btn-zoom{
		z-index: 9999px;
		position: absolute;
		top: 0;
		left: 0;
		font-size: 20px;
		cursor: pointer;
		background-color: #000;
		color: #fff;
		padding: 4px;
		border-radius: 50%;
		font-weight: bold;
	}
</style>
  </head>
  <body>

<div id='zoomable' style="">
</div>
    <p class='btn-zoom'> X </p>
    <script src='panzoom.js'></script>
    <script>
		var area = document.querySelector('#zoomable')
		// panzoom(area)
		$('.btn-zoom').click(function(){
			if($('.btn-zoom').hasClass('zoom-in')){
				$('.btn-zoom').removeClass('zoom-in');
				console.log('test');
			}else{
				$('.btn-zoom').addClass('zoom-in');
				$('#zoomable').append('<p style="position:absolute">¡Double Clic to ZOOM!</p>')
			}
			panzoom(area);
		})

    // Array.from(
    //   document.querySelectorAll('.button-container a.button')
    // ).forEach(attachClickHandler)

    // function attachClickHandler(el) {
    //   el.addEventListener('click', handleClick);
    // }

    // function handleClick(e) {
    //   e.preventDefault();
    //   let container = document.querySelector('#scene');
    //   let rect = container.getBBox();
    //   let cx = rect.x + rect.width/2;
    //   let cy = rect.y + rect.height/2;
    //   let isZoomIn = e.target.id === 'zoomIn';
    //   let zoomBy = isZoomIn ? 2 : 0.5;
    //   pz.smoothZoom(cx, cy, zoomBy);
    //   // Or if you don't need animation, usee this:
    //   // pz.zoomTo(cx, cy, zoomBy);
    // }

    </script>
  </body>
</html>
