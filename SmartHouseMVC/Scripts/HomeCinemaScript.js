$(document).ready(function () {
    $(".homeCinema .delete").click(function (event) {
        event.preventDefault();
        var device = $(event.target).closest(".item")[0];
        var id = $(device).find(".hidden").val();
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
        var id = $(device).find(".hidden").val();
        $.ajax({
            url: "/api/HomeCinemaWebApi/OnOff/" + id,
            type: "PUT",
            success: function () {
                $.ajax({
                    url: "/api/HomeCinemaWebApi/" + id,
                    type: "GET",
                    success: function (data) {
                        repaint(data);
                    }
                });
            }
        });
    });
    $(".homeCinema .addVolume").click(function (event) {
        event.preventDefault();
        var device = $(event.target).closest(".item")[0];
        var id = $(device).find(".hidden").val();
        $.ajax({
            url: "/api/HomeCinemaWebApi/AddVolume/" + id,
            type: "PUT",
            success: function () {
                $.ajax({
                    url: "/api/HomeCinemaWebApi/" + id,
                    type: "GET",
                    success: function (data) {
                        repaint(data);
                    }
                });
            }
        });
    });
    $(".homeCinema .decreaseVolume").click(function (event) {
        event.preventDefault();
        var device = $(event.target).closest(".item")[0];
        var id = $(device).find(".hidden").val();
        $.ajax({
            url: "/api/HomeCinemaWebApi/DecreaseVolume/" + id,
            type: "PUT",
            success: function () {
                $.ajax({
                    url: "/api/HomeCinemaWebApi/" + id,
                    type: "GET",
                    success: function (data) {
                        repaint(data);
                    }
                });
            }
        });
    });
    $(".homeCinema .mute").click(function (event) {
        event.preventDefault();
        var device = $(event.target).closest(".item")[0];
        var id = $(device).find(".hidden").val();
        $.ajax({
            url: "/api/HomeCinemaWebApi/Mute/" + id,
            type: "PUT",
            success: function () {
                $.ajax({
                    url: "/api/HomeCinemaWebApi/" + id,
                    type: "GET",
                    success: function (data) {
                        repaint(data);
                    }
                });
            }
        });
    });
    $(".homeCinema .rec").click(function (event) {
        event.preventDefault();
        var device = $(event.target).closest(".item")[0];
        var id = $(device).find(".hidden").val();
        $.ajax({
            url: "/api/HomeCinemaWebApi/Rec/" + id,
            type: "PUT",
            success: function () {
                $.ajax({
                    url: "/api/HomeCinemaWebApi/" + id,
                    type: "GET",
                    success: function (data) {
                        repaint(data);
                    }
                });
            }
        });
    });
    $(".homeCinema .bass").click(function (event) {
        event.preventDefault();
        var device = $(event.target).closest(".item")[0];
        var id = $(device).find(".hidden").val();
        $.ajax({
            url: "/api/HomeCinemaWebApi/Bass/" + id,
            type: "PUT",
            success: function () {
                $.ajax({
                    url: "/api/HomeCinemaWebApi/" + id,
                    type: "GET",
                    success: function (data) {
                        repaint(data);
                    }
                });
            }
        });
    });
    $(".homeCinema .threeD").click(function (event) {
        event.preventDefault();
        var device = $(event.target).closest(".item")[0];
        var id = $(device).find(".hidden").val();
        $.ajax({
            url: "/api/HomeCinemaWebApi/ThreeDOnOff/" + id,
            type: "PUT",
            success: function () {
                $.ajax({
                    url: "/api/HomeCinemaWebApi/" + id,
                    type: "GET",
                    success: function (data) {
                        repaint(data);
                    }
                });
            }
        });
    });
});

function repaint(data) {
    var newView = $("<div/>", {
        id: data.Position
    });
    var oldView = $("#" + data.Position);
    $(newView).addClass("item homeCinema");
    $("<input/>", {
        type: "hidden",
        "class": "hidden",
        value: data.Id
    }).appendTo(newView);
    $("<a/>", {
        "class": "delete",
        href: "/HomeCinema/Delete/" + data.Id
    }).appendTo("<div/>").appendTo(newView);
    $(oldView).replaceWith(newView);
}