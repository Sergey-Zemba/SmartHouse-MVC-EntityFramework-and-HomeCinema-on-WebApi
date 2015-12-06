using System;
using SmartHouseMVC.Models.SmartHouse.Interfaces;
using SmartHouseMVC.Models.SmartHouse.States;

namespace SmartHouseMVC.Models.SmartHouse.Devices
{
    [Serializable]

    abstract class HomeCinema : Device, IVolumeable, IRecording
    {

        public HomeCinema(int id, Tv tv, Loudspeakers loudspeakers)
            : base(id)
        {
            Tv = tv;
            Loudspeakers = loudspeakers;
        }
        public Tv Tv { get; set; }
        public Loudspeakers Loudspeakers { get; set; }
        public RecordMode RecordMode { get { return Tv.RecordMode; } }
        public int CurrentVolume { get { return Loudspeakers.CurrentVolume; } }
        public MuteState MuteState { get { return Loudspeakers.MuteState; } }
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
