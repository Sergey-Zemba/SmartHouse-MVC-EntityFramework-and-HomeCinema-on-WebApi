using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using SmartHouseMVC.Models.SmartHouse.Devices;

namespace SmartHouseMVC.Models.SavingModel
{
    public class BinaryReadingWriting : IReadingWriting
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