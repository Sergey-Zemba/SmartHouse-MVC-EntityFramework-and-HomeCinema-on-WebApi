using System;
using SmartHouseMVC.Models.SmartHouse.Interfaces;

namespace SmartHouseMVC.Models.SmartHouse.Devices
{
    [Serializable]
    public class AirConditioner : Device, ITemperature
    {
        public AirConditioner()
        {
            
        }
        public AirConditioner(int position) : base(position)
        {
            CurrentTemperature = 18;
        }

        public int CurrentTemperature { get; set; }
        public void AddTemperture()
        {
            if (CurrentTemperature < 25)
            {
                CurrentTemperature++;
            }
            else
            {
                CurrentTemperature = 25;
            }

        }

        public void DecreaseTemperature()
        {
            if (CurrentTemperature > 16)
            {
                CurrentTemperature--;
            }
            else
            {
                CurrentTemperature = 16;
            }
        }
    }
}
