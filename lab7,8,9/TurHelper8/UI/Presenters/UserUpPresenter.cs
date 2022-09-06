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
    public class UserUpPresenter
    {
        private Model model;
        private UserUpI view;
        public UserUpPresenter(UserUpI view, Model model)
        {
            this.view = view;
            this.model = model;

        }

        public void UpdateUser(string Login, int permission)
        {
            try
            {
                var u = this.model.GetUserInfo(Login);
                u.Permission = permission;
                this.model.UpdateUser(u);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
