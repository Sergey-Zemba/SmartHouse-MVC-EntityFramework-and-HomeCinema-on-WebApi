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
    public static class RecordingHelper
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
                div.InnerHtml += helper.ActionLink(" ", "Rec", device.GetType().Name, new { id = device.Id },
                    new { @class = "control rec" });
            }
            else
            {
                div.InnerHtml += helper.ActionLink(" ", "Rec", device.GetType().BaseType.Name, new { id = device.Id },
                    new { @class = "control rec" });
            }
            return new MvcHtmlString(div.ToString());
        }
        public static MvcHtmlString CreateIndicator(this HtmlHelper helper, Device device)
        {
            TagBuilder img = new TagBuilder("img");
            img.AddCssClass("indicator");
            if ((device as IRecording).RecordMode && device.SwitchState)
            {
                img.AddCssClass("visible");
            }
            else
            {
                img.AddCssClass("invisible");
            }
            img.MergeAttribute("src", "/Css/Controls/recind.jpg");
            img.MergeAttribute("alt", "Rec");
            return new MvcHtmlString(img.ToString());
        }
    }
}