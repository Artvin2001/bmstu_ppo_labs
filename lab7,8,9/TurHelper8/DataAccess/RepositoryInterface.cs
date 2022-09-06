using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

using TurHelper.DataAccesss.EntityStructures;

namespace TurHelper.DataAccesss
{
    public interface UserRepositoryInterface
    {
        List<Users> GetAllUsers();
        Users GetUserByLogin(string Login);
        void InsertUser(Users U);
        bool CheckUserLogin(string Login);
        int GetNewId();
        void DeleteUser(Users U);
        void UpdatePassword(int Id, string Password);
        void UpdateUser(Users u);
    }

    public interface CountriesRepositoryInterface
    {
        List<Countries> GetAllCountires();
        Countries GetCountryByName(string name);
    }

    public interface ClimateRepositoryInterface
    {
        Climate GetClimateById(int Id);

        Climate GetClimateByCountry(int IdCountry);

        void UpdateClimate(Climate cl);
    }

    public interface CityRepositoryInterface
    {
        List<Cities> GetAllCities(int IdCountry);
        Cities GetCityByName(string Name);
    }

    public interface HotelsRepositoryInterface
    {
        List<Hotels> GetAllHotels(int IdCountry);
        Hotels GetHotelByName(string name);
        void InsertHotel(Hotels h);
        void DeleteHotel(int Id);
        void UpdateHotel(Hotels h);
        int GetNewId();
    }

    public interface RoomsRepositoryInterface
    {
        List<Rooms> GetAllRooms(int IdHotel);
        Rooms GetRoomByName(string name, int IdHotel);
        void InsertRoom(Rooms r);
        void DeleteRoom(int Id);
        void UpdateRoom(Rooms r);
        int GetNewId();
    }
}
