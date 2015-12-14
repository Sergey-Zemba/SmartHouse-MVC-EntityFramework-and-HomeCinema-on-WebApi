namespace SmartHouseMVC.Models.SmartHouse.Interfaces
{
    public interface ITemperature
    {
        int CurrentTemperature { get; set; }
        void AddTemperture();
        void DecreaseTemperature();
    }
}
