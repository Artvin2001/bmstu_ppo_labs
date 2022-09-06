using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace TurHelper.buisness_logic.bl_structures
{
    public class Room
    {
        public int Id { get; set; }
        public int IdHotel { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Floor { get; set; }
        public int Price { get; set; }

        public Room() { }
        public Room(int _Id, int _IdHotel, string _Name, int _Capacity, int _Floor, int _Price)
        {
            this.Id = _Id;
            this.IdHotel = _IdHotel;
            this.Name = _Name;
            this.Capacity = _Capacity;
            this.Floor = _Floor;
            this.Price = _Price;
        }
    }
}
