using System;
using SmartHouseMVC.Models.SmartHouse.Interfaces;

namespace SmartHouseMVC.Models.SmartHouse.Devices
{
    [Serializable]
    public class Fridge : Device, IOpenable, ITemperature
    {
        public Fridge()
        {
            
        }
        public Fridge(int position)
            : base(position)
        {
        }

        public bool OpenState { get; set; }
        public int CurrentTemperature { get; set; }

        public void Open()
        {

            OpenState = true;

        }

        public void Close()
        {
            OpenState = false;
        }
        public void AddTemperture()
        {
            if (CurrentTemperature < 5)
            {
                CurrentTemperature++;
            }
            else
            {
                CurrentTemperature = 5;
            }

        }

        public void DecreaseTemperature()
        {
            if (CurrentTemperature > -5)
            {
                CurrentTemperature--;
            }
            else
            {
                CurrentTemperature = -5;
            }
        }
    }
}
