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
    public static class IBassHelper
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
            string className = device.GetType().Name;
            if (!className.Contains("_"))
            {
                div.InnerHtml += helper.ActionLink(" ", "Bass", device.GetType().Name, new { id = device.Id },
                    new { @class = "control bass" });
            }
            else
            {
                div.InnerHtml += helper.ActionLink(" ", "Bass", device.GetType().BaseType.Name, new { id = device.Id },
                    new { @class = "control bass" });
            }
            return new MvcHtmlString(div.ToString());
        }
        public static MvcHtmlString CreateIndicator(this HtmlHelper helper, Device device)
        {
            TagBuilder img = new TagBuilder("img");
            img.AddCssClass("indicator");
            if ((device as IBass).BassState && device.SwitchState)
            {
                img.AddCssClass("visible");
            }
            else
            {
                img.AddCssClass("invisible");
            }
            img.MergeAttribute("src", "/Css/Controls/bassind.png");
            img.MergeAttribute("alt", "Bass");
            return new MvcHtmlString(img.ToString());
        }
    }
}