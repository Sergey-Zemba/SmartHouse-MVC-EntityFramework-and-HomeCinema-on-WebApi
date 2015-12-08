$(document).ready(function () {
    $("#AddHomeCinema").click(function () { showRadios("HomeCinema") });
    $("#AddLoudspeakers").click(function () { showRadios("Loudspeakers") });
    $("#AddTv").click(function () { showRadios("Tv") });
});
function showRadios(dev) {
    var id = dev + "Radio";
    $(".radio").attr('hidden', true);
    $("#" + id).attr('hidden', false);
}