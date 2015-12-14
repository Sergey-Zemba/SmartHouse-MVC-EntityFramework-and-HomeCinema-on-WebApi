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


        public List<Device> Read()
        {
            List<Device> devices;
            using (FileStream fs = new FileStream(HttpContext.Current.Server.MapPath("~/Devices.dat"), FileMode.OpenOrCreate))
            {
                if (fs.Length != 0)
                {
                    devices = (List<Device>)formatter.Deserialize(fs);
                }
                else
                {
                    devices = new List<Device>();
                }
            }
            return devices;
        }

        public void Write(List<Device> devices)
        {
            using (FileStream fs = new FileStream(HttpContext.Current.Server.MapPath("~/Devices.dat"), FileMode.Open))
            {
                formatter.Serialize(fs, devices);
            }
        }
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