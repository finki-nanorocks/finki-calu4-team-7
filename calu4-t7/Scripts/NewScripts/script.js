
$(window).scroll(function() {
    if ($(document).scrollTop() > 70) {
       // alert();
        $('nav').addClass('shrink');
    } else {
        $('nav').removeClass('shrink');
    }
});