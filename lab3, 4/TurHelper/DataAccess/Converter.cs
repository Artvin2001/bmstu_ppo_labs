using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TurHelper.buisness_logic.bl_structures;
using TurHelper.DataAccesss.EntityStructures;

namespace TurHelper.DataAccesss
{
    public class Converter
    {
        public User ConvertUserDaToBL(Users u)
        {
            User res = new User();
            res.Id = u.Id;
            res.Login = u.Login;
            res.Password = u.Password;
            res.Permission = u.Permission;
            return res;
        }
        public Users ConvertUserBLToDa(User u)
        {
            Users res = new Users();
            res.Id = u.Id;
            res.Login = u.Login;
            res.Password = u.Password;
            res.Permission = u.Permission;
            return res;
        }

        public Room ConvertRoomDAToBL(Rooms r)
        {
            Room res = new Room();
            res.Id = r.Id;
            res.IdHotel = r.IdHotel;
            res.Name = r.Name;
            res.Price = r.Price;
            res.Capacity = r.Capacity;
            res.Floor = r.Floor;
            return res;
        }
        public Rooms ConvertRoomBLToDA(Room r)
        {
            Rooms res = new Rooms();
            res.Id = r.Id;
            res.IdHotel = r.IdHotel;
            res.Name = r.Name;
            res.Price = r.Price;
            res.Capacity = r.Capacity;
            res.Floor = r.Floor;
            return res;
        }

        public Hotel ConvertHotelDaToBL(Hotels h)
        {
            Hotel res = new Hotel();
            res.Id = h.Id;
            res.IdCountry = h.IdCountry;
            res.Name = h.Name;
            res.Stars = h.Stars;
            res.Beach = h.Beach;
            res.AllInc = h.AllInc;
            return res;
        }
        public Hotels ConvertHotelBLToDA(Hotel h)
        {
            Hotels res = new Hotels();
            res.Id = h.Id;
            res.IdCountry = h.IdCountry;
            res.Name = h.Name;
            res.Stars = h.Stars;
            res.Beach = h.Beach;
            res.AllInc = h.AllInc;
            return res;
        }

        public Country ConvertCountryDAToBL(Countries c)
        {
            Country res = new Country();
            res.Id = c.Id;
            res.Name = c.Name;
            res.Capital = c.Capital;
            res.Continent = c.Continent;
            return res;
        }
        public Countries ConvertCountryBLToDA(Country c)
        {
            Countries res = new Countries();
            res.Id = c.Id;
            res.Name = c.Name;
            res.Capital = c.Capital;
            res.Continent = c.Continent;
            return res;
        }

        public Climat ConvertClimatDAToBL(Climate cl)
        {
            Climat res = new Climat();
            res.Id = cl.Id;
            res.IdCountry = cl.IdCountry;
            res.TurMonth = cl.TurMonth;
            res.Temp = cl.Temp;
            res.TempNight = cl.TempNight;
            res.TempWater = cl.TempWater;
            return res;
        }
        public Climate ConvertClimatBLToDA(Climat cl)
        {
            Climate res = new Climate();
            res.Id = cl.Id;
            res.IdCountry = cl.IdCountry;
            res.TurMonth = cl.TurMonth;
            res.Temp = cl.Temp;
            res.TempNight = cl.TempNight;
            res.TempWater = cl.TempWater;
            return res;
        }
    }
}
