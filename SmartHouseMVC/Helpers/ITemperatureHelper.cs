using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using SmartHouseMVC.Models.SmartHouse.Devices;
using SmartHouseMVC.Models.SmartHouse.Interfaces;

namespace SmartHouseMVC.Helpers
{
    public static class ITemperatureHelper
    {
        public static MvcHtmlString CreateControl(this HtmlHelper helper, Device device)
        {
            TagBuilder div = new TagBuilder("div");
            if (device.SwitchState)
            {
                div.AddCssClass("visible");
            }
            else
            {
                div.AddCssClass("invisible");
            }
            TagBuilder img = new TagBuilder("img");
            img.AddCssClass("control");
            img.MergeAttribute("src", "/Css/Controls/TempIcon.png");
            img.MergeAttribute("alt", "temp");
            div.InnerHtml += img.ToString();
            TagBuilder span = new TagBuilder("span");
            span.AddCssClass("control");
            span.InnerHtml = (device as ITemperature).CurrentTemperature + "°C";
            div.InnerHtml += span.ToString();
            div.InnerHtml += helper.ActionLink(" ", "Warmer", device.GetType().Name, new {id = device.Id},
                new {@class = "control up"});
            div.InnerHtml += helper.ActionLink(" ", "Cooler", device.GetType().Name, new { id = device.Id },
                new { @class = "control down" });
            return new MvcHtmlString(div.ToString());
        }
    }
}