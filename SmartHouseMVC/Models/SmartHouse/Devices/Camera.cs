using System;
using SmartHouseMVC.Models.SmartHouse.Interfaces;
using SmartHouseMVC.Models.SmartHouse.States;

namespace SmartHouseMVC.Models.SmartHouse.Devices
{
    [Serializable]
    public class Camera : Device, IRecording
    {
        private RecordMode _recordMode;
        public Camera(int id)
            : base(id)
        {
        }

        public RecordMode RecordMode
        {
            get
            {
                return _recordMode;
            }
        }

        public void StartRecording()
        {
            _recordMode = RecordMode.Record;
        }

        public void StopRecording()
        {
            _recordMode = RecordMode.Live;
        }
    }
}
