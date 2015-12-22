using System.Collections.Generic;
using System.Web;
using SmartHouseMVC.Models.SmartHouse.Devices;

namespace SmartHouseMVC.Models.SavingModel
{
    public class SessionReadingWriting : IReadingWriting
    {
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