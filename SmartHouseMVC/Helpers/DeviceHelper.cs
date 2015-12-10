using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using SmartHouseMVC.Models.SmartHouse.Devices;
using SmartHouseMVC.Models.SmartHouse.States;
using SmartHouseMVC.Models.SmartHouse.Interfaces;

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
            }
            TagBuilder delete = new TagBuilder("input");
            delete.AddCssClass("delete");
            delete.MergeAttribute("type", "image");
            delete.MergeAttribute("src", "/Css/Controls/Delete.png");
            item.InnerHtml += delete.ToString();
            TagBuilder indicators = new TagBuilder("div");
            indicators.AddCssClass("indicators");
            TagBuilder indicator = null;
            if (device is IRecording)
            {
                indicator = new TagBuilder("img");
                indicator.AddCssClass("indicator");
                indicator.MergeAttribute("src", "/Css/Controls/recind.jpg");
                indicator.MergeAttribute("alt", "Recording");
                if ((device as IRecording).RecordMode == RecordMode.Record)
                {
                    indicator.MergeAttribute("hidden", "false");
                }
                else
                {
                    indicator.MergeAttribute("hidden", "true");
                }
                indicators.InnerHtml += indicator.ToString();
            }
            if (device is IVolumeable)
            {
                indicator = new TagBuilder("img");
                indicator.AddCssClass("indicator");
                indicator.MergeAttribute("src", "/Css/Controls/muteind.png");
                indicator.MergeAttribute("alt", "Mute");
                if ((device as IVolumeable).MuteState == MuteState.MuteOn)
                {
                    indicator.MergeAttribute("hidden", "false");
                }
                else
                {
                    indicator.MergeAttribute("hidden", "true");
                }
                indicators.InnerHtml += indicator.ToString();
            }
            if (device is IBass)
            {
                indicator = new TagBuilder("img");
                indicator.AddCssClass("indicator");
                indicator.MergeAttribute("src", "/Css/Controls/bassind.png");
                indicator.MergeAttribute("alt", "Bass");
                if ((device as IBass).BassState == BassState.On)
                {
                    indicator.MergeAttribute("hidden", "false");
                }
                else
                {
                    indicator.MergeAttribute("hidden", "true");
                }
                indicators.InnerHtml += indicator.ToString();
            }
            
            if (device is IThreeDimensional)
            {
                indicator = new TagBuilder("img");
                indicator.AddCssClass("indicator");
                indicator.MergeAttribute("src", "/Css/Controls/3Dind.png");
                indicator.MergeAttribute("alt", "3D");
                if ((device as IThreeDimensional).Mode == TvMode.ThreeDMode)
                {
                    indicator.MergeAttribute("hidden", "false");
                }
                else
                {
                    indicator.MergeAttribute("hidden", "true");
                }
                indicators.InnerHtml += indicator.ToString();
            }
            item.InnerHtml += indicators.ToString();
            TagBuilder controls = new TagBuilder("div");
            controls.AddCssClass("controls");
            TagBuilder control = new TagBuilder("input");
            control.AddCssClass("control");
            control.MergeAttribute("type", "image");
            if (device.SwitchState == SwitchState.On)
            {
                control.MergeAttribute("src", "/Css/Controls/On.png");
            }
            else
            {
                control.MergeAttribute("src", "/Css/Controls/Off.png");
            }
            controls.InnerHtml += control.ToString();
            if (device is ITemperature)
            {
                control = new TagBuilder("div");
                control.AddCssClass("control");
                if (device.SwitchState == SwitchState.On)
                {
                    control.MergeAttribute("hidden", "false");
                }
                else
                {
                    control.MergeAttribute("hidden", "true");
                }
                TagBuilder img = new TagBuilder("img");
            }
            item.InnerHtml += controls.ToString();
            return new MvcHtmlString(item.ToString());
        }
    }
}