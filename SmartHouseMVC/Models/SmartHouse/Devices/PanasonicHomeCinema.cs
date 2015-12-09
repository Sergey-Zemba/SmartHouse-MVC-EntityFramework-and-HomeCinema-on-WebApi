﻿using System;
using SmartHouseMVC.Models.SmartHouse.Interfaces;
using SmartHouseMVC.Models.SmartHouse.States;

namespace SmartHouseMVC.Models.SmartHouse.Devices
{
    [Serializable]
    public class PanasonicHomeCinema : HomeCinema, IBass, IThreeDimensional
    {

        public PanasonicHomeCinema(int id, PanasonicTv t, PanasonicLoudspeakers l)
            : base(id, t, l)
        {

        }

        public BassState BassState
        {
            get
            {
                PanasonicLoudspeakers panasonicLoudspeakers= Loudspeakers as PanasonicLoudspeakers;
                return panasonicLoudspeakers.BassState;
            }
        }

        public TvMode Mode
        {
            get
            {
                PanasonicTv panasonicTv = Tv as PanasonicTv;
                return panasonicTv.Mode;
            }
        }

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
