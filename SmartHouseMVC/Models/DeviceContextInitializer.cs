using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SmartHouseMVC.Models
{
    public class DeviceContextInitializer : DropCreateDatabaseAlways<DeviceContext>
    {
    }
}