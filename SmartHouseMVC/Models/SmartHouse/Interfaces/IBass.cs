
namespace SmartHouseMVC.Models.SmartHouse.Interfaces
{
    public interface IBass
    {
        bool BassState { get; set; }
        void BassOn();
        void BassOff();
    }
}
