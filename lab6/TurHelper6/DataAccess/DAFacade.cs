using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

using TurHelper.DataAccesss.PSQLRepository;
using TurHelper.DataAccesss.EntityStructures;
using TurHelper.buisness_logic.bl_structures;
using TurHelper.Util;

using TurHelper6.DataAccess.Exceptions;
using TurHelper6;

namespace TurHelper.DataAccesss
{
    public class DAFacade
    {
        private ClimateRepositoryInterface clim_rep;
        private UserRepositoryInterface user_rep;
        private CountriesRepositoryInterface country_rep;
        private HotelsRepositoryInterface hotel_rep;
        private RoomsRepositoryInterface room_rep;
        private IOC dep;
        private Converter converter;
        private Log log;
        public DAFacade()
        {
            dep = new IOC();

            user_rep = dep.ninjectKernel.Get<UserRepositoryInterface>();
            clim_rep = dep.ninjectKernel.Get<ClimateRepositoryInterface>();
            hotel_rep = dep.ninjectKernel.Get<HotelsRepositoryInterface>();
            room_rep = dep.ninjectKernel.Get<RoomRepositoryPSQL>();
            country_rep = dep.ninjectKernel.Get<CountriesRepositoryInterface>();

            converter = new Converter();
            log = new Log();
        }
        public DAFacade(string Login, string Password)
        {
            dep = new IOC(Login, Password);

            user_rep = dep.ninjectKernel.Get<UserRepositoryInterface>();
            clim_rep = dep.ninjectKernel.Get<ClimateRepositoryInterface>();
            hotel_rep = dep.ninjectKernel.Get<HotelsRepositoryInterface>();
            room_rep = dep.ninjectKernel.Get<RoomRepositoryPSQL>();
            country_rep = dep.ninjectKernel.Get<CountriesRepositoryInterface>();

            converter = new Converter();
            log = new Log();
        }
        public List<User> GetAllUsers()
        {
            List<Users> users = this.user_rep.GetAllUsers();

            List<User> res = new List<User>();

            foreach (Users u in users)
            {
                res.Add(this.converter.ConvertUserDaToBL(u));
            }

            return res;
        }

        public User GetUserByLogin(string Login)
        {
            try
            {
                Users res = this.user_rep.GetUserByLogin(Login);
                return this.converter.ConvertUserDaToBL(res);
            }
            catch (Exception ex)
            {
                throw new GetUserException();
            }
        }

        public void InsertUser(User u)
        {
            try { user_rep.InsertUser(this.converter.ConvertUserBLToDa(u)); }
            catch (Exception ex)
            {
                throw new InsertUserException();
            }
        }
        public bool CheckUserLogin(string Login)
        {
            return this.user_rep.CheckUserLogin(Login);
        }

        public int GetNewIdUser()
        {
            try
            {
                return user_rep.GetNewId();
            }
            catch (Exception ex)
            {
                throw new UseridException();
            }
        }

        public void UpdatePassword(int UId, string Password)
        {
            try { this.user_rep.UpdatePassword(UId, Password); }
            catch (Exception ex) { throw new UpdateUserException(); }
        }
        public void UpdateUser(User u)
        {
            try { this.user_rep.UpdateUser(this.converter.ConvertUserBLToDa(u)); }
            catch (Exception ex) { throw new UpdateUserException(); }
        }

        public List<Country> GetAllCountries()
        {
            List<Countries> countries = country_rep.GetAllCountires();
            List<Country> res = new List<Country>();

            foreach (Countries c in countries)
            {
                res.Add(this.converter.ConvertCountryDAToBL(c));
            }
            return res;
        }

        public Country GetCountryByName(string Name)
        {
            try
            {
                Countries res = country_rep.GetCountryByName(Name);
                return this.converter.ConvertCountryDAToBL(res);
            }
            catch (Exception ex)
            {
                throw new GetCountryException();
            }
        }

        public Climat GetClimatById(int Id)
        {
            try
            {
                Climate res = clim_rep.GetClimateById(Id);
                return this.converter.ConvertClimatDAToBL(res);
            }
            catch (Exception ex)
            {
                throw new GetClimatException();
            }
        }

        public Climat Getclimatebycountry(int IdCountry)
        {
            try
            {
                Climate res = clim_rep.GetClimateByCountry(IdCountry);
                return this.converter.ConvertClimatDAToBL(res);
            }
            catch (Exception ex)
            {
                throw new GetClimatException();
            }
        }
        public void UpdateClimate(Climat cl)
        {
            try { this.clim_rep.UpdateClimate(this.converter.ConvertClimatBLToDA(cl)); }
            catch (Exception ex) { throw new UpdateClimatException(); }
        }

        public List<Hotel> GetAllHotels(int IdCountry)
        {
            List<Hotels> hotels = hotel_rep.GetAllHotels(IdCountry);
            List<Hotel> res = new List<Hotel>();

            foreach (Hotels h in hotels)
            {
                res.Add(this.converter.ConvertHotelDaToBL(h));
            }
            return res;
        }

        public Hotel GetHotelByName(string Name)
        {
            try
            {
                Hotels res = hotel_rep.GetHotelByName(Name);
                return this.converter.ConvertHotelDaToBL(res);
            }
            catch (Exception ex)
            {
                throw new GetHotelException();
            }
        }

        public void InsertHotel(Hotel h)
        {
            try { hotel_rep.InsertHotel(this.converter.ConvertHotelBLToDA(h)); }
            catch (Exception ex) { throw new InsertHotelException(); }
        }

        public void DeleteHotel(int Id)
        {
            try { hotel_rep.DeleteHotel(Id); }
            catch (Exception ex) { throw new DeleteHotelException(); }
        }

        public void UpdateHotel(Hotel h)
        {
            try { hotel_rep.UpdateHotel(this.converter.ConvertHotelBLToDA(h)); }
            catch (Exception ex) { throw new UpdateHotelException(); }
        }
        public int GetNewIdHotel()
        {
            try { return hotel_rep.GetNewId(); }
            catch (Exception ex) { throw new GetHotelIdException(); }
        }

        public List<Room> GetAllRooms(int IdHotel)
        {
            List<Rooms> rooms = room_rep.GetAllRooms(IdHotel);
            List<Room> res = new List<Room>();

            foreach (Rooms r in rooms)
            {
                res.Add(this.converter.ConvertRoomDAToBL(r));
            }
            return res;
        }
        public Room GetRoomByName(string Name, int IdHotel)
        {
            try
            {
                Rooms res = room_rep.GetRoomByName(Name, IdHotel);
                return this.converter.ConvertRoomDAToBL(res);
            }
            catch (Exception ex)
            {
                throw new GetRoomException();
            }
        }
        public void InsertRoom(Room r)
        {
            try { this.room_rep.InsertRoom(this.converter.ConvertRoomBLToDA(r)); }
            catch (Exception ex) { throw new InsertRoomException(); }
        }
        public void DeleteRoom(int Id)
        {
            try { this.room_rep.DeleteRoom(Id); }
            catch (Exception ex) { throw new DeleteRoomException(); }
        }
        public void UpdateRoom(Room r)
        {
            try { this.room_rep.UpdateRoom(this.converter.ConvertRoomBLToDA(r)); }
            catch (Exception ex) { throw new UpdateRoomException(); }
        }
        public int GetNewIdRoom()
        {
            try { return room_rep.GetNewId(); }
            catch (Exception ex) { throw new GetRoomIdException(); }
        }
    }
}
