var k = jQuery.noConflict();
k(document).ready(function () {
    k("#owl-demo").owlCarousel({
        autoPlay: 3000, //Set AutoPlay to 3 seconds
        items: 4,
        itemsDesktop: [1199, 3],
        itemsDesktopSmall: [979, 3],
        navigation: true,
        navigationText: [
          "<i class='fa fa-arrow-left '></i>",
          "<i class='fa fa-arrow-right '></i>"
        ],
        pagination: false

    });
    k("#owl-demo-mayvanphong").owlCarousel({
        autoPlay: 3000, //Set AutoPlay to 3 seconds
        items: 4,
        itemsDesktop: [1199, 3],
        itemsDesktopSmall: [979, 3],
        navigation: true,
        navigationText: [
          "<i class='fa fa-arrow-left '></i>",
          "<i class='fa fa-arrow-right '></i>"
        ],
        pagination: false

    });
    k(".new-product_1").owlCarousel({
        autoPlay: 3000, //Set AutoPlay to 3 seconds
        items: 1,
        itemsDesktop: [1199, 1],
        itemsDesktopSmall: [979, 1],
        navigation: true,
        navigationText: [
          "<i class='fa fa-arrow-left '></i>",
          "<i class='fa fa-arrow-right '></i>"
        ],
        pagination: false

    });

    k('#slider').nivoSlider({
        effect: 'random',
        animSpeed: 500,
    });


    var owl = j("#owl_product_home");
    var owlpro = j("#owl_product_pro");

    owl.owlCarousel({
        items: 4, //10 items above 1000px browser width
        itemsDesktop: [1350, 4], //5 items between 1000px and 901px
        itemsDesktopSmall: [1170, 3], // betweem 900px and 601px
        itemsTablet: [600, 2], //2 items between 600 and 0
        itemsMobile: [480, 1],  //
        pagination: false,
        autoPlay: true,
    });
    owlpro.owlCarousel({
        items: 4, //10 items above 1000px browser width
        itemsDesktop: [1350, 4], //5 items between 1000px and 901px
        itemsDesktopSmall: [1170, 3], // betweem 900px and 601px
        itemsTablet: [600, 2], //2 items between 600 and 0
        itemsMobile: [480, 1],  //
        pagination: false,
        autoPlay: true,
    });
    // Custom Navigation Events
    j(".nav_left").click(function () {
        owl.trigger('owl.next');
    });
    j(".nav_right").click(function () {
        owl.trigger('owl.prev');
    });
    j(".nav_left_prom").click(function () {
        owlpro.trigger('owl.next');
    });
    j(".nav_right_prom").click(function () {
        owlpro.trigger('owl.prev');
    });


    for (var i = 20; i < 60; i++) {
        var a = i;
        var owlid = k("#owl_product_" + i);
        owlid.owlCarousel({
            items: 4, //10 items above 1000px browser width
            itemsDesktop: [1350, 4], //5 items between 1000px and 901px
            itemsDesktopSmall: [1170, 3], // betweem 900px and 601px
            itemsTablet: [600, 2], //2 items between 600 and 0
            itemsMobile: [480, 1],  //
            pagination: false,
            autoPlay: true,
        });
        k(".nav_left_" + i).click(function () {
            owlid.trigger('owl.next');
        });
        k(".nav_right_" + i).click(function () {
            owlid.trigger('owl.prev');
        });
    }
});