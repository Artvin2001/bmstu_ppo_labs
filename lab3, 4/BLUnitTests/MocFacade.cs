using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TurHelper.buisness_logic.bl_structures;
using TurHelper.DataAccesss;

namespace BLUnitTests
{
    public class MocFacade
    {
        public User GetUserInfo(string Login)
        {
            User u = new User();
            u.Id = 120;
            u.Login = Login;
            u.Password = "test23";
            u.Permission = 1;
            return u;
        }
        public void RegisterUser(User u) { }
        public bool CheckUserLogin(string Login) { return false; }
        public string GetUserPassword(string Login)
        {
            User u = new User();
            u.Id = 130;
            u.Login = Login;
            u.Password = "test2";
            u.Permission = 2;
            return u.Password;
        }
        public void UpdateUser(User u) { }
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            User u1 = new User();
            u1.Id = 140;
            u1.Login = "test1";
            u1.Password = "test12345";
            u1.Permission = 2;

            User u2 = new User();
            u2.Id = 141;
            u2.Login = "test2";
            u2.Password = "test12345";
            u2.Permission = 3;

            users.Append(u1);
            users.Append(u2);

            return users;
        }

        //countries
        public List<Country> GetAllCountries()
        {
            List<Country> countries = new List<Country>();

            Country c1 = new Country();
            c1.Id = 120;
            c1.Name = "Индия";
            c1.Capital = "Дели";
            c1.Continent = "Азия";

            Country c2 = new Country();
            c2.Id = 121;
            c2.Name = "Франция";
            c2.Capital = "Париж";
            c2.Continent = "Европа";
            countries.Append(c1);
            countries.Append(c2);
            return countries;
        }
        public Country GetCountryInfo(string Name)
        {
            Country c = new Country();
            c.Id = 120;
            c.Name = Name;
            c.Capital = "Дели";
            c.Continent = "Азия";
            return c;
        }

        //climate
        public Climat GetClimatInfo(int Idcountry)
        {
            Climat cl = new Climat();
            cl.Id = 25;
            cl.IdCountry = Idcountry;
            cl.TurMonth = "май";
            cl.Temp = 24;
            cl.TempNight = 18;
            cl.TempWater = 21;
            return cl;
        }

        public void UpdateClimat(Climat cl) { }

        //hotels
        public List<Hotel> GetAllHotels(int IdCountry)
        {
            List<Hotel> hotels = new List<Hotel>();

            Hotel h1 = new Hotel();
            h1.Id = 20;
            h1.IdCountry = IdCountry;
            h1.Name = "Best way";
            h1.Stars = 4;
            h1.Beach = true;
            h1.AllInc = true;

            Hotel h2 = new Hotel();
            h2.Id = 24;
            h2.IdCountry = IdCountry;
            h2.Name = "Sun Resort";
            h2.Stars = 5;
            h2.Beach = true;
            h2.AllInc = false;
            hotels.Append(h1);
            hotels.Append(h2);
            return hotels;
        }
        public Hotel GetHotelInfo(string Name)
        {
            Hotel h = new Hotel();
            h.Id = 24;
            h.IdCountry = 2;
            h.Name = Name;
            h.Stars = 5;
            h.Beach = true;
            h.AllInc = false;
            return h;
        }
        public void InsertHotel(Hotel h) { }
        public void DeleteHotel(int Id) { }
        public void UpdateHotel(Hotel h) { }

        //rooms
        public List<Room> GetAllRooms(int idHotel)
        {
            List<Room> rooms = new List<Room>();

            Room r1 = new Room();
            r1.Id = 3;
            r1.IdHotel = idHotel;
            r1.Name = "Standart";
            r1.Capacity = 2;
            r1.Floor = 3;
            r1.Price = 2300;

            Room r2 = new Room();
            r2.Id = 4;
            r2.IdHotel = idHotel;
            r2.Name = "Standart Luxe";
            r2.Capacity = 2;
            r2.Floor = 4;
            r2.Price = 2500;

            rooms.Append(r1);
            rooms.Append(r2);
            return rooms;
        }

        public Room GetRoomInfo(string Name, int IdHotel)
        {
            Room r = new Room();
            r.Id = 5;
            r.IdHotel = IdHotel;
            r.Name = Name;
            r.Capacity = 3;
            r.Floor = 2;
            r.Price = 3000;
            return r;
        }
        public void InsertRoom(Room r) { }
        public void DeleteRoom(int Id) { }
        public void UpdateRoom(Room r) { }
    }
}
