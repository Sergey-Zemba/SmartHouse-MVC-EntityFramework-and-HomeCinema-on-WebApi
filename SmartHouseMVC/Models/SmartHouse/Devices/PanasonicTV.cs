using System;
using SmartHouseMVC.Models.SmartHouse.Interfaces;

namespace SmartHouseMVC.Models.SmartHouse.Devices
{
    [Serializable]

    public class PanasonicTv : Tv, IThreeDimensional
    {
        public PanasonicTv()
        {
            
        }
        public PanasonicTv(int position)
            : base(position)
        {
        }

        public bool ThreeDMode { get; set; }

        public void ThreeDOn()
        {
            ThreeDMode = true;
        }

        public void ThreeDOff()
        {
            ThreeDMode = false;
        }
    }
}
