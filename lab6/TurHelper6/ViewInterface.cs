using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TurHelper.buisness_logic.bl_structures;


namespace TurHelper5
{
    public interface ViewInterface
    {
        event Action<string> UserInfoSelect;
        event Action UserListSelect;
        void SetUserInfo(User u);
        void SetUserList(List<User> list);
        event Action CountryListSelect;
        event Action<string> CountryInfoSelect;
        event Action<int> ClimatInfoSelect;
        void SetClimat(Climat cl);
        void SetCountry(Country c);
        void SetCountryList(List<Country> list);
        event Action<int> HotelListSelect;
        event Action<string> HotelInfoSelect;
        void SetHotel(Hotel h);
        void SetHotelList(List<Hotel> list);
        event Action<int> RoomListSelect;
        event Action<string, int> RoomInfoSelect;
        void SetRoom(Room r);
        void SetRoomList(List<Room> list);
        event Action<string, int, int> CountPrice;
        void SetCount(int Price, int days);
        event Action<int, string, int, int, int> ClimatChange;
        event Action<string, int, bool, bool> HotelChange;

    }
}
