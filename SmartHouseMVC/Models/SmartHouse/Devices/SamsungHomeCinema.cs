using System;

namespace SmartHouseMVC.Models.SmartHouse.Devices
{
    [Serializable]

    public class SamsungHomeCinema : HomeCinema
    {
        public SamsungHomeCinema(int position, SamsungTv t, SamsungLoudspeakers l)
            : base(position, t, l)
        {

        }
    }
}
