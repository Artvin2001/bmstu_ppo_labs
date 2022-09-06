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
        public DAFacade()
        {
            dep = new IOC();

            user_rep = dep.ninjectKernel.Get<UserRepositoryInterface>();
            clim_rep = dep.ninjectKernel.Get<ClimateRepositoryInterface>();
            hotel_rep = dep.ninjectKernel.Get<HotelsRepositoryInterface>();
            room_rep = dep.ninjectKernel.Get<RoomRepositoryPSQL>();
            country_rep = dep.ninjectKernel.Get<CountriesRepositoryInterface>();

            converter = new Converter();
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
            Users res = this.user_rep.GetUserByLogin(Login);
            return this.converter.ConvertUserDaToBL(res);
        }

        public void InsertUser(User u)
        {
            user_rep.InsertUser(this.converter.ConvertUserBLToDa(u));
        }
        public bool CheckUserLogin(string Login)
        {
            return this.user_rep.CheckUserLogin(Login);
        }

        public int GetNewIdUser()
        {
            return user_rep.GetNewId();
        }

        public void UpdatePassword(int UId, string Password)
        {
            this.user_rep.UpdatePassword(UId, Password);
        }
        public void UpdateUser(User u)
        {
            this.user_rep.UpdateUser(this.converter.ConvertUserBLToDa(u));
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
            Countries res = country_rep.GetCountryByName(Name);
            return this.converter.ConvertCountryDAToBL(res);
        }

        public Climat GetClimatById(int Id)
        {
            Climate res = clim_rep.GetClimateById(Id);
            return this.converter.ConvertClimatDAToBL(res);
        }

        public Climat Getclimatebycountry(int IdCountry)
        {
            Climate res = clim_rep.GetClimateByCountry(IdCountry);
            return this.converter.ConvertClimatDAToBL(res);
        }
        public void UpdateClimate(Climat cl)
        {
            this.clim_rep.UpdateClimate(this.converter.ConvertClimatBLToDA(cl));
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
            Hotels res = hotel_rep.GetHotelByName(Name);
            return this.converter.ConvertHotelDaToBL(res);
        }

        public void InsertHotel(Hotel h)
        {
            hotel_rep.InsertHotel(this.converter.ConvertHotelBLToDA(h));
        }

        public void DeleteHotel(int Id)
        {
            hotel_rep.DeleteHotel(Id);
        }

        public void UpdateHotel(Hotel h)
        {
            hotel_rep.UpdateHotel(this.converter.ConvertHotelBLToDA(h));
        }
        public int GetNewIdHotel()
        {
            return hotel_rep.GetNewId();
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
            Rooms res = room_rep.GetRoomByName(Name, IdHotel);
            return this.converter.ConvertRoomDAToBL(res);
        }
        public void InsertRoom(Room r)
        {
            this.room_rep.InsertRoom(this.converter.ConvertRoomBLToDA(r));
        }
        public void DeleteRoom(int Id)
        {
            this.room_rep.DeleteRoom(Id);
        }
        public void UpdateRoom(Room r)
        {
            this.room_rep.UpdateRoom(this.converter.ConvertRoomBLToDA(r));
        }
        public int GetNewIdRoom()
        {
            return room_rep.GetNewId();
        }
    }
}
