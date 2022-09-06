using System;
using Xunit;
using System.Collections.Generic;
using System.Linq;

using TurHelper.DataAccesss;
using TurHelper.buisness_logic.bl_structures;

namespace BLUnitTests
{
    public class BLUnitTests
    {
        private MocFacade facade = new MocFacade();
        static void CheckEqualUser(User u1, User u2)
        {
            Assert.Equal(u1.Id, u2.Id);
            Assert.Equal(u1.Login, u2.Login);
            Assert.Equal(u1.Password, u2.Password);
            Assert.Equal(u1.Permission, u2.Permission);
        }

        static void CheckEqualCountry(Country c1, Country c2)
        {
            Assert.Equal(c1.Id, c2.Id);
            Assert.Equal(c1.Name, c2.Name);
            Assert.Equal(c1.Capital, c2.Capital);
            Assert.Equal(c1.Continent, c2.Continent);
        }

        static void CheckEqualClimat(Climat c1, Climat c2)
        {
            Assert.Equal(c1.Id, c2.Id);
            Assert.Equal(c1.IdCountry, c2.IdCountry);
            Assert.Equal(c1.TurMonth, c2.TurMonth);
            Assert.Equal(c1.Temp, c2.Temp);
            Assert.Equal(c1.TempNight, c2.TempNight);
            Assert.Equal(c1.TempWater, c2.TempWater);
        }

        static void CheckEqualHotel(Hotel h1, Hotel h2)
        {
            Assert.Equal(h1.Id, h2.Id);
            Assert.Equal(h1.IdCountry, h2.IdCountry);
            Assert.Equal(h1.Name, h2.Name);
            Assert.Equal(h1.Stars, h2.Stars);
            Assert.Equal(h1.Beach, h2.Beach);
            Assert.Equal(h1.AllInc, h2.AllInc);
        }

        static void CheckEqualRoom(Room r1, Room r2)
        {
            Assert.Equal(r1.Id, r2.Id);
            Assert.Equal(r1.IdHotel, r2.IdHotel);
            Assert.Equal(r1.Name, r2.Name);
            Assert.Equal(r1.Capacity, r2.Capacity);
            Assert.Equal(r1.Floor, r2.Floor);
            Assert.Equal(r1.Price, r2.Price);
        }

        [Fact]
        public void TestGetUserInfo()
        {
            User u = this.facade.GetUserInfo("Lane");
            User u2 = new User();
            u2.Id = 120;
            u2.Login = "Lane";
            u2.Password = "test23";
            u2.Permission = 1;
            CheckEqualUser(u, u2);
        }

        [Fact]
        public void TestGetUserPassword()
        {
            string p1 = this.facade.GetUserPassword("Lane");
            string p2 = "test2";
            Assert.Equal(p1, p2);
        }
        [Fact]
        public void TestGetAllUsers()
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

            List<User> users_t = this.facade.GetAllUsers();
            for (int i = 0; i < users_t.Count; i++)
            {
                CheckEqualUser(users[i], users_t[i]);
            }
        }

        [Fact]
        public void TestGetCountryInfo()
        {
            Country c = this.facade.GetCountryInfo("Индия");
            Country c2 = new Country();
            c2.Id = 120;
            c2.Name = "Индия";
            c2.Capital = "Дели";
            c2.Continent = "Азия";
            CheckEqualCountry(c, c2);
        }
        [Fact]
        public void TestGetAllCountries()
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

            List<Country> countries_t = this.facade.GetAllCountries();
            for (int i = 0; i < countries.Count; i++)
            {
                CheckEqualCountry(countries[i], countries_t[i]);
            }
        }
        [Fact]
        public void TestGetClimatInfo()
        {
            Climat cl = new Climat();
            cl.Id = 25;
            cl.IdCountry = 2;
            cl.TurMonth = "май";
            cl.Temp = 24;
            cl.TempNight = 18;
            cl.TempWater = 21;
            Climat cl2 = this.facade.GetClimatInfo(2);
            CheckEqualClimat(cl, cl2);
        }

        [Fact]
        public void TestGetAllHotels()
        {
            List<Hotel> hotels = new List<Hotel>();

            Hotel h1 = new Hotel();
            h1.Id = 20;
            h1.IdCountry = 3;
            h1.Name = "Best way";
            h1.Stars = 4;
            h1.Beach = true;
            h1.AllInc = true;

            Hotel h2 = new Hotel();
            h2.Id = 24;
            h2.IdCountry = 3;
            h2.Name = "Sun Resort";
            h2.Stars = 5;
            h2.Beach = true;
            h2.AllInc = false;
            hotels.Append(h1);
            hotels.Append(h2);
            List<Hotel> hotels_t = this.facade.GetAllHotels(3);
            for (int i = 0; i < hotels.Count; i++)
            {
                CheckEqualHotel(hotels[i], hotels_t[i]);
            }
        }
        [Fact]
        public void TestGetHotelInfo()
        {
            Hotel h = new Hotel();
            h.Id = 24;
            h.IdCountry = 2;
            h.Name = "Resort";
            h.Stars = 5;
            h.Beach = true;
            h.AllInc = false;
            Hotel h2 = this.facade.GetHotelInfo("Resort");
            CheckEqualHotel(h, h2);
        }

        [Fact]
        public void TestGetRoomInfo()
        {
            Room r = new Room();
            r.Id = 5;
            r.IdHotel = 2;
            r.Name = "Standart";
            r.Capacity = 3;
            r.Floor = 2;
            r.Price = 3000;
            Room r2 = this.facade.GetRoomInfo("Standart", 2);
            CheckEqualRoom(r, r2);
        }
        [Fact]
        public void TestGetAllRooms()
        {
            List<Room> rooms = new List<Room>();

            Room r1 = new Room();
            r1.Id = 3;
            r1.IdHotel = 3;
            r1.Name = "Standart";
            r1.Capacity = 2;
            r1.Floor = 3;
            r1.Price = 2300;

            Room r2 = new Room();
            r2.Id = 4;
            r2.IdHotel = 3;
            r2.Name = "Standart Luxe";
            r2.Capacity = 2;
            r2.Floor = 4;
            r2.Price = 2500;

            rooms.Append(r1);
            rooms.Append(r2);
            List<Room> rooms_t = this.facade.GetAllRooms(3);
            for (int i = 0; i < rooms.Count; i++)
            {
                CheckEqualRoom(rooms[i], rooms_t[i]);
            }
        }
    }
}
