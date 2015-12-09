using System;

namespace SmartHouseMVC.Models.SmartHouse.Devices
{
    [Serializable]

    public class SamsungHomeCinema : HomeCinema
    {
        public SamsungHomeCinema(int id, SamsungTv t, SamsungLoudspeakers l)
            : base(id, t, l)
        {

        }
    }
}
