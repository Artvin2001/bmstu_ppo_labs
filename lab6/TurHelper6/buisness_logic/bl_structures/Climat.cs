using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace TurHelper.buisness_logic.bl_structures
{
    public class Climat
    {
        public int Id { get; set; }
        public int IdCountry { get; set; }
        public string TurMonth { get; set; }
        public int Temp { get; set; }
        public int TempNight { get; set; }
        public int TempWater { get; set; }
        public Climat() { }
        public Climat(int _Id, int _Idcountry, string _TurMonth, int _Temp, int _TempNight, int _TempWater)
        {
            this.Id = _Id;
            this.IdCountry = _Idcountry;
            this.TurMonth = _TurMonth;
            this.Temp = _Temp;
            this.TempNight = _TempNight;
            this.TempWater = _TempWater;
        }
    }
}
