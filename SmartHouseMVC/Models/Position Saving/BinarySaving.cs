using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;

namespace SmartHouseMVC.Models.Position_Saving
{
    public class BinarySaving : ISaving
    {
        private BinaryFormatter formatter = new BinaryFormatter();
        public int MakePosition()
        {
            int position;
            using (FileStream fs = new FileStream(HttpContext.Current.Server.MapPath("~/Position.dat"), FileMode.OpenOrCreate))
            {
                if (fs.Length != 0)
                {
                    position = (int)formatter.Deserialize(fs);
                }
                else
                {
                    position = 0;
                }
            }
            using (
                FileStream fs =
                    new FileStream(HttpContext.Current.Server.MapPath("~/Position.dat"),
                        FileMode.Open))
            {

                position++;
                formatter.Serialize(fs, position);
            }
            return position;
        }
    }
}