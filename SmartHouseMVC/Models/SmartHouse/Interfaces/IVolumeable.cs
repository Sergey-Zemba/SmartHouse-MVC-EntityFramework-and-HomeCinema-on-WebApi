

namespace SmartHouseMVC.Models.SmartHouse.Interfaces
{
    public interface IVolumeable
    {
        int CurrentVolume { get; set; }
        bool MuteState { get; set; }
        void AddVolume();
        void DecreaseVolume();
        void MuteOn();
        void MuteOff();
    }
}
