using SmartHouseMVC.Models.SmartHouse.States;

namespace SmartHouseMVC.Models.SmartHouse.Interfaces
{
    public interface IOpenable
    {
        OpenState OpenState { get; }
        void Open();
        void Close();


    }
}
