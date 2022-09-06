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
    public class HotelInsPresenter
    {
        private Model model;
        private HotelInsI view;

        public HotelInsPresenter(HotelInsI view, Model model)
        {
            this.view = view;
            this.model = model;
        }

        public void InsertHotel(int IdCountry, string Name, int Stars, bool Beach, bool AllInc)
        {
            try
            {
                var h = new Hotel();
                h.Id = 0;
                h.IdCountry = IdCountry;
                h.Name = Name;
                h.Stars = Stars;
                h.Beach = Beach;
                h.AllInc = AllInc;
                this.model.InsertHotel(h);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
