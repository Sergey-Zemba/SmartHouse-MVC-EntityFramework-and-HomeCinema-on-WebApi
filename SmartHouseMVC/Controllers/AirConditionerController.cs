using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartHouseMVC.Models;
using SmartHouseMVC.Models.SmartHouse.Devices;

namespace SmartHouseMVC.Controllers
{
    public class AirConditionerController : Controller
    {
        DeviceContext context = new DeviceContext();
        // GET: AirConditioner
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Delete(int id)
        {
            AirConditioner conditioner = context.AirConditioners.Find(id);
            context.AirConditioners.Remove(conditioner);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}