using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SmartHouseMVC.Models.SmartHouse.Devices;

namespace SmartHouseMVC.Models
{
    public class DeviceContext : DbContext
    {
        static DeviceContext()
        {
            Database.SetInitializer(new DeviceContextInitializer());
        }
        public DeviceContext() : base("DefaultConnection")
        {
            
        }

        public DbSet<AirConditioner> AirConditioners { get; set; }
        public DbSet<Camera> Cameras { get; set; }
        public DbSet<Fridge> Fridges { get; set; }
        public DbSet<Garage> Garages { get; set; }
        //public DbSet<PanasonicHomeCinema> PanasonicHomeCinemas { get; set; }
        //public DbSet<SamsungHomeCinema> SamsungHomeCinemas { get; set; }
        //public DbSet<PanasonicLoudspeakers> PanasonicLoudspeakerses { get; set; }
        //public DbSet<SamsungLoudspeakers> SamsungLoudspeakerses { get; set; }
        //public DbSet<PanasonicTv> PanasonicTvs { get; set; }
        //public DbSet<SamsungTv> SamsungTvs { get; set; }
    }
}