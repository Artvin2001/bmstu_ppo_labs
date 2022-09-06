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
    public partial class Form3 : Form, ClimatUpI
    {
        public event Action FormLoaded;
        public event Action RefreshForm;
        private ClimatUpPresenter Presenter;

        private Country country;
        public Form3(Country c)
        {
            InitializeComponent();
            this.Presenter = new ClimatUpPresenter(this, new Model());
            this.country = c;
        }



        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { this.Presenter.UpdateClimat(country.Id, this.textBox1.Text, Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text)); }
            catch (Exception ex) { MessageBox.Show("Не получается обновить климат. Введите все данные"); }
        }
    }
}
