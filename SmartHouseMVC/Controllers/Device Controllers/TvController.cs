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
    public class TvController : Controller
    {
        DeviceContext context = new DeviceContext();
        public ActionResult Delete(int id)
        {
            Tv tv = context.Tvs.Find(id);
            context.Tvs.Remove(tv);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult OnOff(int id)
        {
            Tv tv = context.Tvs.Find(id);
            if (tv.SwitchState)
            {
                tv.Off();
            }
            else
            {
                tv.On();
            }
            context.Entry(tv).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult AddVolume(int id)
        {
            Tv tv = context.Tvs.Find(id);
            tv.AddVolume();
            context.Entry(tv).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult DecreaseVolume(int id)
        {
            Tv tv = context.Tvs.Find(id);
            tv.DecreaseVolume();
            context.Entry(tv).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Mute(int id)
        {
            Tv tv = context.Tvs.Find(id);
            if (tv.MuteState)
            {
                tv.MuteOff();
            }
            else
            {
                tv.MuteOn();
            }
            context.Entry(tv).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Rec(int id)
        {
            Tv tv = context.Tvs.Find(id);
            if (tv.RecordMode)
            {
                tv.StopRecording();
            }
            else
            {
                tv.StartRecording();
            }
            context.Entry(tv).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ThreeDOnOff(int id)
        {
            Tv tv = context.Tvs.Find(id);
            if (tv.ThreeDMode)
            {
                tv.ThreeDOff();
            }
            else
            {
                tv.ThreeDOn();
            }
            context.Entry(tv).State = EntityState.Modified;
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