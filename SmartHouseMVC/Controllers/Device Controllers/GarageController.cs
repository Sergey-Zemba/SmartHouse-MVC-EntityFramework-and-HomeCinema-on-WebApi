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
    public class GarageController : Controller
    {
        DeviceContext context = new DeviceContext();
        public ActionResult Delete(int id)
        {
            Garage garage = context.Garages.Find(id);
            context.Garages.Remove(garage);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult OnOff(int id)
        {
            Garage garage = context.Garages.Find(id);
            if (garage.SwitchState)
            {
                garage.Off();
            }
            else
            {
                garage.On();
            }
            context.Entry(garage).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult OpenClose(int id)
        {
            Garage garage = context.Garages.Find(id);
            if (garage.OpenState)
            {
                garage.Close();
            }
            else
            {
                garage.Open();
            }
            context.Entry(garage).State = EntityState.Modified;
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