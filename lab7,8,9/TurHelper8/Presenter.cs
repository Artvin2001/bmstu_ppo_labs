using System;
using System.Collections.Generic;
using System.Text;

using TurHelper.buisness_logic;
using TurHelper.buisness_logic.bl_structures;
using TurHelper6;

namespace TurHelper8
{
    public class Presenter
    {
        private Model model;
        private Log log;
        public bool CheckLogin(string Login)
        {
            return this.model.CheckLogin(Login);
        }

        public void LoadUserInfo(string Login)
        {
            try
            {
                User u = this.model.GetUserInfo(Login);
                this.log.Loging("Info: выведена информация о пользователе");
            }
            catch (Exception ex)
            {
                log.Loging("Error:" + ex);
            }
        }

        public void LoadUserList()
        {
            List<User> users = this.model.GetAllUsers();
            this.log.Loging("Info: выведен список пользователей");
        }
        public void LoadCountriesList()
        {
            List<Country> countries = this.model.GetAllCountries();
            this.log.Loging("Info: выведен список стран");
        }
        public void LoadCountry(string Name)
        {
            try
            {
                Country c = this.model.GetCountry(Name);
                this.log.Loging("Info: выведена информация о стране");
            }
            catch (Exception ex)
            {
                log.Loging("Error:" + ex);
            }
        }
        public void LoadClimat(int IdCountry)
        {
            try
            {
                Climat cl = this.model.GetClimat(IdCountry);
                this.log.Loging("Info: выведена информация о климате");
            }
            catch (Exception ex)
            {
                log.Loging("Error:" + ex);
            }
        }
        public void LoadHotel(string Name)
        {
            try
            {
                Hotel h = this.model.GetHotel(Name);
                this.log.Loging("Info: выведена информация об отеле");
            }
            catch (Exception ex)
            {
                log.Loging("Error:" + ex);
            }
        }
        public void LoadHotelList(int Id)
        {
            List<Hotel> hotels = this.model.GetAllHotels(Id);
            this.log.Loging("Info: выведен список отелей");
        }
        public void LoadRoom(string Name, int IdHotel)
        {
            try
            {
                Room r = this.model.GetRoom(Name, IdHotel);
                this.log.Loging("Info: выведена информация о номере");
            }
            catch (Exception ex) { log.Loging("Error:" + ex); }
        }
        public void LoadRoomList(int IdHotel)
        {
            List<Room> rooms = this.model.GetAllRooms(IdHotel);
            this.log.Loging("Info: выведен список номеров");
        }
        public void LoadCount(string Name, int IdHotel, int days)
        {
            try
            {
                Room r = this.model.GetRoom(Name, IdHotel);
            }
            catch (Exception ex)
            {
                log.Loging("Error:" + ex);
            }
        }

        public void ClimatNew(int IdCountry, string month, int temp, int night, int water)
        {
            try
            {
                Climat cl = this.model.GetClimat(IdCountry);
                cl.TurMonth = month;
                cl.Temp = temp;
                cl.TempNight = night;
                cl.TempWater = water;
                this.model.UpdateClimat(cl);
                this.log.Loging("Info: изменен климат");
            }
            catch (Exception ex)
            {
                log.Loging("Error:" + ex);
            }
        }
        public void HotelNew(string Name, int stars, bool beach, bool allinc)
        {
            try
            {
                Hotel h = this.model.GetHotel(Name);
                h.Stars = stars;
                h.Beach = beach;
                h.AllInc = allinc;
                this.model.Updatehotel(h);
                this.log.Loging("Info: выведен список отель");
            }
            catch (Exception ex)
            {
                log.Loging("Error:" + ex);
            }
        }
    }
}
