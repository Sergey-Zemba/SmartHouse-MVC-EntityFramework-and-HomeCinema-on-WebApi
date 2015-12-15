using System;
using SmartHouseMVC.Models.SmartHouse.Interfaces;

namespace SmartHouseMVC.Models.SmartHouse.Devices
{
    [Serializable]
    public class Camera : Device, IRecording
    {
        public Camera()
        {
            
        }
        public Camera(int position)
            : base(position)
        {
        }

        public bool RecordMode { get; set; }

        public void StartRecording()
        {
            RecordMode = true;
        }

        public void StopRecording()
        {
            RecordMode = false;
        }
    }
}
