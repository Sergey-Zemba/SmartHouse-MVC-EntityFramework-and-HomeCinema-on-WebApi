using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        public ActionResult DoAction(string action)
        {
            switch (action)
            {
                case "addAirConditioner":
                    model.Add("conditioner");
                    break;
                case "addCamera":
                    model.Add("camera");
                    break;
                case "addFridge":
                    model.Add("fridge");
                    break;
                case "addGarage":
                    model.Add("garage");
                    break;
                case "addPanasonicHomeCinema":
                    model.Add("panasonicCinema");
                    break;
                case "addSamsungHomeCinema":
                    model.Add("samsungCinema");
                    break;
                case "addPanasonicLoudspeakers":
                    model.Add("panasonicLoudspeakers");
                    break;
                case "addSamsungLoudspeakers":
                    model.Add("samsungLoudspeakers");
                    break;
                case "addPanasonicTv":
                    model.Add("panasonicTv");
                    break;
                case "addSamsungTv":
                    model.Add("samsungTv");
                    break;
                case "delete":
                    model.Delete(1);
                    break;
            }
            return RedirectToAction("Index");
        }

        //public ActionResult DoAction(string action, int id)
        //{
        //    switch (action)
        //    {
        //        case "delete":
        //            model.Delete(id);
        //            break;
        //    }
        //    return RedirectToAction("Index");
        //}

    }
}