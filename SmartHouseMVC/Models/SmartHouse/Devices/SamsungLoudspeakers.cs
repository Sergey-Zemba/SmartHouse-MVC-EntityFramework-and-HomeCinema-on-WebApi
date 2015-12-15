using System;

namespace SmartHouseMVC.Models.SmartHouse.Devices
{
    [Serializable]

    public class SamsungLoudspeakers : Loudspeakers
    {
        public SamsungLoudspeakers()
        {
            
        }
        public SamsungLoudspeakers(int position) : base(position)
        {
        }
    }
}
