using System;
using SmartHouseMVC.Models.SmartHouse.Interfaces;
using SmartHouseMVC.Models.SmartHouse.States;

namespace SmartHouseMVC.Models.SmartHouse.Devices
{
    [Serializable]
    public class Fridge : Device, IOpenable, ITemperature
    {
        private OpenState _openState;
        private int _temperature;
        public Fridge(int id)
            : base(id)
        {
        }

        public OpenState OpenState
        {
            get
            {
                return _openState;
            }

        }
        public int CurrentTemperature { get { return _temperature; } }

        public void Open()
        {

            _openState = OpenState.Open;

        }

        public void Close()
        {
            _openState = OpenState.Close;
        }
        public void AddTemperture()
        {
            if (_temperature < 5)
            {
                _temperature++;
            }
            else
            {
                _temperature = 5;
            }

        }

        public void DecreaseTemperature()
        {
            if (_temperature > -5)
            {
                _temperature--;
            }
            else
            {
                _temperature = -5;
            }
        }
    }
}
