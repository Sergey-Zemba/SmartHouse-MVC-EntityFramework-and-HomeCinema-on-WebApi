using System;
using SmartHouseMVC.Models.SmartHouse.Interfaces;
using SmartHouseMVC.Models.SmartHouse.States;

namespace SmartHouseMVC.Models.SmartHouse.Devices
{
    [Serializable]

    public class PanasonicLoudspeakers : Loudspeakers, IBass
    {
        private BassState _bassState;
        public PanasonicLoudspeakers(int id)
            : base(id)
        {
        }
        public BassState BassState
        {
            get
            {
                return _bassState;
            }

        }
        public void BassOn()
        {
            _bassState = BassState.On;
        }

        public void BassOff()
        {
            _bassState = BassState.Off;
        }
    }
}
