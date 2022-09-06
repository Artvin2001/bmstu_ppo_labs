using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TurHelper.buisness_logic.bl_structures;
using TurHelper6;
using TurHelper8.UI.IvIew;

namespace TurHelper8.UI.Presenters
{
    public class HotelUpPresenter
    {
        private Model model;
        private HotelUpI view;

        public HotelUpPresenter(HotelUpI view, Model model)
        {
            this.view = view;
            this.model = model;
        }

        public void UpdateHotel(string Name, int stars, bool beach, bool allinc)
        {
            try
            {
                var h = model.GetHotel(Name);
                h.Stars = stars;
                h.Beach = beach;
                h.AllInc = allinc;
                this.model.Updatehotel(h);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
