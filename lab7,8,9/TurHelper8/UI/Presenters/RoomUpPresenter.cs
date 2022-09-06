using System;
using System.Collections.Generic;
using System.Text;

using TurHelper.buisness_logic.bl_structures;
using TurHelper6;
using TurHelper8.UI.IvIew;

namespace TurHelper8.UI.Presenters
{
    public class RoomUpPresenter
    {
        private Model model;
        private RoomUpI view;

        public RoomUpPresenter(RoomUpI view, Model model)
        {
            this.view = view;
            this.model = model;
        }
        public void UpdateRoom(string Name, int IdHotel, int Capacity, int Floor, int Price)
        {try
            {
                var r = model.GetRoom(Name, IdHotel);
                r.Capacity = Capacity;
                r.Floor = Floor;
                r.Price = Price;
                this.model.UpdateRoom(r);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
