$('.black-background, .white-background').css('min-height', $(window).height() - 50);

//function initLinksAnimations() {
//    $('a.page-scroll').click(function () {
//        var target = $(this.hash);
//        var hash = this.hash;
//        $('html,body').animate({
//            scrollTop: target.offset().top - 50
//        }, 900, function () {
//            //window.location.hash = hash;

//        });
//    });
//}

function moveScrollToContent() {
    var hash = window.location.hash;
    var firstSlash = hash.indexOf('/');
    var secondSlash = hash.indexOf('/', firstSlash + 1);
    if (secondSlash <= 0) {
        secondSlash = hash.length;
    }
    var containerToScrollId = hash.substr(firstSlash + 1, secondSlash - firstSlash - 1);
    //if (containerToScrollId == 'Admin' || containerToScrollId == 'User') {
    //    containerToScrollId = 'content-container';
    //}
    var target = $('#' + containerToScrollId);

    $('html,body').animate({
        scrollTop: target.offset().top - 50
    }, 900, function () {
        //window.location.hash = hash;
    });
}

