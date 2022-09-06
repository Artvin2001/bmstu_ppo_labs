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
    public partial class Form5 : Form, HotelInsI
    {
        public event Action FormLoaded;
        public event Action RefreshForm;
        private HotelInsPresenter Presenter;

        private int Idcountry;
        private bool Beach;
        private bool AllInc;
        public Form5(int IdCountry)
        {
            InitializeComponent();
            this.Presenter = new HotelInsPresenter(this, new Model());
            this.Idcountry = IdCountry;
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
                this.Presenter.InsertHotel(Idcountry, textBox1.Text, Convert.ToInt32(textBox2.Text), Beach, AllInc);
            }
            catch (Exception ex) { MessageBox.Show("Не удается добавить отель. Введите все данные"); }
        }
    }
}
