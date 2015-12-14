

namespace SmartHouseMVC.Models.SmartHouse.Interfaces
{
    public interface IRecording
    {
        bool RecordMode { get; set; }
        void StartRecording();
        void StopRecording();
    }
}
