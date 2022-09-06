using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TurHelper.buisness_logic.bl_structures;
using TurHelper6;

namespace TurHelper5
{
    public class View : ViewInterface
    {
        public event Action<string> UserInfoSelect;
        public event Action UserListSelect;
        public event Action CountryListSelect;
        public event Action<string> CountryInfoSelect;
        public event Action<int> ClimatInfoSelect;
        public event Action<int> HotelListSelect;
        public event Action<string> HotelInfoSelect;
        public event Action<int> RoomListSelect;
        public event Action<string,int> RoomInfoSelect;
        public event Action<string, int, int> CountPrice;
        public event Action<int, string, int, int, int> ClimatChange;
        public event Action<string, int, bool, bool> HotelChange;
        public View() { }
        public void StartMenu()
        {
            string Menu = "\nВыберите нужный пункт меню:\n" +
                "0 - Выход\n" +
                "1 - Вывод информации о пользователе\n" +
                "2 - Вывод всех пользователей\n" +
                "3 - Вывод всех стран\n" +
                "4 - Вывод информации о стране\n" +
                "5 - Вывод климата страны\n" +
                "6 - Вывод всех отелей в стране\n" +
                "7 - Вывод всех номеров в отеле\n" +
                "8 - Вывод информации об отеле\n" +
                "9 - Вывод информации о номере\n" +
                "10 - Стоимость тура \n" +
                "11 - Изменить климат \n" +
                "12 - Изменить отель\n";

            string Choice = "";
            Log log = new Log();
            log.Loging("Начало работы меню");

            while (Choice != "0")
            {
                switch (Choice)
                {
                    case "1":
                        Console.Write("Введите логин пользователя: ");
                        string login = Console.ReadLine();
                        this.UserInfoSelect(login);
                        break;
                    case "2":
                        this.UserListSelect();
                        break;
                    case "3":
                        this.CountryListSelect();
                        break;
                    case "4":
                        Console.WriteLine("Введите название страны");
                        string name = Console.ReadLine();
                        this.CountryInfoSelect(name);
                        break;
                    case "5":
                        Console.WriteLine("Введите Id страны");
                        int Idсountr = Convert.ToInt32(Console.ReadLine());
                        this.ClimatInfoSelect(Idсountr);
                        break;
                    case "6":
                        Console.WriteLine("Введите Id страны");
                        int IdCountr = Convert.ToInt32(Console.ReadLine());
                        this.HotelListSelect(IdCountr);
                        break;
                    case "7":
                        Console.WriteLine("Введите Id отеля");
                        int IdHotel = Convert.ToInt32(Console.ReadLine());
                        this.RoomListSelect(IdHotel);
                        break;
                    case "8":
                        Console.WriteLine("Введите название отеля");
                        string name_h = Console.ReadLine();
                        this.HotelInfoSelect(name_h);
                        break;
                    case "9":
                        Console.WriteLine("Введите название номера");
                        string name_r = Console.ReadLine();
                        Console.WriteLine("Введите Id отеля");
                        int IdH = Convert.ToInt32(Console.ReadLine());
                        this.RoomInfoSelect(name_r, IdH);
                        break;
                    case "10":
                        Console.WriteLine("Введите название номера");
                        string name_room = Console.ReadLine();
                        Console.WriteLine("Введите Id отеля");
                        int IdHot = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите количество дней");
                        int days = Convert.ToInt32(Console.ReadLine());
                        this.CountPrice(name_room, IdHot, days);
                        break;
                    case "11":
                        Console.WriteLine("Введите Id страны");
                        int Id_cl = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите Туристический месяц");
                        string Tur_month = Console.ReadLine();
                        Console.WriteLine("Введите Среднюю температуру");
                        int temp = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите Среднюю температуру ночью");
                        int night = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите Среднюю температуру воды");
                        int water = Convert.ToInt32(Console.ReadLine());
                        this.ClimatChange(Id_cl, Tur_month, temp, night, water);
                        break;
                    case "12":
                        Console.WriteLine("Введите название отеля");
                        string name_hotel = Console.ReadLine();
                        Console.WriteLine("Введите количество звезд");
                        int stars = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите 1 если есть пляж, иначе 0");
                        int beach_c = Convert.ToInt32(Console.ReadLine());
                        bool beach = false;
                        if (beach_c == 1)
                                beach = true;
                        bool allinc = false;
                        Console.WriteLine("Введите 1 если есть Все включено, иначе 0");
                        int allinc_c = Convert.ToInt32(Console.ReadLine());
                        if (allinc_c == 1)
                            allinc = true;
                        this.HotelChange(name_hotel, stars, beach, allinc);
                        break;
                }
                Console.WriteLine(Menu);
                Console.Write("Выбор: ");
                Choice = Console.ReadLine();
                Console.WriteLine();
            }
            log.Loging("Конец работы");
        }

        public void SetUserInfo(User u)
        {
            string res = "Id - " + u.Id + "; Логин - " + u.Login + "; Права доступа - " + u.Permission;
            Console.WriteLine(res);
        }

        public void SetUserList(List<User> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                SetUserInfo(list[i]);
            }
        }
        public void SetClimat(Climat cl)
        {
            string res = "Id - " + cl.Id + "Id страны - " + cl.IdCountry + "; Туристический месяц - " + cl.TurMonth + "; Средняя температура - " + cl.Temp
                + "; Средняя температура ночью - " + cl.TempNight + "; Средняя температура воды - " + cl.TempWater;
            Console.WriteLine(res);
        }
        public void SetCountry(Country c)
        {
            Console.WriteLine("Id - " + c.Id + "; Название - " + c.Name + "; Столица - " + c.Capital + "; Континент" + c.Continent);
        }

        public void SetCountryList(List<Country> list)
        {
            for(int i = 0; i < list.Count; i++)
            {
                SetCountry(list[i]);
            }
        }

        public void SetHotel(Hotel h)
        {
            string res = "Id - " + h.Id + "; Id страны - " + h.IdCountry + "; Название - " + h.Name + "; Звезды - " + h.Stars;
            if (h.Beach == true)
                res += "; Есть пляж";
            else
                res += "; Нет пляжа";
            if (h.AllInc == true)
                res += "; Все включено доступно";
            else
                res += "; Все включено недоступно";
            Console.WriteLine(res);
        }

        public void SetHotelList(List<Hotel> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                SetHotel(list[i]);
            }
        }


        public void SetRoom(Room r)
        {
            string res = "Id - " + r.Id + "; Id отеля - " + r.IdHotel + "; Название - " + r.Name + "; Вместимость - " + r.Capacity +
                "; Этаж - " + r.Floor + "; Цена - " + r.Price;
            Console.WriteLine(res);
        }

        public void SetRoomList(List<Room> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                SetRoom(list[i]);
            }
        }

        public void SetCount(int Price, int days)
        {
            int res = Price * days;
            Console.WriteLine("Стоимость:" + res);
        }

    }
}
