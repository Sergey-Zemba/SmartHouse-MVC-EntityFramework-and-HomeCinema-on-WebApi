using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using SmartHouseMVC.Models;
using SmartHouseMVC.Models.SmartHouse.Devices;

namespace SmartHouseMVC.Controllers
{
    public class HomeCinemaWebApiController : ApiController
    {
        DeviceContext context = new DeviceContext();
        public HomeCinema GetHomeCinema(int id)
        {
            HomeCinema homeCinema = context.HomeCinemas.Find(id);
            return homeCinema;
        }
        public void Delete(int id)
        {
            HomeCinema homeCinema = context.HomeCinemas.Find(id);
            context.HomeCinemas.Remove(homeCinema);
            context.SaveChanges();
        }
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/HomeCinemaWebApi/OnOff/{id}")]
        public void OnOff(int id)
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
        }
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/HomeCinemaWebApi/AddVolume/{id}")]
        public void AddVolume(int id)
        {
            HomeCinema homeCinema = context.HomeCinemas.Find(id);
            homeCinema.AddVolume();
            context.Entry(homeCinema).State = EntityState.Modified;
            context.SaveChanges();
        }
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/HomeCinemaWebApi/DecreaseVolume/{id}")]
        public void DecreaseVolume(int id)
        {
            HomeCinema homeCinema = context.HomeCinemas.Find(id);
            homeCinema.DecreaseVolume();
            context.Entry(homeCinema).State = EntityState.Modified;
            context.SaveChanges();
        }
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/HomeCinemaWebApi/Mute/{id}")]
        public void Mute(int id)
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
        }
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/HomeCinemaWebApi/Rec/{id}")]
        public void Rec(int id)
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
        }
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/HomeCinemaWebApi/Bass/{id}")]
        public void Bass(int id)
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
        }
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/HomeCinemaWebApi/ThreeDOnOff/{id}")]
        public void ThreeDOnOff(int id)
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
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}
