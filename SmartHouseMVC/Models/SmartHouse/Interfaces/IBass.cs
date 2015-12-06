using SmartHouseMVC.Models.SmartHouse.States;

namespace SmartHouseMVC.Models.SmartHouse.Interfaces
{
    public interface IBass
    {
        BassState BassState { get; }
        void BassOn();
        void BassOff();
    }
}
