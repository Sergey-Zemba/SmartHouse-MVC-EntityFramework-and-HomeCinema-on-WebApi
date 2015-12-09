using System;
using SmartHouseMVC.Models.SmartHouse.Interfaces;
using SmartHouseMVC.Models.SmartHouse.States;

namespace SmartHouseMVC.Models.SmartHouse.Devices
{
    [Serializable]
    public class Garage : Device, IOpenable
    {
        private OpenState _openState;
        public Garage(int id)
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

        public void Open()
        {

            _openState = OpenState.Open;

        }

        public void Close()
        {
            _openState = OpenState.Close;
        } 
    }
}
