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
    public class FridgeController : Controller
    {
        DeviceContext context = new DeviceContext();
        // GET: Camera
        public ActionResult Fridge()
        {
            return View();
        }
        public ActionResult Delete(int id)
        {
            Fridge fridge = context.Fridges.Find(id);
            context.Fridges.Remove(fridge);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult OnOff(int id)
        {
            Fridge fridge = context.Fridges.Find(id);
            if (fridge.SwitchState)
            {
                fridge.Off();
            }
            else
            {
                fridge.On();
            }
            context.Entry(fridge).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult OpenClose(int id)
        {
            Fridge fridge = context.Fridges.Find(id);
            if (fridge.OpenState)
            {
                fridge.Close();
            }
            else
            {
                fridge.Open();
            }
            context.Entry(fridge).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Warmer(int id)
        {
            Fridge fridge = context.Fridges.Find(id);
            fridge.AddTemperture();
            context.Entry(fridge).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Cooler(int id)
        {
            Fridge fridge = context.Fridges.Find(id);
            fridge.DecreaseTemperature();
            context.Entry(fridge).State = EntityState.Modified;
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