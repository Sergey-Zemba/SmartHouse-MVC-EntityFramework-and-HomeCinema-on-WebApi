using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using SmartHouseMVC.Models.SavingModel;
using SmartHouseMVC.Models.SmartHouse.Devices;
using SmartHouseMVC.Models.SmartHouse.Interfaces;

namespace SmartHouseMVC.Models
{
    public class DeviceListModel
    {
        private List<Device> _devices;
        private IReadingWriting irw  = new SessionReadingWriting();

        public List<Device> GetDevices()
        {
            _devices = irw.Read();
            return _devices;
        }

        public void Add(string device)
        {
            _devices = irw.Read();
            int position = irw.MakePosition();
            switch (device)
            {
                case "conditioner":
                    _devices.Add(new AirConditioner(position));
                    break;
                case "camera":
                    _devices.Add(new Camera(position));
                    break;
                case "fridge":
                    _devices.Add(new Fridge(position));
                    break;
                case "garage":
                    _devices.Add(new Garage(position));
                    break;
                case "panasonicCinema":
                    _devices.Add(new PanasonicHomeCinema(position, new PanasonicTv(position), new PanasonicLoudspeakers(position)));
                    break;
                case "samsungCinema":
                    _devices.Add(new SamsungHomeCinema(position, new SamsungTv(position), new SamsungLoudspeakers(position)));
                    break;
                case "panasonicLoudspeakers":
                    _devices.Add(new PanasonicLoudspeakers(position));
                    break;
                case "samsungLoudspeakers":
                    _devices.Add(new SamsungLoudspeakers(position));
                    break;
                case "panasonicTv":
                    _devices.Add(new PanasonicTv(position));
                    break;
                case "samsungTv":
                    _devices.Add(new SamsungTv(position));
                    break;
            }
            irw.Write(_devices);
        }
        public void Delete(int position)
        {
            _devices = irw.Read();
            Device device = GetDevice(_devices, position);
            _devices.Remove(device);
            irw.Write(_devices);
        }

        public void OnOff(int position)
        {
            _devices = irw.Read();
            Device device = GetDevice(_devices, position);
            if (device.SwitchState)
            {
                device.Off();
            }
            else
            {
                device.On();
            }
            irw.Write(_devices);
        }

        public void Bass(int position)
        {
            _devices = irw.Read();
            Device device = GetDevice(_devices, position);
            if ((device as IBass).BassState)
            {
                (device as IBass).BassOff();
            }
            else
            {
                (device as IBass).BassOn();
            }
            irw.Write(_devices);
        }

        public void OpenClose(int position)
        {
            _devices = irw.Read();
            Device device = GetDevice(_devices, position);
            if ((device as IOpenable).OpenState)
            {
                (device as IOpenable).Close();
            }
            else
            {
                (device as IOpenable).Open();
            }
            irw.Write(_devices);
        }
        public void Rec(int position)
        {
            _devices = irw.Read();
            Device device = GetDevice(_devices, position);
            if ((device as IRecording).RecordMode)
            {
                (device as IRecording).StopRecording();
            }
            else
            {
                (device as IRecording).StartRecording();
            }
            irw.Write(_devices);
        }

        public void Warmer(int position)
        {
            _devices = irw.Read();
            Device device = GetDevice(_devices, position);
            (device as ITemperature).AddTemperture();
            irw.Write(_devices);
        }
        public void Cooler(int position)
        {
            _devices = irw.Read();
            Device device = GetDevice(_devices, position);
            (device as ITemperature).DecreaseTemperature();
            irw.Write(_devices);
        }

        public void ThreeD(int position)
        {
            _devices = irw.Read();
            Device device = GetDevice(_devices, position);
            if ((device as IThreeDimensional).ThreeDMode)
            {
                (device as IThreeDimensional).ThreeDOff();
            }
            else
            {
                (device as IThreeDimensional).ThreeDOn();
            }
            irw.Write(_devices);
        }
        public void Louder(int position)
        {
            _devices = irw.Read();
            Device device = GetDevice(_devices, position);
            (device as IVolumeable).AddVolume();
            irw.Write(_devices);
        }
        public void Hush(int position)
        {
            _devices = irw.Read();
            Device device = GetDevice(_devices, position);
            (device as IVolumeable).DecreaseVolume();
            irw.Write(_devices);
        }
        public void Mute(int position)
        {
            _devices = irw.Read();
            Device device = GetDevice(_devices, position);
            if ((device as IVolumeable).MuteState)
            {
                (device as IVolumeable).MuteOff();
            }
            else
            {
                (device as IVolumeable).MuteOn();
            }
            irw.Write(_devices);
        }
        private Device GetDevice(List<Device> devices, int position)
        {
            Device device = devices.Single(x => x.Position == position);
            return device;
        }

        
    }
}