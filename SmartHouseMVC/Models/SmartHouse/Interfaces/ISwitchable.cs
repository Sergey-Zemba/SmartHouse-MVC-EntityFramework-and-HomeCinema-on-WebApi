

namespace SmartHouseMVC.Models.SmartHouse.Interfaces
{
    public interface ISwitchable
    {
        bool SwitchState { get; set; }
        void On();
        void Off();
    }
}
