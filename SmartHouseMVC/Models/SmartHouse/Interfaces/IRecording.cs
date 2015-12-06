using SmartHouseMVC.Models.SmartHouse.States;

namespace SmartHouseMVC.Models.SmartHouse.Interfaces
{
    public interface IRecording
    {
        RecordMode RecordMode { get; }
        void StartRecording();
        void StopRecording();
    }
}
