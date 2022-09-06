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
        void UserInfoSelect(string Login);
        void UserListSelect();
        void SetUserInfo(User u);
        void CountryListSelect();
        void CountryInfoSelect(string Name);
        void ClimatInfoselect(int IdCountry);
        void SetClimat(Climat cl);
        void HotelListSelect(int IdCountry);
        void HotelInfoSelect(string Name);
        void SetHotel(Hotel h);
        void AddHotel(Hotel h);
        void RoomListSelect(int Idcountry, int IdHotel);
        void RoomInfoSelect(string Name, int IdHotel);
        void SetRoom(Room r);
        void AddRoom(Room r);
        int CountPrice(Room r, int days);

    }
}
