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
    public class ClimatUpPresenter
    {
        private Model model;
        private ClimatUpI view;
        public ClimatUpPresenter(ClimatUpI view, Model model)
        {
            this.view = view;
            this.model = model;

        }
        public void UpdateClimat(int IdCountry, string turmonth, int temp, int nighttemp, int watertemp)
        {
            try
            {
                var cl = this.model.GetClimat(IdCountry);
                cl.TurMonth = turmonth;
                cl.Temp = temp;
                cl.TempNight = nighttemp;
                cl.TempWater = watertemp;
                this.model.UpdateClimat(cl);
            }
            catch (Exception ex) { throw ex; }
            //this.view.SetClimat(cl);
        }
    }
}
