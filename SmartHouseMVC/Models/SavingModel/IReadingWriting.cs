using System.Collections.Generic;
using SmartHouseMVC.Models.SmartHouse.Devices;

namespace SmartHouseMVC.Models.SavingModel
{
    interface IReadingWriting
    {
        List<Device> Read();
        void Write(List<Device> devices);
        int MakePosition();
    }
}
