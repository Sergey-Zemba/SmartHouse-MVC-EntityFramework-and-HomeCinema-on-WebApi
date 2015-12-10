using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using SmartHouseMVC.Models.SmartHouse.Devices;

namespace SmartHouseMVC.Helpers
{
    public static class DeviceHelper
    {
        public static MvcHtmlString CreateDevice(this HtmlHelper helper, Device device)
        {
            TagBuilder item = new TagBuilder("div");
            item.AddCssClass("item");
            if (device is AirConditioner)
            {
                item.AddCssClass("airConditioner");
            }
            else if (device is Camera)
            {
                item.AddCssClass("camera");
            }
            else if (device is Fridge)
            {
                item.AddCssClass("fridge");
            }
            else if (device is Garage)
            {
                item.AddCssClass("garage");
            }
            else if (device is PanasonicHomeCinema)
            {
                item.AddCssClass("panasonicHomeCinema");
            }
            else if (device is SamsungHomeCinema)
            {
                item.AddCssClass("samsungHomeCinema");
            }
            else if (device is PanasonicLoudspeakers)
            {
                item.AddCssClass("panasonicLoudspeakers");
            }
            else if (device is SamsungLoudspeakers)
            {
                item.AddCssClass("samsungLoudspeakers");
            }
            else if (device is PanasonicTv)
            {
                item.AddCssClass("panasonicTv");
            }
            else if (device is SamsungTv)
            {
                item.AddCssClass("samsungTv");
                //item.MergeAttribute("id", "samsungTv");
            }
            TagBuilder imageButton = new TagBuilder("input");
            imageButton.MergeAttribute("type", "image");
            imageButton.MergeAttribute("src", "/Css/Controls/Delete.png");
            imageButton.AddCssClass("delete");
            item.InnerHtml += imageButton.ToString();
            TagBuilder indicators = new TagBuilder("div");
            indicators.AddCssClass("indicators");
            TagBuilder indicator = new TagBuilder("img");
            indicator.AddCssClass("indicator");
            indicator.MergeAttribute("src", "/Css/Controls/recind.jpg");
            indicator.MergeAttribute("alt", "Recording");
            indicator.MergeAttribute("hidden", "true");
            indicators.InnerHtml += indicator.ToString();
            indicator = new TagBuilder("img");
            indicator.AddCssClass("indicator");
            indicator.MergeAttribute("src", "/Css/Controls/muteind.png");
            indicator.MergeAttribute("alt", "Mute");
            indicator.MergeAttribute("hidden", "true");
            indicators.InnerHtml += indicator.ToString();
            indicator = new TagBuilder("img");
            indicator.AddCssClass("indicator");
            indicator.MergeAttribute("src", "/Css/Controls/bassind.png");
            indicator.MergeAttribute("alt", "Bass");
            indicator.MergeAttribute("hidden", "true");
            indicators.InnerHtml += indicator.ToString();
            indicator = new TagBuilder("img");
            indicator.AddCssClass("indicator");
            indicator.MergeAttribute("src", "/Css/Controls/3Dind.png");
            indicator.MergeAttribute("alt", "3D");
            indicator.MergeAttribute("hidden", "true");
            indicators.InnerHtml += indicator.ToString();
            item.InnerHtml += indicators.ToString();
            return new MvcHtmlString(item.ToString());
        }
    }
}