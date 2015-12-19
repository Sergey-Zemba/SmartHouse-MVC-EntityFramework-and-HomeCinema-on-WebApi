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
    public static class IVolumeableHelper
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
            
            TagBuilder span = new TagBuilder("span");
            span.AddCssClass("control");
            span.InnerHtml = (device as IVolumeable).CurrentVolume.ToString();
            div.InnerHtml += span.ToString();
            string className = device.GetType().Name;
            if (!className.Contains("_"))
            {
                div.InnerHtml += helper.ActionLink(" ", "AddVolume", device.GetType().Name, new { id = device.Id },
                    new { @class = "control up" });
                div.InnerHtml += helper.ActionLink(" ", "DecreaseVolume", device.GetType().Name, new { id = device.Id },
                    new { @class = "control down" });
                div.InnerHtml += helper.ActionLink(" ", "Mute", device.GetType().Name, new { id = device.Id },
                    new { @class = "control mute" });
            }
            else
            {
                div.InnerHtml += helper.ActionLink(" ", "AddVolume", device.GetType().BaseType.Name, new { id = device.Id },
                    new { @class = "control up" });
                div.InnerHtml += helper.ActionLink(" ", "DecreaseVolume", device.GetType().BaseType.Name, new { id = device.Id },
                    new { @class = "control down" });
                div.InnerHtml += helper.ActionLink(" ", "Mute", device.GetType().BaseType.Name, new { id = device.Id },
                    new { @class = "control mute" });
            }
            return new MvcHtmlString(div.ToString());
        }
        public static MvcHtmlString CreateIndicator(this HtmlHelper helper, Device device)
        {
            TagBuilder img = new TagBuilder("img");
            img.AddCssClass("indicator");
            if ((device as IVolumeable).MuteState && device.SwitchState)
            {
                img.AddCssClass("visible");
            }
            else
            {
                img.AddCssClass("invisible");
            }
            img.MergeAttribute("src", "/Css/Controls/muteind.png");
            img.MergeAttribute("alt", "Mute");
            return new MvcHtmlString(img.ToString());
        }
    }
}