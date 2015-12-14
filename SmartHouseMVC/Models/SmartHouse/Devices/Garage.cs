using System;
using SmartHouseMVC.Models.SmartHouse.Interfaces;

namespace SmartHouseMVC.Models.SmartHouse.Devices
{
    [Serializable]
    public class Garage : Device, IOpenable
    {
        public Garage(int position)
            : base(position)
        {
        }

        public bool OpenState { get; set; }

        public void Open()
        {

            OpenState = true;

        }

        public void Close()
        {
            OpenState = false;
        } 
    }
}
