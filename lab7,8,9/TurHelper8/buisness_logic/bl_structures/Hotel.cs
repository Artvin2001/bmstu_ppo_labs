using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace TurHelper.buisness_logic.bl_structures
{
    public class Hotel
    {
        public int Id { get; set; }
        public int IdCountry { get; set; }
        public string Name { get; set; }
        public int Stars { get; set; }
        public bool Beach { get; set; }
        public bool AllInc { get; set; }
        public Hotel() { }
        public Hotel(int _Id, int _IdCountry, string _Name, int _Stars, bool _Beach, bool _AllInc)
        {
            this.Id = _Id;
            this.IdCountry = _IdCountry;
            this.Name = _Name;
            this.Stars = _Stars;
            this.Beach = _Beach;
            this.AllInc = _AllInc;
        }
    }
}
