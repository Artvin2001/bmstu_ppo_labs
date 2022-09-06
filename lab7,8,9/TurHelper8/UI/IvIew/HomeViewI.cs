using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TurHelper.buisness_logic.bl_structures;

namespace TurHelper8.UI.IvIew
{
    public interface HomeViewI
    {
        event Action FormLoaded;
        event Action RefreshForm;
        //void SetUserInfo(User user);
        void SetCountriesList(List<Country> countries);
        void SetHotelList(List<Hotel> hotels);
        void SetCitiesList(List<City> cities);
        void SetRoomsList(List<Room> rooms);
        void SetClimat(Climat climat);
        void SetHotel(Hotel hotel);
        void SetCountry(Country c);
        void SetRoom(Room r);

        void SetCity(City c);

        void SetUserList(List<User> users);
        void SetUser(User u);
    }
}
