using SmartHouseMVC.Models.SmartHouse.States;

namespace SmartHouseMVC.Models.SmartHouse.Interfaces
{
    public interface ISwitchable
    {
        SwitchState SwitchState { get; }
        void On();
        void Off();
    }
}
