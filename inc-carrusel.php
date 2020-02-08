<style type="text/css">	
.carousel-inner img {
  width: 100%;
}
.carusel-cat{
	padding-top: 95px;
}
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
.carousel-item{
	cursor: pointer;
}
.carousel-item:hover .btm-carousel{
  opacity: 1;
}
</style>

<script type="text/javascript">
var num_cat="<?php echo count($catalogos); ?>";
// console.log("num > " + num_cat);
$(document).ready(function(){
	var selectCarousel = $('#carousel-cat');
	var selectInner = selectCarousel.find('.carousel-indicators');
	for(i=1;i<num_cat;i++){
		selectInner.append('<li data-target="#carousel-cat" data-slide-to="'+i+'"></li>');		
	}
});
function ver_catalogo(cat){
	location.href ="<?php echo $typeDomain.$domain; ?>/catalogo/"+cat;
}
</script>
<div class="container-fluid carusel-cat"> 
	<div id="carousel-cat" class="carousel slide" data-ride="carousel">
		<ol class="carousel-indicators">
			<li data-target="#carousel-cat" data-slide-to="0" class="active"></li>
  		</ol>
    	<div class="carousel-inner">
<?php 
$contador=0;
foreach ($catalogos as $cat =>$valor) {
	if($contador==0){
		echo '<div class="carousel-item active"><a href="'.$typeDomain.$domain.'/catalogo/'.$catalogos[$cat]['dir'].'"><img class="d-block w-100" src="'.$typeDomain.$domain.'/catalogo/'.$catalogos[$cat]['dir'].'/img-slider.jpg" alt="'._P_CATALOGO." ".$catalogos[$cat]['name'].'"><div class="btm-carousel"><div class="text">'._TITLE_VER_CAT." ".$catalogos[$cat]['name'].'</div></div></a></div>';
	    $contador=1;			
	}else{
		echo '<div class="carousel-item"><a href="'.$typeDomain.$domain.'/catalogo/'.$catalogos[$cat]['dir'].'"><img class="d-block w-100" src="'.$typeDomain.$domain.'/catalogo/'.$catalogos[$cat]['dir'].'/img-slider.jpg" alt="'._P_CATALOGO." ".$catalogos[$cat]['name'].'"><div class="btm-carousel"><div class="text">'._TITLE_VER_CAT." ".$catalogos[$cat]['name'].'</div></div></a></div>';
	}	
} 
?>	    	
    	</div>
		<a class="carousel-control-prev" href="#carousel-cat" role="button" data-slide="prev">
			<span class="carousel-control-prev-icon" aria-hidden="true"></span>
			<span class="sr-only">Previous</span>
		</a>
		<a class="carousel-control-next" href="#carousel-cat" role="button" data-slide="next">
			<span class="carousel-control-next-icon" aria-hidden="true"></span>
			<span class="sr-only">Next</span>
		</a>
  </div>
</div>