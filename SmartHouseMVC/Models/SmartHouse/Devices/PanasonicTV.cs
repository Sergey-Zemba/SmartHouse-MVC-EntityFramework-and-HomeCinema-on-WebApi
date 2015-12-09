using System;
using SmartHouseMVC.Models.SmartHouse.Interfaces;
using SmartHouseMVC.Models.SmartHouse.States;

namespace SmartHouseMVC.Models.SmartHouse.Devices
{
    [Serializable]

    public class PanasonicTv : Tv, IThreeDimensional
    {
        private TvMode _mode;

        public PanasonicTv(int id)
            : base(id)
        {
        }

        public TvMode Mode { get { return _mode; } }

        public void ThreeDOn()
        {
            _mode = TvMode.ThreeDMode;
        }

        public void ThreeDOff()
        {
            _mode = TvMode.StandartMode;
        }
    }
}
