using System;
using System.Collections.Generic;
using System.Text;

using TurHelper.buisness_logic.bl_structures;
using TurHelper6;
using TurHelper8.UI.IvIew;

namespace TurHelper8.UI.Presenters
{
    class RoomInsPresenter
    {
        private Model model;
        private RoomInsI view;

        public RoomInsPresenter(RoomInsI view, Model model)
        {
            this.view = view;
            this.model = model;
        }

        public void InsertRoom(int IdHotel, string Name, int Capacity, int Floor, int Price)
        {
            try
            {
                var r = new Room();
                r.Id = 0;
                r.IdHotel = IdHotel;
                r.Name = Name;
                r.Capacity = Capacity;
                r.Floor = Floor;
                r.Price = Price;
                this.model.InsertRoom(r);
            } catch (Exception ex) { throw ex; }
        }
    }
}
