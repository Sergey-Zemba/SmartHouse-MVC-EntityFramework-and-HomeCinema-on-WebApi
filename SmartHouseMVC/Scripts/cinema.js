$(document).ready(function () {
    $(".homeCinema .delete").click(function (event) { remove(event); });
    $(".homeCinema .onOff").click(function (event) { onOff(event); });
    $(".homeCinema .addVolume").click(function (event) { addVolume(event); });
    $(".homeCinema .decreaseVolume").click(function (event) { decreaseVolume(event); });
    $(".homeCinema .mute").click(function (event) { mute(event); });
    $(".homeCinema .rec").click(function (event) { rec(event); });
    $(".homeCinema .bass").click(function (event) { bass(event); });
    $(".homeCinema .threeD").click(function (event) { threeD(event); });
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
    var removeControl = $("<a/>", {
        "class": "delete",
        href: "/HomeCinema/Delete/" + data.Id
    });
    $(removeControl).click(function (event) { remove(event); });
    $("<div/>").append(removeControl).appendTo(newView);

    var indicators = $("<div/>");
    $(indicators).addClass("indicators");

    var muteIndicator = $("<img/>", {
        "class": "indicator",
        src: "/Css/Controls/muteind.png",
        alt: "Mute"
    });
    if ((data.MuteState === true) && (data.SwitchState === true)) {
        $(muteIndicator).addClass("visible");
    }
    else {
        $(muteIndicator).addClass("invisible");
    }
    $(muteIndicator).appendTo(indicators);

    var recordingIndicator = $("<img/>", {
        "class": "indicator",
        src: "/Css/Controls/recind.jpg",
        alt: "Rec"
    });
    if ((data.RecordMode === true) && (data.SwitchState === true)) {
        $(recordingIndicator).addClass("visible");
    }
    else {
        $(recordingIndicator).addClass("invisible");
    }
    $(recordingIndicator).appendTo(indicators);

    var bassIndicator = $("<img/>", {
        "class": "indicator",
        src: "/Css/Controls/bassind.png",
        alt: "Bass"
    });
    if ((data.BassState === true) && (data.SwitchState === true)) {
        $(bassIndicator).addClass("visible");
    }
    else {
        $(bassIndicator).addClass("invisible");
    }
    $(bassIndicator).appendTo(indicators);

    var threeDIndicator = $("<img/>", {
        "class": "indicator",
        src: "/Css/Controls/3Dind.png",
        alt: "3D"
    });
    if ((data.ThreeDMode === true) && (data.SwitchState === true)) {
        $(threeDIndicator).addClass("visible");
    }
    else {
        $(threeDIndicator).addClass("invisible");
    }
    $(threeDIndicator).appendTo(indicators);

    $(indicators).appendTo(newView);

    var controls = $("<div/>");
    $(controls).addClass("controls");

    var onOffControl;
    if (data.SwitchState === true) {
        onOffControl = $("<a/>", {
            "class": "control on onOff",
            href: "/HomeCinema/OnOff/" + data.Id
        });
    }
    else {
        onOffControl = $("<a/>", {
            "class": "control off onOff",
            href: "/HomeCinema/OnOff/" + data.Id
        });
    }
    $(onOffControl).click(function (event) { onOff(event); });
    $("<div/>").append(onOffControl).appendTo(controls);

    var volumePanel = $("<div>");
    if (data.SwitchState === true) {
        $(volumePanel).addClass("visible");
    }
    else {
        $(volumePanel).addClass("invisible");
    }
    var volume = $("<span/>");
    $(volume).addClass("control").html(data.CurrentVolume);
    $(volumePanel).append(volume);
    var up = $("<a/>", {
        "class": "control up addVolume",
        href: "/HomeCinema/AddVolume/" + data.Id
    });
    $(up).click(function (event) { addVolume(event); });
    var down = $("<a/>", {
        "class": "control down decreaseVolume",
        href: "/HomeCinema/DecreaseVolume/" + data.Id
    });
    $(down).click(function (event) { decreaseVolume(event); });
    var muteControl = $("<a/>", {
        "class": "control mute",
        href: "/HomeCinema/Mute/" + data.Id
    });
    $(muteControl).click(function (event) { mute(event); });
    $(volumePanel).append(up);
    $(volumePanel).append(down);
    $(volumePanel).append(muteControl);
    $(volumePanel).appendTo(controls);
    
    var recordingPanel = $("<div>");
    if (data.SwitchState === true) {
        $(recordingPanel).addClass("visible");
    }
    else {
        $(recordingPanel).addClass("invisible");
    }
    var recControl = $("<a/>", {
        "class": "control rec",
        href: "/HomeCinema/Rec/" + data.Id
    });
    $(recControl).click(function (event) { rec(event); });
    $(recordingPanel).append(recControl);
    $(recordingPanel).appendTo(controls);

    var bassPanel = $("<div>");
    if (data.SwitchState === true) {
        $(bassPanel).addClass("visible");
    }
    else {
        $(bassPanel).addClass("invisible");
    }
    var bassControl = $("<a/>", {
        "class": "control bass",
        href: "/HomeCinema/Bass/" + data.Id
    });
    $(bassControl).click(function (event) { bass(event); });
    $(bassPanel).append(bassControl);
    $(bassPanel).appendTo(controls);

    var threeDPanel = $("<div>");
    if (data.SwitchState === true) {
        $(threeDPanel).addClass("visible");
    }
    else {
        $(threeDPanel).addClass("invisible");
    }
    var threeDControl = $("<a/>", {
        "class": "control threeD",
        href: "/HomeCinema/ThreeDOnOff/" + data.Id
    });
    $(threeDControl).click(function (event) { threeD(event); });
    $(threeDPanel).append(threeDControl);
    $(threeDPanel).appendTo(controls);
    $(controls).appendTo(newView);
    $(oldView).replaceWith(newView);
}

function remove(event) {
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
}

function onOff(event) {
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
}

function addVolume(event) {
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
}

function decreaseVolume(event) {
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
}

function mute(event) {
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
}
function rec(event) {
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
}

function bass(event) {
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
}

function threeD(event) {
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
}