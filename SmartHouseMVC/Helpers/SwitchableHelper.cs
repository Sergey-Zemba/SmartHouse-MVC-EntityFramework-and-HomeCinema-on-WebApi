using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using SmartHouseMVC.Models.SmartHouse.Devices;

namespace SmartHouseMVC.Helpers
{
    public static class SwitchableHelper
    {
        public static MvcHtmlString CreateControl(this HtmlHelper helper, Device device)
        {
            TagBuilder div = new TagBuilder("div");
            string className = device.GetType().Name;
            if (device.SwitchState)
            {
                if (!className.Contains("_"))
                {
                    div.InnerHtml += helper.ActionLink(" ", "OnOff", device.GetType().Name, new { id = device.Id },
                        new { @class = "control on onOff" });
                }
                else
                {
                    div.InnerHtml += helper.ActionLink(" ", "OnOff", device.GetType().BaseType.Name, new { id = device.Id },
                        new { @class = "control on onOff" });
                }
            }
            else
            {
                if (!className.Contains("_"))
                {
                    div.InnerHtml += helper.ActionLink(" ", "OnOff", device.GetType().Name, new { id = device.Id },
                        new { @class = "control off onOff" });
                }
                else
                {
                    div.InnerHtml += helper.ActionLink(" ", "OnOff", device.GetType().BaseType.Name, new { id = device.Id },
                        new { @class = "control off onOff" });
                }
            }
            return new MvcHtmlString(div.ToString());
        }
    }
}