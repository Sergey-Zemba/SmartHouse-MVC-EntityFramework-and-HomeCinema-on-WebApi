$(document).ready(function () {
    $("#AddHomeCinema").click(function () { showLinks("HomeCinema") });
    $("#AddLoudspeakers").click(function () { showLinks("Loudspeakers") });
    $("#AddTv").click(function () { showLinks("Tv") });
});
function showLinks(dev) {
    var id = dev + "Link";
    $(".visible").removeClass("visible").addClass("invisible");
    $("#" + id).removeClass("invisible");
    $("#" + id).addClass("visible");
}