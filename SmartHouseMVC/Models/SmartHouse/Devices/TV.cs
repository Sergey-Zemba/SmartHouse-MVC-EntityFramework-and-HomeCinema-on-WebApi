using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using SmartHouseMVC.Models.SmartHouse.Interfaces;

namespace SmartHouseMVC.Models.SmartHouse.Devices
{
    [Serializable]

    public class Tv : Device, IVolumeable, IRecording, IThreeDimensional
    {
        public Tv()
        {
            
        }
        public Tv(int position)
            : base(position)
        {
        }
        public bool RecordMode { get; set; }
        public int CurrentVolume { get; set; }
        public int PreviousVolume { get; set; }
        public bool MuteState { get; set; }
        public bool ThreeDMode { get; set; }
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

        public void StartRecording()
        {
            RecordMode = true;
        }

        public void StopRecording()
        {
            RecordMode = false;
        }
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
