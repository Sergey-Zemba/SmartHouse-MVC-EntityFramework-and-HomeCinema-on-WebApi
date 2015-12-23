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
    public static class OpenableHelper
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
            if ((device as IOpenable).OpenState)
            {
                if (!className.Contains("_"))
                {
                    div.InnerHtml += helper.ActionLink(" ", "OpenClose", device.GetType().Name, new { id = device.Id },
                        new { @class = "control open" });
                }
                else
                {
                    div.InnerHtml += helper.ActionLink(" ", "OpenClose", device.GetType().BaseType.Name, new { id = device.Id },
                        new { @class = "control open" });
                }
            }
            else
            {
                if (!className.Contains("_"))
                {
                    div.InnerHtml += helper.ActionLink(" ", "OpenClose", device.GetType().Name, new { id = device.Id },
                        new { @class = "control close" });
                }
                else
                {
                    div.InnerHtml += helper.ActionLink(" ", "OpenClose", device.GetType().BaseType.Name, new { id = device.Id },
                        new { @class = "control close" });
                }
            }
            return new MvcHtmlString(div.ToString());
        }
    }
}