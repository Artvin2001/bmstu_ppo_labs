using System;
using System.Collections.Generic;
using System.Text;

namespace TurHelper.DataAccesss.EntityStructures
{
    public partial class Countries
    {
        public Countries()
        {
            Climates = new HashSet<Climate>();
            HotelList = new HashSet<Hotels>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Continent { get; set; }
        public string Capital { get; set; }
        public virtual ICollection<Climate> Climates { get; set; }
        public virtual ICollection<Hotels> HotelList { get; set; }
    }
}
