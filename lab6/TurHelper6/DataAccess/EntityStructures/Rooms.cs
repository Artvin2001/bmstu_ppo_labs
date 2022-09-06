using System;
using System.Collections.Generic;
using System.Text;

namespace TurHelper.DataAccesss.EntityStructures
{
    public partial class Rooms
    {
        public int Id { get; set; }
        public int IdHotel { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Floor { get; set; }
        public int Price { get; set; }

        public virtual Hotels IdHotelNavigation { get; set; }
    }
}
