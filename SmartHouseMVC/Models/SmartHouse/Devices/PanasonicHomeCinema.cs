using System;
using SmartHouseMVC.Models.SmartHouse.Interfaces;

namespace SmartHouseMVC.Models.SmartHouse.Devices
{
    [Serializable]
    public class PanasonicHomeCinema : HomeCinema, IBass, IThreeDimensional
    {

        public PanasonicHomeCinema(int position, PanasonicTv t, PanasonicLoudspeakers l)
            : base(position, t, l)
        {
            BassState = l.BassState;
            ThreeDMode = t.ThreeDMode;
        }

        public bool BassState { get; set; }

        public bool ThreeDMode { get; set; }

        public void BassOn()
        {
            PanasonicLoudspeakers panasonicLoudspeakers = Loudspeakers as PanasonicLoudspeakers;
            if (panasonicLoudspeakers != null)
            {
                panasonicLoudspeakers.BassOn();
            }
        }

        public void BassOff()
        {
            PanasonicLoudspeakers panasonicLoudspeakers = Loudspeakers as PanasonicLoudspeakers;
            if (panasonicLoudspeakers != null)
            {
                panasonicLoudspeakers.BassOff();
            }
        }


        public void ThreeDOn()
        {
            PanasonicTv panasonicTv = Tv as PanasonicTv;
            if (panasonicTv != null)
            {
                panasonicTv.ThreeDOn();
            }
        }

        public void ThreeDOff()
        {
            PanasonicTv panasonicTv = Tv as PanasonicTv;
            if (panasonicTv != null)
            {
                panasonicTv.ThreeDOff();
            }
        }
    }
}
