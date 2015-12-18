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
            devices.AddRange(context.HomeCinemas);
            devices.AddRange(context.Loudspeakerses.Where(l => l.Position != 0));
            devices.AddRange(context.Tvs.Where(t => t.Position != 0));
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
                case "addHomeCinema":
                    context.HomeCinemas.Add(new HomeCinema(position, new Tv(),new Loudspeakers() ));
                    break;
                case "addLoudspeakers":
                    context.Loudspeakerses.Add(new Loudspeakers(position));
                    break;
                case "addTv":
                    context.Tvs.Add((new Tv(position)));
                    break;
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}