using System;
using System.Collections.Generic;
using System.Text;

namespace TurHelper.DataAccesss.EntityStructures
{
    public partial class Users
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Permission { get; set; }
    }
}
