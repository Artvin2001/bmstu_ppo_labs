using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TurHelper.buisness_logic;
using TurHelper.buisness_logic.bl_structures;

namespace TurHelper6
{
    public class Model
    {
        private User LoggedUser;
        private BLFacade facade;
        private List<Country> Countries;
        private List<Hotel> Hotels;
        private List<Room> Rooms;
        private List<User> Users;

        public Model()
        {
            this.facade = new BLFacade();
            this.LoggedUser = null;
            this.Hotels = new List<Hotel>();
            this.Countries = new List<Country>();
            this.Rooms = new List<Room>();
            this.Users = new List<User>();
        }

        public Model(string Login, string Password)
        {
            string ConString = "Host=localhost;Port=5432;Database=ppo;Username=" + Login + ";Password=" + Password;
            this.facade = new BLFacade(Login, Password);
            this.LoggedUser = this.facade.GetUserInfo(Login);
            this.Hotels = new List<Hotel>();
            this.Countries = new List<Country>();
            this.Rooms = new List<Room>();
            this.Users = new List<User>();
        }

        public Model(User u)
        {
            string ConString = "Host=localhost;Port=5432;Database=ppo;Username=" + u.Login + ";Password=" + u.Password;
            this.facade = new BLFacade(u.Login, u.Password);
            this.LoggedUser = this.facade.GetUserInfo(u.Login);
            this.Hotels = new List<Hotel>();
            this.Countries = new List<Country>();
            this.Rooms = new List<Room>();
            this.Users = new List<User>();
        }
        public bool CheckUser(string Login, string Password)
        {
            if (this.facade.CheckUserLogin(Login) && this.facade.GetUserInfo(Login).Password == Password)
                return true;
            else
                return false;
        }
        public User GetUserInfo()
        {
            return this.LoggedUser;
        }
        public User GetUserInfo(string Login)
        {
            try
            {
                return this.facade.GetUserInfo(Login);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CheckLogin(string Login)
        {
            return this.facade.CheckUserLogin(Login);
        }

        public void Register(User u)
        {
            try { this.facade.RegisterUser(u); }
            catch (Exception ex) { throw ex; }
        }

        public List<User> GetAllUsers()
        {
            return this.facade.GetAllUsers();
        }

        public void UpdateUser(User u)
        {
            try { this.facade.UpdateUser(u); }
            catch (Exception ex) { throw ex; }
        }

        //to do
        public bool ChangePassword(string Old, string New)
        {
            if (this.LoggedUser.Password == Old)
            {
                this.LoggedUser.Password = New;
                //this.facade.ChangePassword(this.LoggedUser.Id, New);
                return true;
            }

            return false;
        }
        public void ChangeLogin(string Login)
        {
            this.LoggedUser.Login = Login;
            //this.facade.ChangeLogin(this.LoggedUser.Id, Login);
        }

        public List<Country> GetAllCountries()
        {
            return this.facade.GetAllCountries();
        }

        public Country GetCountry(string Name)
        {
            try
            {
                return this.facade.GetCountryInfo(Name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Climat GetClimat(int IdCountry)
        {
            try { return this.facade.GetClimatInfo(IdCountry); }
            catch (Exception ex) { throw ex; }
        }

        public void UpdateClimat(Climat cl)
        {
            try
            {
                this.facade.UpdateClimat(cl);
            }
            catch (Exception ex) { throw ex; }
        }

        public List<Hotel> GetAllHotels(int IdCountry)
        {
            return this.facade.GetAllHotels(IdCountry);
        }

        public Hotel GetHotel(string Name)
        {
            try
            {
                return this.facade.GetHotelInfo(Name);
            }
            catch (Exception ex) { throw ex; }
        }

        public List<City> GetAllCities(int IdCountry)
        {
            return this.facade.GetAllCities(IdCountry);
        }

        public City GetCity(string Name)
        {
            try
            {
                return this.facade.GetCityByName(Name);
            }
            catch (Exception ex) { throw ex; }
        }

        public void Updatehotel(Hotel h)
        {
            try
            {
                this.facade.UpdateHotel(h);
            }
            catch (Exception ex) { throw ex; }
        }

        public void InsertHotel(Hotel h)
        {
            try { this.facade.InsertHotel(h); }
            catch (Exception ex) { throw ex; }
        }

        public void DeleteHotel(int Id)
        {
            try
            {
                this.facade.DeleteHotel(Id);
            }
            catch (Exception ex) { throw ex; }
        }

        public List<Room> GetAllRooms(int IdHotel)
        {
            return this.facade.GetAllRooms(IdHotel);
        }

        public Room GetRoom(string Name, int IdHotel)
        {
            try
            {
                return this.facade.GetRoomInfo(Name, IdHotel);
            }
            catch (Exception ex) { throw ex; }
        }

        public void UpdateRoom(Room r)
        {
            try
            {
                this.facade.UpdateRoom(r);
            }
            catch (Exception ex) { throw ex; }
        }

        public void InsertRoom(Room r)
        {
            try
            {
                this.facade.InsertRoom(r);
            }
            catch (Exception ex) { throw ex; }
        }

        public void DeleteRoom(int id)
        {
            try
            {
                this.facade.DeleteRoom(id);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
