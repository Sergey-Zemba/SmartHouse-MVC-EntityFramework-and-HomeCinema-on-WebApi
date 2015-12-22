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
    public class CameraController : Controller
    {
        DeviceContext context = new DeviceContext();
        public ActionResult Delete(int id)
        {
            Camera camera = context.Cameras.Find(id);
            context.Cameras.Remove(camera);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult OnOff(int id)
        {
            Camera camera = context.Cameras.Find(id);
            if (camera.SwitchState)
            {
                camera.Off();
            }
            else
            {
                camera.On();
            }
            context.Entry(camera).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Rec(int id)
        {
            Camera camera = context.Cameras.Find(id);
            if (camera.RecordMode)
            {
                camera.StopRecording();
            }
            else
            {
                camera.StartRecording();
            }
            context.Entry(camera).State = EntityState.Modified;
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