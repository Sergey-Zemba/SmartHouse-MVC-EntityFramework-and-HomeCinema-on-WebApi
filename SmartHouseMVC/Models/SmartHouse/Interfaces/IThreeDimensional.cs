using SmartHouseMVC.Models.SmartHouse.States;

namespace SmartHouseMVC.Models.SmartHouse.Interfaces
{
    public interface IThreeDimensional
    {
        TvMode Mode { get; }
        void ThreeDOn();
        void ThreeDOff();
    }
}
