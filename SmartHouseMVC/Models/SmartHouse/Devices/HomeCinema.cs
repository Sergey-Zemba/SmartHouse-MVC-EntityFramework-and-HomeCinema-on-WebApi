using System;
using System.ComponentModel.DataAnnotations.Schema;
using SmartHouseMVC.Models.SmartHouse.Interfaces;

namespace SmartHouseMVC.Models.SmartHouse.Devices
{
    [Serializable]

    public class HomeCinema : Device, IVolumeable, IRecording, IBass, IThreeDimensional
    {
        public HomeCinema()
        {
            Tv = new Tv();
            Loudspeakers = new Loudspeakers();
        }
        public HomeCinema(int position, Tv t, Loudspeakers l)
            : base(position)
        {
            Tv = t;
            Loudspeakers = l;

        }
        [NotMapped]
        public Tv Tv { get; set; }
        [NotMapped]
        public Loudspeakers Loudspeakers { get; set; }
        public bool RecordMode
        {
            get { return Tv.RecordMode; }
            set
            {
                Tv.RecordMode = value;
            }
            
        }
        public int CurrentVolume
        {
            get { return Tv.CurrentVolume; }
            set
            {
                Tv.CurrentVolume = value;
                Loudspeakers.CurrentVolume = value;
            }
        }
        public bool MuteState
        {
            get { return Tv.MuteState; }
            set
            {
                Tv.MuteState = value;
                Loudspeakers.MuteState = value;
            }
            
        }
        public bool BassState
        {
            get { return Loudspeakers.BassState; }
            set
            {
                Loudspeakers.BassState = value;
            }
        }
        public bool ThreeDMode
        {
            get { return Tv.ThreeDMode; }
            set
            {
                Tv.ThreeDMode = value;
            }
        }
        public void AddVolume()
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

        public void StartRecording()
        {
            Tv.StartRecording();
        }

        public void StopRecording()
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
        public void BassOn()
        {
            Loudspeakers.BassOn();
        }

        public void BassOff()
        {
            Loudspeakers.BassOff();
        }


        public void ThreeDOn()
        {
            Tv.ThreeDOn();
        }

        public void ThreeDOff()
        {
            Tv.ThreeDOff();
        }
    }
}
