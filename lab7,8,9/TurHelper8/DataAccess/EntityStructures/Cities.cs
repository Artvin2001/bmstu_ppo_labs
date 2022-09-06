using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TurHelper.DataAccesss.EntityStructures
{
    public partial class Cities
    {
        public int Id { get; set; }
        //here Idcounry
        public int IdCountry { get; set; }
        [ForeignKey("idcountry")]
        public string Name { get; set; }
        public int Population { get; set; }

        public virtual Countries IdCityNavigation { get; set; }
    }
}
