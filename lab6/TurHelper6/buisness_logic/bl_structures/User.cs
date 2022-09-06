using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace TurHelper.buisness_logic.bl_structures
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Permission { get; set; }

        public User() { }
        public User(int _Id, string _Login, string _Password, int _Permission)
        {
            this.Id = _Id;
            this.Login = _Login;
            this.Password = _Password;
            this.Permission = _Permission;
        }
    }
}
