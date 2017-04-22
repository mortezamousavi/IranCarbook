$(document).ready(function(){
	
	// Twitter settings
	$(".tweet").tweet({
		username: "voodoopixel",
		count: 3,
		template:"{join}{text}"
	});
	
	// Navigation and responsive menu
	$('#menu').supersubs({
		minWidth:    12,   // minimum width of submenus in em units
		maxWidth:    27,   // maximum width of submenus in em units
		extraWidth:  1     // extra width can ensure lines don't sometimes turn over	
	}).superfish({
	});	
	$('#menu').mobileMenu({
		defaultText: 'Navigate to...',
		className: 'mobileMenu',
		subMenuDash: '&ndash;'
	});
	
	// Tabs
	$('.tab-container').easytabs({animationSpeed:"fast"});
	
	// Toggles
	$(".togglebox").hide();
	$("div").click(function(){
	$(this).toggleClass("active").next(".togglebox").slideToggle("normal");
		return true;
	});
	
	// Hover images
	$(".hover-image-alt1").hover(function() {
		$(this).find("img").stop().animate({'opacity' : 0.2});
	}, function(){
		$(this).find("img").stop().animate({'opacity' : 1});
	});
	$(".hover-image-alt2").hover(function() {
		$(this).find("img").stop().animate({'opacity' : 0.2});
	}, function(){
		$(this).find("img").stop().animate({'opacity' : 1});
	});
	
	// Flickr Feed
	$('.flickr').jflickrfeed({
		limit: 12,
		qstrings: {
			id: '52617155@N08' // Flickr Id form in your photostream of flickr profile. You can find it here http://idgettr.com/
		}
	});
	
	// FitVideos
	$(".embeded-container").fitVids();

	// Portfolio container
	var $container = $('.portfolio-content');
	$container.imagesLoaded(function() {
		$container.isotope({
			layoutMode : 'masonry'	// masonry, fitRows
	  });
	});
	
	
	// Filter items when filter link is clicked
	$('.portfolio-filter a').click(function(){
	  var selector = $(this).attr('data-filter');
		$('.portfolio-filter a').removeClass('selected-portfolio-filter');
		$(this).addClass('selected-portfolio-filter');
	  $container.isotope({ filter: selector });
	  return false;
	});
	
	// Filterable menu	
	$('.portfolio-filter').hide();
	$('#filters .show-category span').click(function () {
		$('.portfolio-filter').slideToggle('fast');
	});
	
	// Tooltips
	$('.tooltip').tooltipster({
		animation: 'fade',		// fade, grow, swing, slide, fall
		delay: 0,				// Delay how long it takes (in milliseconds) for the tooltip to start animating in.
		position: 'top',		// right, left, top, top-right, top-left, bottom, bottom-right, bottom-left
		speed: 350,				// Set the speed of the animation.
		timer: 0,				// How long the tooltip should be allowed to live before closing.
		trigger: 'hover'		// hover, click
	});
	
	// PrettyPhoto
	$("a[rel^='prettyPhoto']").prettyPhoto({});
	
	// Nivo Slider
	$('.nivoSlider').nivoSlider({
        effect: 'random', // Specify sets like: 'fold,fade,sliceDown'
        slices: 15, // For slice animations
        boxCols: 8, // For box animations
        boxRows: 4, // For box animations
        animSpeed: 500, // Slide transition speed
        pauseTime: 3000, // How long each slide will show
        startSlide: 0, // Set starting Slide (0 index)
        directionNav: true, // Next & Prev navigation
        controlNav: false, // 1,2,3... navigation
        controlNavThumbs: false, // Use thumbnails for Control Nav
        pauseOnHover: true, // Stop animation while hovering
        manualAdvance: false, // Force manual transitions
    });
	
});