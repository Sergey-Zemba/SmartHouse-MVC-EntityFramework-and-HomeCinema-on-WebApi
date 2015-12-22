using System;
using SmartHouseMVC.Models.SmartHouse.Interfaces;

namespace SmartHouseMVC.Models.SmartHouse.Devices
{

    public class Loudspeakers : Device, IVolumeable, IBass
    {
        public Loudspeakers()
        {
            
        }
        public Loudspeakers(int position)
            : base(position)
        {
        }
        public int CurrentVolume { get; set; }
        public int PreviousVolume { get; set; }
        public bool MuteState { get; set; }
        public bool BassState { get; set; }
        public void AddVolume()
        {
            if (MuteState)
            {
                MuteOff();
                CurrentVolume = PreviousVolume;
            }
            if (CurrentVolume < 100)
            {
                CurrentVolume++;
            }
            else
            {
                CurrentVolume = 100;
            }
        }

        public void DecreaseVolume()
        {
            if (MuteState)
            {
                MuteOff();
                CurrentVolume = PreviousVolume;
            }
            if (CurrentVolume > 0)
            {
                CurrentVolume--;
            }
            else
            {
                CurrentVolume = 0;
            }
        }

        public void MuteOn()
        {
            PreviousVolume = CurrentVolume;
            CurrentVolume = 0;
            MuteState = true;
        }

        public void MuteOff()
        {
            CurrentVolume = PreviousVolume;
            MuteState = false;
        }
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
