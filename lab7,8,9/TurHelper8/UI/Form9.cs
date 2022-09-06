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
    public partial class Form9 : Form, RegistrationI
    {
        public event Action FormLoaded;
        public event Action RefreshForm;
        Log log = new Log();
        private RegistrationPresenter Presenter;

        private string login;
        private string password;
        private int permission;
        public Form9()
        {
            InitializeComponent();
            this.Presenter = new RegistrationPresenter(this, new Model());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login = textBox1.Text;
            password = textBox2.Text;
            log.Loging("Info: prepare register user in form 9 ");
            this.Presenter.RegisterUser(login, password, permission);
            log.Loging("Info: register user in form 9 ");
            Form2 Home = new Form2(permission);
            Home.Show();
            this.Hide();
            //this.Close();
        }

        public void SetError(string s)
        {
            MessageBox.Show(s);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            permission = 0;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            permission = 1;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            permission = 2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            login = textBox3.Text;
            password = textBox4.Text;
            var code = this.Presenter.LoadUser(login, password, permission);
            if (code >= 0)
            {
                Form2 Home = new Form2(code);
                Home.Show();
                this.Hide();
            }
        }
    }
}
