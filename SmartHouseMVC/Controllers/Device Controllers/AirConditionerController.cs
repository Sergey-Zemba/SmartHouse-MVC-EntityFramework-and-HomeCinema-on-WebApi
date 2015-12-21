using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public ActionResult Conditioner()
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
        public ActionResult OnOff(int id)
        {
            AirConditioner conditioner = context.AirConditioners.Find(id);
            if (conditioner.SwitchState)
            {
                conditioner.Off();
            }
            else
            {
                conditioner.On();
            }
            context.Entry(conditioner).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Warmer(int id)
        {
            AirConditioner conditioner = context.AirConditioners.Find(id);
            conditioner.AddTemperture();
            context.Entry(conditioner).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Cooler(int id)
        {
            AirConditioner conditioner = context.AirConditioners.Find(id);
            conditioner.DecreaseTemperature();
            context.Entry(conditioner).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}