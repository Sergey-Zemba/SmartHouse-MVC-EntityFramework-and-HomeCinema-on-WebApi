$(document).ready(function () {
    $(".homeCinema .delete").click(function (event) {
        event.preventDefault();
        var device = $(event.target).closest(".item")[0];
        var id = $(device).find("#hidden").val();
        $.ajax({
            url: "/api/HomeCinemaWebApi/" + id,
            type: "DELETE",
            success: function () {
                var container = $(event.target).closest(".container")[0];
                container.removeChild(device);
            }
        });
    });
    $(".homeCinema .onOff").click(function (event) {
        event.preventDefault();
        var device = $(event.target).closest(".item")[0];
        var id = $(device).find("#hidden").val();
        $.ajax({
            url: "/api/HomeCinemaWebApi/OnOff/" + id,
            type: "PUT",
            success: function () {
                $.ajax({
                    url: "/api/HomeCinemaWebApi/" + id,
                    type: "GET",
                    success: function(data) {
                        alert(data);
                    }                
                });
            }
        });
    });
});