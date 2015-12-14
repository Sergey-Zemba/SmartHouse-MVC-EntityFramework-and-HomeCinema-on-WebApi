using System;
using System.Diagnostics.Contracts;
using SmartHouseMVC.Models.SmartHouse.Interfaces;

namespace SmartHouseMVC.Models.SmartHouse.Devices
{
    [Serializable]

    public abstract class Tv : Device, IVolumeable, IRecording
    {
        public Tv(int position)
            : base(position)
        {
        }

        public bool RecordMode { get; set; }
        public int CurrentVolume { get; set; }
        public int PreviousVolume { get; set; }
        public bool MuteState { get; set; }

        public virtual void AddVolume()
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

        public virtual void DecreaseVolume()
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
        public virtual void MuteOn()
        {
            PreviousVolume = CurrentVolume;
            CurrentVolume = 0;
            MuteState = true;
        }

        public virtual void MuteOff()
        {
            CurrentVolume = PreviousVolume;
            MuteState = false;
        }

        public virtual void StartRecording()
        {
            RecordMode = true;
        }

        public virtual void StopRecording()
        {
            RecordMode = false;
        }
    }
}
