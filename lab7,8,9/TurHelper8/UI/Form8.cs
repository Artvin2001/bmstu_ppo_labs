using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TurHelper8.UI.IvIew;
using TurHelper8.UI.Presenters;
using TurHelper6;
using TurHelper.buisness_logic.bl_structures;


namespace TurHelper8
{
    public partial class Form8 : Form, UserUpI
    {
        public event Action FormLoaded;
        public event Action RefreshForm;
        private UserUpPresenter Presenter;

        private string Login;
        private int Permission;
        public Form8(string login)
        {
            InitializeComponent();
            this.Presenter = new UserUpPresenter(this, new Model());
            this.Login = login;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Presenter.UpdateUser(Login, Permission);
            }
            catch (Exception ex) { MessageBox.Show("Не удается обновить пользователя."); }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.Permission = 0;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.Permission = 1;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            this.Permission = 2;
        }
    }
}
