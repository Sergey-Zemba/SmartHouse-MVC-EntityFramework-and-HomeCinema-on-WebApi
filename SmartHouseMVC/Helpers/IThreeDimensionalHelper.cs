using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Razor.Generator;
using SmartHouseMVC.Models.SmartHouse.Devices;
using SmartHouseMVC.Models.SmartHouse.Interfaces;

namespace SmartHouseMVC.Helpers
{
    public static class IThreeDimensionalHelper
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
            div.InnerHtml += helper.ActionLink(" ", "ThreeDOnOff", device.GetType().Name, new { id = device.Id },
                new { @class = "control threeD" });
            return new MvcHtmlString(div.ToString());
        }

        public static MvcHtmlString CreateIndicator(this HtmlHelper helper, Device device)
        {
            TagBuilder img = new TagBuilder("img");
            img.AddCssClass("indicator");
            if ((device as IThreeDimensional).ThreeDMode)
            {
                img.AddCssClass("visible");
            }
            else
            {
                img.AddCssClass("invisible");
            }
            img.MergeAttribute("src", "/Css/Controls/3Dind.png");
            img.MergeAttribute("alt", "3D");
            return new MvcHtmlString(img.ToString());
        }
    }
}