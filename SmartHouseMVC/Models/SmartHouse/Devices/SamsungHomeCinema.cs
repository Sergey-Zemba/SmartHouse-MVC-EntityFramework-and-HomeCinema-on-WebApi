using System;

namespace SmartHouseMVC.Models.SmartHouse.Devices
{
    [Serializable]

    class SamsungHomeCinema : HomeCinema
    {
        public SamsungHomeCinema(int id, SamsungTv t, SamsungLoudspeakers l)
            : base(id, t, l)
        {

        }
    }
}
