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
    public class LoudspeakersController : Controller
    {
        DeviceContext context = new DeviceContext();
        // GET: AirConditioner
        public ActionResult Loudspeakers()
        {
            return View();
        }
        public ActionResult Delete(int id)
        {
            Loudspeakers loudspeakers = context.Loudspeakerses.Find(id);
            context.Loudspeakerses.Remove(loudspeakers);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult OnOff(int id)
        {
            Loudspeakers loudspeakers = context.Loudspeakerses.Find(id);
            if (loudspeakers.SwitchState)
            {
                loudspeakers.Off();
            }
            else
            {
                loudspeakers.On();
            }
            context.Entry(loudspeakers).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult AddVolume(int id)
        {
            Loudspeakers loudspeakers = context.Loudspeakerses.Find(id);
            loudspeakers.AddVolume();
            context.Entry(loudspeakers).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult DecreaseVolume(int id)
        {
            Loudspeakers loudspeakers = context.Loudspeakerses.Find(id);
            loudspeakers.DecreaseVolume();
            context.Entry(loudspeakers).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Mute(int id)
        {
            Loudspeakers loudspeakers = context.Loudspeakerses.Find(id);
            if (loudspeakers.MuteState)
            {
                loudspeakers.MuteOff();
            }
            else
            {
                loudspeakers.MuteOn();
            }
            context.Entry(loudspeakers).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Bass(int id)
        {
            Loudspeakers loudspeakers = context.Loudspeakerses.Find(id);
            if (loudspeakers.BassState)
            {
                loudspeakers.BassOff();
            }
            else
            {
                loudspeakers.BassOn();
            }
            context.Entry(loudspeakers).State = EntityState.Modified;
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