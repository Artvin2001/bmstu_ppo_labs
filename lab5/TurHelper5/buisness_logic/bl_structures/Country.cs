using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace TurHelper.buisness_logic.bl_structures
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Continent { get; set; }
        public string Capital { get; set; }
        public Country() { }
        public Country(int _Id, string _Name, string _Continent, string _Capital)
        {
            this.Id = _Id;
            this.Name = _Name;
            this.Capital = _Capital;
            this.Continent = _Continent;
        }
    }
}
