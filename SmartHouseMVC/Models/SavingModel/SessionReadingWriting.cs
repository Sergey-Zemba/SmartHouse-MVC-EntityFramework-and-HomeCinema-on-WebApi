using System.Collections.Generic;
using System.Web;
using SmartHouseMVC.Models.SmartHouse.Devices;

namespace SmartHouseMVC.Models.SavingModel
{
    public class SessionReadingWriting : IReadingWriting
    {
        public List<Device> Read()
        {
            List<Device> devices;
            if (HttpContext.Current.Session["devices"] != null)
            {
                devices = (List<Device>) HttpContext.Current.Session["devices"];
            }
            else
            {
                devices = new List<Device>();
            }
            return devices;
        }

        public void Write(List<Device> devices)
        {
            HttpContext.Current.Session["devices"] = devices;
        }
        public int MakePosition()
        {
            int position;
            if (HttpContext.Current.Session["position"] != null)
            {
                position = (int)HttpContext.Current.Session["position"];
            }
            else
            {
                position = 0;
            }
            position++;
            HttpContext.Current.Session["position"] = position;
            return position;
        }
    }
}