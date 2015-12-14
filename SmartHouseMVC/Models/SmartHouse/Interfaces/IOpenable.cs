

namespace SmartHouseMVC.Models.SmartHouse.Interfaces
{
    public interface IOpenable
    {
        bool OpenState { get; set; }
        void Open();
        void Close();


    }
}
