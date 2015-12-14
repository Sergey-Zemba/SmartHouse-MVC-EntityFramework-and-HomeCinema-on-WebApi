using System;
using SmartHouseMVC.Models.SmartHouse.Interfaces;

namespace SmartHouseMVC.Models.SmartHouse.Devices
{
    [Serializable]

    public abstract class HomeCinema : Device, IVolumeable, IRecording
    {

        public HomeCinema(int position, Tv tv, Loudspeakers loudspeakers)
            : base(position)
        {
            Tv = tv;
            Loudspeakers = loudspeakers;
            RecordMode = Tv.RecordMode;
            CurrentVolume = Loudspeakers.CurrentVolume;
            MuteState = Loudspeakers.MuteState;
        }
        public Tv Tv { get; set; }
        public Loudspeakers Loudspeakers { get; set; }
        public bool RecordMode { get; set; }
        public int CurrentVolume { get; set; }
        public bool MuteState { get; set; }
        public virtual void AddVolume()
        {
            Tv.AddVolume();
            Loudspeakers.AddVolume();
        }

        public void DecreaseVolume()
        {
            Tv.DecreaseVolume();
            Loudspeakers.DecreaseVolume();
        }

        public void MuteOn()
        {
            Tv.MuteOn();
            Loudspeakers.MuteOn();
        }
        public void MuteOff()
        {
            Tv.MuteOff();
            Loudspeakers.MuteOff();
        }

        public virtual void StartRecording()
        {
            Tv.StartRecording();
        }

        public virtual void StopRecording()
        {
            Tv.StopRecording();
        }

        public override void On()
        {
            base.On();
            Tv.On();
            Loudspeakers.On();
        }

        public override void Off()
        {
            base.Off();
            Tv.Off();
            Loudspeakers.Off();
        }
    }
}
