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
            TagBuilder delete = new TagBuilder("button");
            delete.AddCssClass("test");
            delete.MergeAttribute("name", "action");
            delete.MergeAttribute("value", "delete");
            delete.MergeAttribute("id", "delete");
            item.InnerHtml += delete.ToString();
            TagBuilder indicators = new TagBuilder("div");
            indicators.AddCssClass("indicators");
            TagBuilder indicator;
            if (device is IRecording)
            {
                indicator = new TagBuilder("img");
                indicator.MergeAttribute("src", "/Css/Controls/recind.jpg");
                indicator.MergeAttribute("alt", "Recording");
                if ((device as IRecording).RecordMode == RecordMode.Record)
                {
                    indicator.AddCssClass("indicator visible");
                }
                else
                {
                    indicator.AddCssClass("indicator invisible");
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
                    indicator.AddCssClass("indicator visible");
                }
                else
                {
                    indicator.AddCssClass("indicator invisible");
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
                    indicator.AddCssClass("indicator visible");
                }
                else
                {
                    indicator.AddCssClass("indicator invisible");
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
                    indicator.AddCssClass("indicator visible");
                }
                else
                {
                    indicator.AddCssClass("indicator invisible");
                }
                indicators.InnerHtml += indicator.ToString();
            }
            item.InnerHtml += indicators.ToString();
            TagBuilder controls = new TagBuilder("div");
            controls.AddCssClass("controls");
            TagBuilder control = new TagBuilder("button");
            control.AddCssClass("control test");
            control.MergeAttribute("name", "action");
            control.MergeAttribute("value", "onoff");
            if (device.SwitchState == SwitchState.On)
            {
                control.MergeAttribute("id", "on");
            }
            else
            {
                control.MergeAttribute("id", "off");
            }
            controls.InnerHtml += control.ToString();
            if (device is ITemperature)
            {
                control = new TagBuilder("div");
                if (device.SwitchState == SwitchState.On)
                {
                    control.AddCssClass("control visible");
                }
                else
                {
                    control.AddCssClass("control invisible");
                }
                TagBuilder img = new TagBuilder("img");
                img.MergeAttribute("src", "/Css/Controls/TempIcon.png");
                img.MergeAttribute("alt", "temp");
                control.InnerHtml += img.ToString();
                TagBuilder span = new TagBuilder("span");
                span.InnerHtml += (device as ITemperature).CurrentTemperature + "°C";
                control.InnerHtml += span.ToString();
                TagBuilder tempReg = new TagBuilder("input");
                tempReg.MergeAttribute("type", "image");
                tempReg.MergeAttribute("src", "/Css/Controls/Up.png");
                control.InnerHtml += tempReg.ToString();
                tempReg = new TagBuilder("input");
                tempReg.MergeAttribute("type", "image");
                tempReg.MergeAttribute("src", "/Css/Controls/Down.png");
                control.InnerHtml += tempReg.ToString();
                controls.InnerHtml += control.ToString();
            }
            if (device is IVolumeable)
            {
                control = new TagBuilder("div");
                if (device.SwitchState == SwitchState.On)
                {
                    control.AddCssClass("control visible");
                }
                else
                {
                    control.AddCssClass("control invisible");
                }
                TagBuilder span = new TagBuilder("span");
                span.InnerHtml += (device as IVolumeable).CurrentVolume;
                control.InnerHtml += span.ToString();
                TagBuilder volpReg = new TagBuilder("input");
                volpReg.MergeAttribute("type", "image");
                volpReg.MergeAttribute("src", "/Css/Controls/Up.png");
                control.InnerHtml += volpReg.ToString();
                volpReg = new TagBuilder("input");
                volpReg.MergeAttribute("type", "image");
                volpReg.MergeAttribute("src", "/Css/Controls/Down.png");
                control.InnerHtml += volpReg.ToString();
                volpReg = new TagBuilder("input");
                volpReg.MergeAttribute("type", "image");
                volpReg.MergeAttribute("src", "/Css/Controls/Mute.png");
                control.InnerHtml += volpReg.ToString();
                controls.InnerHtml += control.ToString();
            }
            if (device is IBass)
            {
                control = new TagBuilder("div");
                if (device.SwitchState == SwitchState.On)
                {
                    control.AddCssClass("control visible");
                }
                else
                {
                    control.AddCssClass("control invisible");
                }
                TagBuilder bass = new TagBuilder("input");
                bass.MergeAttribute("type", "image");
                bass.MergeAttribute("src", "/Css/Controls/Bass.png");
                control.InnerHtml += bass.ToString();
                controls.InnerHtml += control.ToString();
            }
            if (device is IOpenable)
            {
                control = new TagBuilder("div");
                if (device.SwitchState == SwitchState.On)
                {
                    control.AddCssClass("control visible");
                }
                else
                {
                    control.AddCssClass("control invisible");
                }
                TagBuilder locked = new TagBuilder("input");
                locked.MergeAttribute("type", "image");
                if ((device as IOpenable).OpenState == OpenState.Open)
                {
                    locked.MergeAttribute("src", "/Css/Controls/Open.png");
                }
                else
                {
                    locked.MergeAttribute("src", "/Css/Controls/Close.png");
                }
                control.InnerHtml += locked.ToString();
                controls.InnerHtml += control.ToString();
            }
            if (device is IRecording)
            {
                control = new TagBuilder("div");
                if (device.SwitchState == SwitchState.On)
                {
                    control.AddCssClass("control visible");
                }
                else
                {
                    control.AddCssClass("control invisible");
                }
                TagBuilder rec = new TagBuilder("input");
                rec.MergeAttribute("type", "image");
                rec.MergeAttribute("src", "/Css/Controls/Rec.png");
                control.InnerHtml += rec.ToString();
                controls.InnerHtml += control.ToString();
            }
            if (device is IThreeDimensional)
            {
                control = new TagBuilder("div");
                if (device.SwitchState == SwitchState.On)
                {
                    control.AddCssClass("control visible");
                }
                else
                {
                    control.AddCssClass("control invisible");
                }
                TagBuilder threeD = new TagBuilder("input");
                threeD.MergeAttribute("type", "image");
                threeD.MergeAttribute("src", "/Css/Controls/3D.png");
                control.InnerHtml += threeD.ToString();
                controls.InnerHtml += control.ToString();
            }
            item.InnerHtml += controls.ToString();
            return new MvcHtmlString(item.ToString());
        }
    }
}