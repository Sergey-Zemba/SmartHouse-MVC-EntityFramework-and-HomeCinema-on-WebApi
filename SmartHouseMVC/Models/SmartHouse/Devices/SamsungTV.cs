using System;

namespace SmartHouseMVC.Models.SmartHouse.Devices
{
    [Serializable]

    public class SamsungTv : Tv
    {
        public SamsungTv()
        {
            
        }
        public SamsungTv(int position) : base(position)
        {
        }
    }
}
