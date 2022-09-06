using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TurHelper.DataAccesss;
using TurHelper.buisness_logic.bl_structures;
using TurHelper6;

namespace TurHelper.buisness_logic
{
    public class BLFacade
    {
        private DAFacade facade;
        private Log log = new Log();
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
            try
            {
                return this.facade.GetUserByLogin(Login);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void RegisterUser(User u)
        {
            try
            {
                u.Id = facade.GetNewIdUser();
                this.facade.InsertUser(u);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CheckUserLogin(string Login)
        {
            return facade.CheckUserLogin(Login);
        }

        public string GetUserPassword(string Login)
        {
            try
            {
                return this.facade.GetUserByLogin(Login).Password;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<User> GetAllUsers()
        {
            return this.facade.GetAllUsers();
        }
        public void UpdateUser(User user)
        {
            try
            {
                this.facade.UpdateUser(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //country
        public List<Country> GetAllCountries()
        {
            return this.facade.GetAllCountries();
        }
        public Country GetCountryInfo(string name)
        {
            try
            {
                return this.facade.GetCountryByName(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //climate
        public Climat GetClimatInfo(int IdCountry)
        {
            try
            {
                return this.facade.Getclimatebycountry(IdCountry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateClimat(Climat cl)
        {
            try
            {
                this.facade.UpdateClimate(cl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //hotels
        public List<Hotel> GetAllHotels(int IdCountry)
        {
            return this.facade.GetAllHotels(IdCountry);
        }
        public Hotel GetHotelInfo(string Name)
        {
            try
            {
                return this.facade.GetHotelByName(Name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertHotel(Hotel h)
        {
            try
            {
                h.Id = facade.GetNewIdHotel();
                this.facade.InsertHotel(h);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteHotel(int Id)
        {
            try
            {
                this.facade.DeleteHotel(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateHotel(Hotel h)
        {
            try
            {
                this.facade.UpdateHotel(h);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //room
        public List<Room> GetAllRooms(int IdHotel)
        {
            return this.facade.GetAllRooms(IdHotel);
        }
        public Room GetRoomInfo(string Name, int IdHotel)
        {
            try
            {
                return this.facade.GetRoomByName(Name, IdHotel);
            }
            catch (Exception ex) { throw ex; }
         }
        public void InsertRoom(Room r)
        {
            try
            {
                r.Id = facade.GetNewIdRoom();
                this.facade.InsertRoom(r);
            }
            catch (Exception ex) { throw ex; }
        }
        public void DeleteRoom(int Id)
        {
            try
            {
                this.facade.DeleteRoom(Id);
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
    }
}
