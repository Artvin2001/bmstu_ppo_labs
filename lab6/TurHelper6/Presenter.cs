using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TurHelper.buisness_logic;
using TurHelper.buisness_logic.bl_structures;
using TurHelper5;

namespace TurHelper6
{
    public class Presenter
    {
        private Model model;
        private ViewInterface view;
        private Log log;

        public Presenter(Model model, ViewInterface view)
        {
            this.view = view;
            this.model = model;
            this.log = new Log();
            this.view.UserInfoSelect += LoadUserInfo;
            this.view.UserListSelect += LoadUserList;
            this.view.CountryListSelect += LoadCountriesList;
            this.view.CountryInfoSelect += LoadCountry;
            this.view.ClimatInfoSelect += LoadClimat;
            this.view.HotelInfoSelect += LoadHotel;
            this.view.HotelListSelect += LoadHotelList;
            this.view.RoomInfoSelect += LoadRoom;
            this.view.RoomListSelect += LoadRoomList;
            this.view.CountPrice += LoadCount;
            this.view.ClimatChange += ClimatNew;
            this.view.HotelChange += HotelNew;
        }

        public void LoadUserInfo(string Login)
        {
            try
            {
                User u = this.model.GetUserInfo(Login);
                this.view.SetUserInfo(u);
                this.log.Loging("Info: выведена информация о пользователе");
            }
            catch(Exception ex)
            {
                log.Loging("Error:" + ex);
            }
        }

        public void LoadUserList()
        {
            List<User> users = this.model.GetAllUsers();
            this.view.SetUserList(users);
            this.log.Loging("Info: выведен список пользователей");
        }
        public void LoadCountriesList()
        {
            List<Country> countries = this.model.GetAllCountries();
            this.view.SetCountryList(countries);
            this.log.Loging("Info: выведен список стран");
        }
        public void LoadCountry(string Name)
        {
            try
            {
                Country c = this.model.GetCountry(Name);
                this.view.SetCountry(c);
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
                this.view.SetClimat(cl);
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
                this.view.SetHotel(h);
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
            this.view.SetHotelList(hotels);
            this.log.Loging("Info: выведен список отелей");
        }
        public void LoadRoom(string Name, int IdHotel)
        {try
            {
                Room r = this.model.GetRoom(Name, IdHotel);
                this.view.SetRoom(r);
                this.log.Loging("Info: выведена информация о номере");
            }
            catch (Exception ex) { log.Loging("Error:" + ex); } 
        }
        public void LoadRoomList(int IdHotel)
        {
            List<Room> rooms = this.model.GetAllRooms(IdHotel);
            this.view.SetRoomList(rooms);
            this.log.Loging("Info: выведен список номеров");
        }

        public void LoadCount(string Name, int IdHotel, int days)
        {
            try
            {
                Room r = this.model.GetRoom(Name, IdHotel);
                this.view.SetCount(r.Price, days);
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
                this.view.SetClimat(cl);
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
                this.view.SetHotel(h);
                this.log.Loging("Info: выведен список отель");
            }
            catch (Exception ex)
            {
                log.Loging("Error:" + ex);
            }
        }
    }
}
