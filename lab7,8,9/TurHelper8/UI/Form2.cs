using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System;
using System.Windows.Forms;

using TurHelper8.UI.IvIew;
using TurHelper8.UI.Presenters;
using TurHelper6;
using TurHelper.buisness_logic.bl_structures;

namespace TurHelper8
{
    public partial class Form2 : Form, HomeViewI
    {
        public event Action FormLoaded;
        public event Action RefreshForm;
        Log log = new Log();
        private int permission;

        private HomePresenter Presenter;
        private List<Country> Countires;
        private List<Hotel> Hotels;
        private List<Room> Rooms;
        private List<User> Users;
        private List<City> Cities;

        private Country country;
        private Hotel hotel;
        private Room room;
        private string user_login;
        private City city;
        public Form2(int perm)
        {
            InitializeComponent();
            log.Loging("start work, permission - " + perm);
            this.Presenter = new HomePresenter(this, new Model());
            this.permission = perm;

            if (permission == 2)
            {
                button7.Visible = false;
                button8.Visible = false;
                button9.Visible = false;
                button10.Visible = false;
                button11.Visible = false;
                button12.Visible = false;
                button13.Visible = false;
                button14.Visible = false;
                dataGridView4.Visible = false;
            }
            if (permission == 1)
            {
                button12.Visible = false;
                button13.Visible = false;
                button14.Visible = false;
                dataGridView4.Visible = false;
            }

        }
        public void RefreshInfo()
        {
            this.dataGridView2.Rows.Clear();
            this.dataGridView2.Refresh();
            this.dataGridView2.Columns.Clear();

            this.dataGridView1.Rows.Clear();
            this.dataGridView1.Refresh();
            this.dataGridView1.Columns.Clear();

            this.dataGridView3.Rows.Clear();
            this.dataGridView3.Refresh();
            this.dataGridView3.Columns.Clear();

            //this.RefreshForm();
        }

        public void RefreshInfoTwo()
        {
            this.dataGridView2.Rows.Clear();
            this.dataGridView2.Refresh();
            this.dataGridView2.Columns.Clear();

            this.dataGridView3.Rows.Clear();
            this.dataGridView3.Refresh();
            this.dataGridView3.Columns.Clear();

            //this.RefreshForm();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var s = this.dataGridView1.Rows[e.RowIndex].Cells[0];
            log.Loging("Info: select coutnry " + s.ToString());
            this.country = this.Countires.Find(a => a.Name == s.Value.ToString());
            log.Loging("Info: select coutnry " + country.Id + " " + country.Name);
            this.Presenter.LoadHotels(country.Id);
        }
        public void SetHotelList(List<Hotel> hotels)
        {
            this.dataGridView2.Rows.Clear();
            this.dataGridView2.Refresh();
            this.dataGridView2.Columns.Clear();

            DataGridViewTextBoxColumn column02 = new DataGridViewTextBoxColumn();
            column02.Name = "Hotel";
            column02.HeaderText = "Название отеля";
            column02.Width = 201;
            column02.CellTemplate = new DataGridViewTextBoxCell();

            dataGridView2.Columns.AddRange(column02);
            foreach (Hotel h in hotels)
            {
                AddHotelToTable(h);
            }

            log.Loging("set hotel list");
            this.Hotels = hotels;
        }

        public void SetCitiesList(List<City> cities)
        {
            this.dataGridView5.Rows.Clear();
            this.dataGridView5.Refresh();
            this.dataGridView5.Columns.Clear();

            DataGridViewTextBoxColumn column02 = new DataGridViewTextBoxColumn();
            column02.Name = "City";
            column02.HeaderText = "Имя города";
            column02.Width = 201;
            column02.CellTemplate = new DataGridViewTextBoxCell();

            dataGridView5.Columns.AddRange(column02);
            foreach (City c in cities)
            {
                this.dataGridView5.Rows.Add(c.Name);
            }
            log.Loging("set cities list");

            this.Cities = cities;
        }

        public void AddHotelToTable(Hotel h)
        {
            this.dataGridView2.Rows.Add(h.Name);
        }
        public void AddRoomToTable(Room r)
        {
            this.dataGridView3.Rows.Add(r.Name);
        }
        public void SetCountriesList(List<Country> countries)
        {
            DataGridViewTextBoxColumn column01 = new DataGridViewTextBoxColumn();
            column01.Name = "Country";
            column01.HeaderText = "Название страны";
            column01.Width = 201;
            column01.CellTemplate = new DataGridViewTextBoxCell();

            dataGridView1.Columns.AddRange(column01);
            foreach (Country c in countries)
            {
                AddCountryToTable(c);
            }
            log.Loging("set countries list");
            this.Countires = countries;
        }

        public void SetUserList(List<User> users)
        {
            DataGridViewTextBoxColumn column01 = new DataGridViewTextBoxColumn();
            column01.Name = "Users";
            column01.HeaderText = "Логин";
            column01.Width = 201;
            column01.CellTemplate = new DataGridViewTextBoxCell();

            dataGridView4.Columns.AddRange(column01);
            foreach (User u in users)
            {
                this.dataGridView4.Rows.Add(u.Login);
            }
            log.Loging("set user list");
            this.Users = users;
        }

