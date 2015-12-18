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
    public class HomeCinemaController : Controller
    {
        DeviceContext context = new DeviceContext();
        // GET: AirConditioner
        public ActionResult HomeCinema()
        {
            return View();
        }
        public ActionResult Delete(int id)
        {
            HomeCinema homeCinema = context.HomeCinemas.Find(id);
            context.HomeCinemas.Remove(homeCinema);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult OnOff(int id)
        {
            HomeCinema homeCinema = context.HomeCinemas.Find(id);
            if (homeCinema.SwitchState)
            {
                homeCinema.Off();
            }
            else
            {
                homeCinema.On();
            }
            context.Entry(homeCinema).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult AddVolume(int id)
        {
            HomeCinema homeCinema = context.HomeCinemas.Find(id);
            homeCinema.AddVolume();
            context.Entry(homeCinema).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult DecreaseVolume(int id)
        {
            HomeCinema homeCinema = context.HomeCinemas.Find(id);
            homeCinema.DecreaseVolume();
            context.Entry(homeCinema).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Mute(int id)
        {
            HomeCinema homeCinema = context.HomeCinemas.Find(id);
            if (homeCinema.MuteState)
            {
                homeCinema.MuteOff();
            }
            else
            {
                homeCinema.MuteOn();
            }
            context.Entry(homeCinema).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Rec(int id)
        {
            HomeCinema homeCinema = context.HomeCinemas.Find(id);
            if (homeCinema.RecordMode)
            {
                homeCinema.StopRecording();
            }
            else
            {
                homeCinema.StartRecording();
            }
            context.Entry(homeCinema).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Bass(int id)
        {
            HomeCinema homeCinema = context.HomeCinemas.Find(id);
            if (homeCinema.BassState)
            {
                homeCinema.BassOff();
            }
            else
            {
                homeCinema.BassOn();
            }
            context.Entry(homeCinema).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult ThreeDOnOff(int id)
        {
            HomeCinema homeCinema = context.HomeCinemas.Find(id);
            if (homeCinema.ThreeDMode)
            {
                homeCinema.ThreeDOff();
            }
            else
            {
                homeCinema.ThreeDOn();
            }
            context.Entry(homeCinema).State = EntityState.Modified;
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