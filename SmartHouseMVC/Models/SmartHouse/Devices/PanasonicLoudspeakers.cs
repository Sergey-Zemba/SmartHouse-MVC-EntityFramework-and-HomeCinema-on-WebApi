using System;
using SmartHouseMVC.Models.SmartHouse.Interfaces;

namespace SmartHouseMVC.Models.SmartHouse.Devices
{
    [Serializable]

    public class PanasonicLoudspeakers : Loudspeakers, IBass
    {
        public PanasonicLoudspeakers(int position)
            : base(position)
        {
        }

        public bool BassState { get; set; }
        public void BassOn()
        {
            BassState = true;
        }

        public void BassOff()
        {
            BassState = false;
        }
    }
}