        public void SetRoomsList(List<Room> rooms)
        {
            this.dataGridView3.Rows.Clear();
            this.dataGridView3.Refresh();
            this.dataGridView3.Columns.Clear();

            DataGridViewTextBoxColumn column01 = new DataGridViewTextBoxColumn();
            column01.Name = "Rooms";
            column01.HeaderText = "Название номера";
            column01.Width = 201;
            column01.CellTemplate = new DataGridViewTextBoxCell();

            dataGridView3.Columns.AddRange(column01);
            foreach (Room r in rooms)
            {
                AddRoomToTable(r);
            }
            log.Loging("set room list");
            this.Rooms = rooms;
        }
        public void AddCountryToTable(Country c)
        {
            this.dataGridView1.Rows.Add(c.Name);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.RefreshInfo();
            try { this.Presenter.LoadCountries(); log.Loging("countries loaded"); }
            catch (Exception ex) { MessageBox.Show("Список стран не может быть загружен"); log.Error(ex.ToString()); }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var s = this.dataGridView2.Rows[e.RowIndex].Cells[0];
            this.hotel = this.Hotels.Find(a => a.Name == s.Value.ToString());
            this.Presenter.LoadRooms(hotel.Id);
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var s = this.dataGridView3.Rows[e.RowIndex].Cells[0];
            this.room = this.Rooms.Find(a => a.Name == s.Value.ToString());
            //this.Presenter.LoadRoom(room.Name, hotel.Id);
        }

      

        private void button2_Click(object sender, EventArgs e)
        {
            this.RefreshInfoTwo();
            try
            { this.Presenter.LoadHotels(country.Id); log.Loging("loaded hotel"); }
            catch (Exception ex) { MessageBox.Show("Отели не могут быть загружены. Выберите страну"); log.Error(ex.ToString()); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.Presenter.LoadClimat(country.Id);
                log.Loging("loaded climate");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Климат не может быть загружен");
                log.Error(ex.ToString());
            }
        }

        public void SetClimat(Climat climat)
        {
            MessageBox.Show("Наиболее популярным для туризма является месяц " + climat.TurMonth + ".\n" + "Средняя температура днем - " + climat.Temp + ".\n" + "Средняя температура ночью - " + climat.TempNight + ".\n" + "Средняя температура воды - " + climat.TempWater + ".");
        }

        public void SetHotel(Hotel hotel)
        {
            string s = "Название - " + hotel.Name + " " + hotel.Stars + "*.\n";
            if (hotel.Beach)
                s += "Есть пляж\n";
            else
                s += "Нет пляжа\n";
            if (hotel.AllInc)
                s += "Доступен All Inclusive\n";
            else
                s += "Не доступен All Inclusive";
            MessageBox.Show(s);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                this.Presenter.LoadHotel(hotel.Name);
                log.Loging("loaded hotel");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Отель не может быть загружен");
                log.Error(ex.ToString());
            }
        }

        public void SetCountry(Country c)
        {
            MessageBox.Show("Название страны - " + c.Name + ".\n" + "Столица - " + c.Capital + ".\n" + "Континент - " + c.Continent + ".");
        }

        public void SetCity(City c)
        {
            MessageBox.Show("Имя города - " + c.Name + ".\n" + "Население - " + c.Population);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            try { this.Presenter.LoadCountry(country.Name); log.Loging("country loaded"); }
            catch (Exception ex) { MessageBox.Show("Информация о стране не может быть загружена"); log.Error(ex.ToString()); }
        }

        public void SetRoom(Room r)
        {
            MessageBox.Show("Название - " + r.Name + ".\n" + "Вместимость - " + r.Capacity + ".\n" + "Этаж - " + r.Floor + ".\n" + 
                "Цена - " + r.Price + ".");
        }

        public void SetUser(User u)
        {
            string s;
            if (u.Permission == 0)
                s = "Администратор";
            else if (u.Permission == 1)
                s = "Модератор";
            else
                s = "Пользователь";
            MessageBox.Show("Логин - " + u.Login + "; Права доступа - " + s);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try { this.Presenter.LoadRoom(room.Name, hotel.Id); log.Loging("room loaded"); }
            catch (Exception ex) { MessageBox.Show("Информация о номере не может быть загружена"); log.Error(ex.ToString()); }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form3 update_cl_f = new Form3(country);
            update_cl_f.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form4 update_h_f = new Form4(hotel.Name);
            update_h_f.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            log.Loging("Info: insert hotel  country id - " + country.Id + "name - " + country.Name);
            Form5 insert_h_f = new Form5(country.Id);
            insert_h_f.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form6 update_r_f = new Form6(this.room.Name, this.hotel.Id);
            update_r_f.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form7 insert_r_f = new Form7(hotel.Id);
            insert_r_f.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.dataGridView4.Rows.Clear();
            this.dataGridView4.Refresh();
            this.dataGridView4.Columns.Clear();
            this.Presenter.LoadUsers();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form8 update_u_f = new Form8(user_login);
            update_u_f.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try { this.Presenter.LoadUser(user_login); log.Loging("user loaded"); }
            catch (Exception ex) { MessageBox.Show("Информация о пользователе не может быть загружена"); log.Error(ex.ToString()); }
        }

        private void dataGridView4_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            var s = this.dataGridView4.Rows[e.RowIndex].Cells[0];
            this.user_login = s.Value.ToString();
            log.Loging("Info: select user " + user_login);
            //this.Presenter.LoadRoom(room.Name, hotel.Id);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try { this.Presenter.LoadCities(country.Id); log.Loging("cities loaded"); }
            catch (Exception ex) { MessageBox.Show("Список городов не может быть загружен. Выберите страну"); log.Error(ex.ToString()); }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try { this.Presenter.LoadCity(city.Name); log.Loging("city loaded"); }
            catch (Exception ex) { MessageBox.Show("Информация о городе не может быть загружена"); log.Error(ex.ToString()); }
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var s = this.dataGridView5.Rows[e.RowIndex].Cells[0];
            this.city = this.Cities.Find(a => a.Name == s.Value.ToString());
        }
    }

}
