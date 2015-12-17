﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using SmartHouseMVC.Models.SmartHouse.Devices;

namespace SmartHouseMVC.Helpers
{
    public static class ISwitchableHelper
    {
        public static MvcHtmlString CreateControl(this HtmlHelper helper, Device device)
        {
            TagBuilder div = new TagBuilder("div");
            if (device.SwitchState)
            {
                div.InnerHtml += helper.ActionLink(" ", "OnOff", device.GetType().Name, new { id = device.Id },
                    new { @class = "control on" });
            }
            else
            {
                div.InnerHtml += helper.ActionLink(" ", "OnOff", device.GetType().Name, new { id = device.Id },
                    new { @class = "control off" });
            }
            return new MvcHtmlString(div.ToString());
        }
    }
}