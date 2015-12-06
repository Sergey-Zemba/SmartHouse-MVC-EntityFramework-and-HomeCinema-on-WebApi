using SmartHouseMVC.Models.SmartHouse.States;

namespace SmartHouseMVC.Models.SmartHouse.Interfaces
{
    public interface IVolumeable
    {
        int CurrentVolume { get; }
        MuteState MuteState { get; }
        void AddVolume();
        void DecreaseVolume();
        void MuteOn();
        void MuteOff();
    }
}
