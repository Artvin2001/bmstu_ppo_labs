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

namespace TurHelper8
{
    public partial class Form6 : Form, RoomUpI
    {
        public event Action FormLoaded;
        public event Action RefreshForm;
        private RoomUpPresenter Presenter;

        private string Name;
        private int IdHotel;
        public Form6(string name, int idhotel)
        {
            InitializeComponent();
            this.Presenter = new RoomUpPresenter(this, new Model());
            this.Name = name;
            this.IdHotel = idhotel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { this.Presenter.UpdateRoom(this.Name, this.IdHotel, Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text)); }
            catch (Exception ex) { MessageBox.Show("Не удается обновить номер. Введите все данные"); }
        }
    }
}
