using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Microsoft.Ajax.Utilities;
using SmartHouseMVC.Models.SmartHouse.Devices;

namespace SmartHouseMVC.Helpers
{
    public static class DeleteHelper
    {
        public static MvcHtmlString CreateControl(this HtmlHelper helper, Device device)
        {
            TagBuilder div = new TagBuilder("div");
            div.InnerHtml+= helper.ActionLink(" ", "Delete", device.GetType().Name, new { id = device.Id },
               new { @class = "delete" });
            return new MvcHtmlString(div.ToString());
        }
    }
}