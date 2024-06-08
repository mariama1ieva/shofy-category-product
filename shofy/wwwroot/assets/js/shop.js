

$(window).scroll(function(){
    var scrolling=$(this).scrollTop()
    if (scrolling >20) {
      $("#nav").addClass("menu_bg");
  }else{$("#nav").removeClass("menu_bg")};
  
  if (scrolling >20) {
    $(".navs").addClass("menu_bg");
}else{$(".navs").removeClass("menu_bg")};
  if (scrolling >20) {
    $(".back_to_top").fadeIn();
  }else{$(".back_to_top").fadeOut()};
  
  })
  $(".back_to_top").click(function(){
  $("html,body").animate({
    scrollTop:0,
  })
  })
  