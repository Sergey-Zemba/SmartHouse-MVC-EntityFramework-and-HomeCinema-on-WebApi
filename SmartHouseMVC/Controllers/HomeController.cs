using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartHouseMVC.Models;
using SmartHouseMVC.Models.SavingModel;
using SmartHouseMVC.Models.SmartHouse.Devices;

namespace SmartHouseMVC.Controllers
{
    public class HomeController : Controller
    {
        DeviceContext context = new DeviceContext();
        List<Device> devices = new List<Device>();
        IReadingWriting irw = new SessionReadingWriting();

        public ActionResult Index()
        {
            devices.AddRange(context.AirConditioners);
            devices.AddRange(context.Cameras);
            devices.AddRange(context.Fridges);
            devices.AddRange(context.Garages);
            //devices.AddRange(context.PanasonicHomeCinemas);
            //devices.AddRange(context.SamsungHomeCinemas);
            //devices.AddRange(context.PanasonicLoudspeakerses);
            //devices.AddRange(context.SamsungLoudspeakerses);
            //devices.AddRange(context.PanasonicTvs);
            //devices.AddRange(context.SamsungTvs);
            devices = devices.OrderBy(d => d.Position).ToList();
            return View(devices);
        }

        [HttpPost]
        public ActionResult DoAction(string action)
        {
            int position = irw.MakePosition();
            switch (action)
            {
                case "addAirConditioner":
                    context.AirConditioners.Add(new AirConditioner(position));
                    break;
                case "addCamera":
                    context.Cameras.Add(new Camera(position));
                    break;
                case "addFridge":
                    context.Fridges.Add(new Fridge(position));
                    break;
                case "addGarage":
                    context.Garages.Add(new Garage(position));
                    break;
                //case "addPanasonicHomeCinema":
                //    model.Add("panasonicCinema");
                //    break;
                //case "addSamsungHomeCinema":
                //    model.Add("samsungCinema");
                //    break;
                //case "addPanasonicLoudspeakers":
                //    model.Add("panasonicLoudspeakers");
                //    break;
                //case "addSamsungLoudspeakers":
                //    model.Add("samsungLoudspeakers");
                //    break;
                //case "addPanasonicTv":
                //    model.Add("panasonicTv");
                //    break;
                //case "addSamsungTv":
                //    model.Add("samsungTv");
                //    break;
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}