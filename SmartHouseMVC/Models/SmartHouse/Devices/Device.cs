using System;
using SmartHouseMVC.Models.SmartHouse.Interfaces;

namespace SmartHouseMVC.Models.SmartHouse.Devices
{
    [Serializable]

    public abstract class Device : ISwitchable
    {

        public Device(int position)
        {
            Position = position;
        }

        public int Id { get; set; }
        public bool SwitchState { get; set; }
        public int Position { get; set; }

        public virtual void On()
        {
            SwitchState = true;
        }

        public virtual void Off()
        {
            SwitchState = false;
        }

        public override string ToString()
        {
            string str = GetType().Name + " is " + SwitchState;
            if (SwitchState)
            {
                if (this is IBass)
                {
                    if ((this as IBass).BassState)
                    {
                        str += " Bass";
                    }
                }
                if (this is IOpenable)
                {
                    if ((this as IOpenable).OpenState)
                    {
                        str += " Open";
                    }
                }
                if (this is IRecording)
                {
                    if ((this as IRecording).RecordMode)
                    {
                        str += " REC";
                    }
                }
                if (this is ITemperature)
                {
                    str += " Current temperature " + (this as ITemperature).CurrentTemperature + "°C";
                }
                if (this is IThreeDimensional)
                {
                    if ((this as IThreeDimensional).ThreeDMode)
                    {
                        str += " 3D";
                    }
                }
                if (this is IVolumeable)
                {
                    if ((this as IVolumeable).MuteState)
                    {
                        str += " Mute";
                    }
                    else
                    {
                        str += " Volume " + (this as IVolumeable).CurrentVolume;
                    }
                }
            }
            return str;
        }
    }
}
