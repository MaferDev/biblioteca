<!doctype html>
<html lang="en">

	<head>
		<meta charset="utf-8">

		<title>zoom.js</title>


		<link href='https://fonts.googleapis.com/css?family=Lato:400,700,400italic,700italic' rel='stylesheet' type='text/css'>
	<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>

	</head>

	<body>
		<style type="text/css">
		  .image{
			/*max-width: 500px;*/
			text-align: center;
		  }
		  .image img{
		  	/*width: 100%;*/
		  }
		  .zoom-in{
			overflow: auto;
		}
		</style>  

  <!-- <div class="image zoom-in"></div> -->

<script type="text/javascript"> 
	// event.preventDefault();
	

 </script>
  <div class="image">
  	<img src="img.jpg" alt="">
  </div>

		<div class="page-body">


			<h2>Source</h2>
			
			<h2>Is she dead, yes or no?</h2>
			<p>Do you see any Teletubbies in here? Do you see a slender plastic tag clipped to my shirt with my name printed on it? Do you see a little Asian child with a <em>blank expression on his face</em> sitting outside on a mechanical helicopter that shakes when you put quarters in it? No? Well, that's what you see at a toy store. And you must think you're in a toy store, because you're here shopping for an infant named Jeb.</p>

			<div style="width: 80px; height: 80px; margin-right: 10px; padding: 10px; float: left; background: green;">
				Float
			</div>

			<h2>I gotta piss</h2>
			<p>Do you see any Teletubbies in here? Do you see a slender plastic tag clipped to my shirt with my name printed on it? Do you see a little Asian child with a blank expression on his face sitting outside on a mechanical helicopter that shakes when you put quarters in it? No? Well, that's what you see at a toy store. And you must think you're in a toy store, because you're here shopping for an infant named Jeb.</p>

			<div style="width: 100px; height: 50px; position: absolute; right: 50px; top: 250px; background: red;">
				Absolute
				<div style="width: 80px; height: 100px; position: relative; left: -50px; top: 200px; padding: 10px; margin-left: 50px; background: blue;">
				Relative, in red container
				</div>
			</div>
		</div>

		<script src="js/zoom.mf.js"></script>
		<script>
			let w=1336,h=1790;
			document.querySelector('.image' ).addEventListener( 'click', function( event ) {
				// $('.image img').css({
				// 	'width':'1336px',
				// 	'height':'1790px'
				// })
				event.preventDefault();
				console.log(event.target);
				zoom.to({ element: event.target });
			} );
		</script>
	</body>
</html>