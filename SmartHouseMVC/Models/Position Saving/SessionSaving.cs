using System.Web;

namespace SmartHouseMVC.Models.Position_Saving
{
    public class SessionSaving : ISaving
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