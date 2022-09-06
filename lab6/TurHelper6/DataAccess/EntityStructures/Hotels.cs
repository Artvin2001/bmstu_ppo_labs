using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TurHelper.DataAccesss.EntityStructures
{
    public partial class Hotels
    {
        public Hotels()
        {
            RoomList = new HashSet<Rooms>();
        }
        public int Id { get; set; }
        public int IdCountry { get; set; }
        [ForeignKey("idcountry")]
        public string Name { get; set; }
        public int Stars { get; set; }
        public bool Beach { get; set; }
        public bool AllInc { get; set; }

        public virtual Countries IdCountryNavigation { get; set; }
        public virtual ICollection<Rooms> RoomList { get; set; }
    }
}
