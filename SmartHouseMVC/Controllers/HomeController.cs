using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartHouseMVC.Attributes;
using SmartHouseMVC.Models;

namespace SmartHouseMVC.Controllers
{
    public class HomeController : Controller
    {
        DeviceListModel model = new DeviceListModel();

        public ActionResult Index()
        {
            return View(model.GetDevices());
        }
        [HttpPost]
        [MultipleButton(Name = "add", Argument = "AirConditioner")]
        public ActionResult AddAirConditioner()
        {
            model.Add("conditioner");
            return RedirectToAction("Index");
        }
        [HttpPost]
        [MultipleButton(Name = "add", Argument = "Camera")]
        public ActionResult AddCamera()
        {
            model.Add("camera");
            return RedirectToAction("Index");
        }
        [HttpPost]
        [MultipleButton(Name = "add", Argument = "Fridge")]
        public ActionResult AddFridge()
        {
            model.Add("fridge");
            return RedirectToAction("Index");
        }
        [HttpPost]
        [MultipleButton(Name = "add", Argument = "Garage")]
        public ActionResult AddGarage()
        {
            model.Add("garage");
            return RedirectToAction("Index");
        }
        [HttpPost]
        [MultipleButton(Name = "add", Argument = "PanasonicHomeCinema")]
        public ActionResult AddPanasonicHomeCinema()
        {
            model.Add("panasonicCinema");
            return RedirectToAction("Index");
        }
        [HttpPost]
        [MultipleButton(Name = "add", Argument = "SamsungHomeCinema")]
        public ActionResult AddSamsungHomeCinema()
        {
            model.Add("samsungCinema");
            return RedirectToAction("Index");
        }
        [HttpPost]
        [MultipleButton(Name = "add", Argument = "PanasonicLoudspeakers")]
        public ActionResult AddPanasonicLoudspeakers()
        {
            model.Add("panasonicLoudspeakers");
            return RedirectToAction("Index");
        }
        [HttpPost]
        [MultipleButton(Name = "add", Argument = "SamsungLoudspeakers")]
        public ActionResult AddSamsungLoudspeakers()
        {
            model.Add("samsungLoudspeakers");
            return RedirectToAction("Index");
        }
        [HttpPost]
        [MultipleButton(Name = "add", Argument = "PanasonicTv")]
        public ActionResult AddPanasonicTv()
        {
            model.Add("panasonicTv");
            return RedirectToAction("Index");
        }
        [HttpPost]
        [MultipleButton(Name = "add", Argument = "SamsungTv")]
        public ActionResult AddSamsungTv()
        {
            model.Add("samsungTv");
            return RedirectToAction("Index");
        }
    }
}