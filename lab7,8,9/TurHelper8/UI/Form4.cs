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
    public partial class Form4 : Form, HotelUpI
    {
        public event Action FormLoaded;
        public event Action RefreshForm;
        private HotelUpPresenter Presenter;

        private string Name;
        // ввести по умолчанию ???
        private bool Beach;
        private bool AllInc;
        public Form4(string Name)
        {
            InitializeComponent();
            this.Presenter = new HotelUpPresenter(this, new Model());
            this.Name = Name;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Beach = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Beach = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            AllInc = true;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            AllInc = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Presenter.UpdateHotel(Name, Convert.ToInt32(textBox1.Text), Beach, AllInc);
            }
            catch (Exception ex) { MessageBox.Show("Не удается обновить отель. Введите все данные"); }
        }
    }
}
