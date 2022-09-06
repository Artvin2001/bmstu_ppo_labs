using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TurHelper.DataAccesss;
using TurHelper.buisness_logic.bl_structures;

namespace TurHelper.buisness_logic
{
    public class BLFacade
    {
        private DAFacade facade;
        public BLFacade()
        {
            this.facade = new DAFacade();
        }
        public BLFacade(string Login, string Password)
        {
            this.facade = new DAFacade(Login, Password);
        }

        //user
        public User GetUserInfo(string Login)
        {
            return this.facade.GetUserByLogin(Login);
        }
        public void RegisterUser(User u)
        {
            u.Id = facade.GetNewIdUser();
            this.facade.InsertUser(u);
        }
        public bool CheckUserLogin(string Login)
        {
            return facade.CheckUserLogin(Login);
        }

        public string GetUserPassword(string Login)
        {
            return this.facade.GetUserByLogin(Login).Password;
        }
        public List<User> GetAllUsers()
        {
            return this.facade.GetAllUsers();
        }
        public void UpdateUser(User user)
        {
            this.facade.UpdateUser(user);
        }

        //country
        public List<Country> GetAllCountries()
        {
            return this.facade.GetAllCountries();
        }
        public Country GetCountryInfo(string name)
        {
            return this.facade.GetCountryByName(name);
        }
        //climate
        public Climat GetClimatInfo(int IdCountry)
        {
            return this.facade.Getclimatebycountry(IdCountry);
        }
        public void UpdateClimat(Climat cl)
        {
            this.facade.UpdateClimate(cl);
        }

        //hotels
        public List<Hotel> GetAllHotels(int IdCountry)
        {
            return this.facade.GetAllHotels(IdCountry);
        }
        public Hotel GetHotelInfo(string Name)
        {
            return this.facade.GetHotelByName(Name);
        }

        public void InsertHotel(Hotel h)
        {
            h.Id = facade.GetNewIdHotel();
            this.facade.InsertHotel(h);
        }
        public void DeleteHotel(int Id)
        {
            this.facade.DeleteHotel(Id);
        }
        public void UpdateHotel(Hotel h)
        {
            this.facade.UpdateHotel(h);
        }

        //room
        public List<Room> GetAllRooms(int IdHotel)
        {
            return this.facade.GetAllRooms(IdHotel);
        }
        public Room GetRoomInfo(string Name, int IdHotel)
        {
            return this.facade.GetRoomByName(Name, IdHotel);
        }
        public void InsertRoom(Room r)
        {
            r.Id = facade.GetNewIdRoom();
            this.facade.InsertRoom(r);
        }
        public void DeleteRoom(int Id)
        {
            this.facade.DeleteRoom(Id);
        }
        public void UpdateRoom(Room r)
        {
            this.facade.UpdateRoom(r);
        }
    }
}
