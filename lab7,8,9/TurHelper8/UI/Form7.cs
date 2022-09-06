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
    public partial class Form7 : Form, RoomInsI
    {
        public event Action FormLoaded;
        public event Action RefreshForm;
        private RoomInsPresenter Presenter;

        private int IdHotel;
        public Form7(int idhotel)
        {
            InitializeComponent();
            this.Presenter = new RoomInsPresenter(this, new Model());
            this.IdHotel = idhotel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { this.Presenter.InsertRoom(IdHotel, textBox1.Text, Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text)); }
            catch (Exception ex) { MessageBox.Show("Не удается добавить номер. Введите все данные"); }
        }
    }
}
