

namespace SmartHouseMVC.Models.SmartHouse.Interfaces
{
    public interface IThreeDimensional
    {
        bool ThreeDMode { get; set; }
        void ThreeDOn();
        void ThreeDOff();
    }
}
