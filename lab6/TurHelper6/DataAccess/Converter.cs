using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TurHelper.buisness_logic.bl_structures;
using TurHelper.DataAccesss.EntityStructures;

using TurHelper6.DataAccess.Exceptions;
using TurHelper6;

namespace TurHelper.DataAccesss
{
    public class Converter
    {
        private Log log = new Log();
        public User ConvertUserDaToBL(Users u)
        {
            try
            {
                User res = new User();
                res.Id = u.Id;
                res.Login = u.Login;
                res.Password = u.Password;
                res.Permission = u.Permission;
                return res;
            }
            catch (Exception ex)
            {
                log.Loging("Error:" + ex);
                throw ex;
            }
        }
        public Users ConvertUserBLToDa(User u)
        {
            try
            {
                Users res = new Users();
                res.Id = u.Id;
                res.Login = u.Login;
                res.Password = u.Password;
                res.Permission = u.Permission;
                return res;
            }
            catch (Exception ex)
            {
                log.Loging("Error:" + ex);
                throw ex;
            }
        }

        public Room ConvertRoomDAToBL(Rooms r)
        {
            try
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
            catch (Exception ex)
            {
                log.Loging("Error:" + ex);
                throw ex;
            }
        }
        public Rooms ConvertRoomBLToDA(Room r)
        {
            try
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
            catch (Exception ex)
            {
                log.Loging("Error:" + ex);
                throw ex;
            }
        }

        public Hotel ConvertHotelDaToBL(Hotels h)
        {
            try
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
            catch (Exception ex)
            {
                log.Loging("Error:" + ex);
                throw ex;
            }
        }
        public Hotels ConvertHotelBLToDA(Hotel h)
        {
            try
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
            catch (Exception ex)
            {
                log.Loging("Error:" + ex);
                throw ex;
            }
        }

        public Country ConvertCountryDAToBL(Countries c)
        {
            try
            {
                Country res = new Country();
                res.Id = c.Id;
                res.Name = c.Name;
                res.Capital = c.Capital;
                res.Continent = c.Continent;
                return res;
            }
            catch (Exception ex)
            {
                log.Loging("Error:" + ex);
                throw ex;
            }
        }
        public Countries ConvertCountryBLToDA(Country c)
        {
            try
            {
                Countries res = new Countries();
                res.Id = c.Id;
                res.Name = c.Name;
                res.Capital = c.Capital;
                res.Continent = c.Continent;
                return res;
            }
            catch (Exception ex)
            {
                log.Loging("Error:" + ex);
                throw ex;
            }
        }

        public Climat ConvertClimatDAToBL(Climate cl)
        {
            try
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
            catch (Exception ex)
            {
                log.Loging("Error:" + ex);
                throw ex;
            }
        }
        public Climate ConvertClimatBLToDA(Climat cl)
        {
            try
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
            catch (Exception ex)
            {
                log.Loging("Error:" + ex);
                throw ex;
            }
        }
    }
}
