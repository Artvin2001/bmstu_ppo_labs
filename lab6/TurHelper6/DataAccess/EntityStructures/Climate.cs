using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TurHelper.DataAccesss.EntityStructures
{
    public partial class Climate
    {
        public int Id { get; set; }
        //here Idcounry
        public int IdCountry { get; set; }
        [ForeignKey("idcountry")]
        public string TurMonth { get; set; }
        public int Temp { get; set; }
        public int TempNight { get; set; }
        public int TempWater { get; set; }
        public virtual Countries IdCountryNavigation { get; set; }
    }
}
