$(window).scroll(function(){
    var scrolling=$(this).scrollTop()
  
  
    
    if (scrolling >20) {
      $("#nav").addClass("menu_bg");
  }else{$("#nav").removeClass("menu_bg")};
    if (scrolling >20) {
      $(".nav").addClass("menu_bg");
  }else{$(".nav").removeClass("menu_bg")};
  
  
  if (scrolling >20) {
    $(".back_to_top").fadeIn();
  }else{$(".back_to_top").fadeOut()};
  
  })
  
  
  $(".back_to_top").click(function(){
  $("html,body").animate({
    scrollTop:0,
  })
  })

  $('.offer_main').slick({
    slidesToShow: 3,
    slidesToScroll: 1,
    dots:true,
    arrows:false,
    centerMode: true,
    centerPadding:"0px",
    responsive: [
      {
        breakpoint: 991,
        settings: {
          slidesToShow: 2,
          slidesToScroll: 1,
        }
      },
      {
        breakpoint: 767,
        settings: {
          slidesToShow: 1,
          slidesToScroll: 1
        }
      },
      {
        breakpoint: 575,
        settings: {
          slidesToShow: 1,
          slidesToScroll: 1
        }
      }
    ]
  });
        
  $('.blog_main').slick({
    slidesToShow: 3,
    slidesToScroll: 1,
    arrows:false,
    centerMode: true,
    centerPadding:"0px",
    responsive: [
      {
        breakpoint: 991,
        settings: {
          slidesToShow: 1,
          slidesToScroll: 1,
        }
      },
      {
        breakpoint: 767,
        settings: {
          slidesToShow: 1,
          slidesToScroll: 1
        }
      },
      {
        breakpoint: 575,
        settings: {
          slidesToShow: 1,
          slidesToScroll: 1
        }
      }
    ]
  });
        
  $('.arrivals_slide_main').slick({
    slidesToShow: 4,
    slidesToScroll: 1,
    nextArrow:".anext",
    prevArrow:".aprev",
    centerMode: true,
    centerPadding:"0px",
    responsive: [
      {
        breakpoint: 991,
        settings: {
          slidesToShow: 2,
          slidesToScroll: 1,
        }
      },
      {
        breakpoint: 767,
        settings: {
          slidesToShow: 1,
          slidesToScroll: 1
        }
      },
      {
        breakpoint: 575,
        settings: {
          slidesToShow: 1,
          slidesToScroll: 1
        }
      }
    ]
  });


 
 
        