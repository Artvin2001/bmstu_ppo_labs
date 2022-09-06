using System;
using System.Collections.Generic;
using System.Text;

namespace TurHelper.buisness_logic.bl_structures
{
    public class City
    {
        public int Id { get; set; }
        public int IdCountry { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }

        public City() { }
        public City(int _Id, int _IdCountry, string _Name, int _Population)
        {
            this.Id = _Id;
            this.IdCountry = _IdCountry;
            this.Name = _Name;
            this.Population = _Population;
        }
    }
}
