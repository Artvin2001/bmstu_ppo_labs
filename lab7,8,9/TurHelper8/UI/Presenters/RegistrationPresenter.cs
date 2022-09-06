using System;
using System.Collections.Generic;
using System.Text;

using TurHelper.buisness_logic.bl_structures;
using TurHelper6;
using TurHelper8.UI.IvIew;

namespace TurHelper8.UI.Presenters
{
    public class RegistrationPresenter
    {
        private Model model;
        private RegistrationI view;
        Log log = new Log();

        public RegistrationPresenter(RegistrationI view, Model model)
        {
            this.view = view;
            this.model = model;
        }

        public void RegisterUser(string Login, string Password, int Permission)
        {
            if (this.model.CheckLogin(Login))
            {
                this.view.SetError("Этот логин уже занят. Попробуйте другой");
                return;
            }
            log.Loging("Info: getting info for registration");
           try
            {
                User u = new User();
                u.Id = 0;
                u.Login = Login;
                u.Password = Password;
                u.Permission = Permission;
                this.model.Register(u);
            }
            catch (Exception ex) { throw ex; }
        }

        public int LoadUser(string login, string password, int permission)
        {
            try
            {
                log.Loging("Info: get user in with login - " + login);
                var u = this.model.GetUserInfo(login);
                if (u.Login != login)
                {
                    this.view.SetError("Неверный пароль");
                    return -1;
                }
                else
                {
                    permission = u.Permission;
                    return u.Permission;
                }    
            }
            catch(Exception ex)
            {
                this.view.SetError("Неверный логин");
                throw ex;
                return -1;
            }
        }
    }
}
