$(document).ready(function() {
    window.scroll(0, $.cookie("scrollTop"));
    $("a").click(function () {
        $.cookie("scrollTop", $(document).scrollTop());
    });
});