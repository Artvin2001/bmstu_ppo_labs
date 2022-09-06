using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TurHelper.buisness_logic.bl_structures;

namespace TurHelper5
{
    public class View : ViewInterface
    {
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
                "7 - Вывод информации об отеле \n" +
                "8 - Вывод всех номеров в отеле\n" +
                "9 - Вывод информации о номере";

            string Choice = "";

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
                        this.ClimatInfoselect(Idсountr);
                        break;
                    case "6":
                        Console.WriteLine("Введите Id страны");
                        int IdCountr = Convert.ToInt32(Console.ReadLine());
                        this.HotelListSelect(IdCountr);
                        break;
                    case "7":
                        Console.WriteLine("Введите название отеля");
                        string nameh = Console.ReadLine();
                        this.HotelInfoSelect(nameh);
                        break;
                    case "8":
                        Console.WriteLine("Введите Id страны");
                        int IdCountry = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите Id отеля");
                        int IdHotel = Convert.ToInt32(Console.ReadLine());
                        this.RoomListSelect(IdCountry, IdHotel);
                        break;
                    case "9":
                        Console.WriteLine("Введите Id отеля");
                        int IdHotel1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите название номера");
                        string namer = Console.ReadLine();
                        this.RoomInfoSelect(namer, IdHotel1);
                        break;
                }
                Console.WriteLine(Menu);
                Console.Write("Выбор: ");
                Choice = Console.ReadLine();
                Console.WriteLine();
            }
        }

        public void UserInfoSelect(string Login)
        {
            User u = new User();
            u.Login = Login;
            u.Id = 2;
            u.Permission = 2;
            string res = "Id - "+ u.Id + "; Логин - " + u.Login + "; Права доступа - " + u.Permission;
            Console.WriteLine(res);
        }

        public void UserListSelect()
        {
            List<User> users = new List<User>();

            User u1 = new User();
            u1.Id = 140;
            u1.Login = "test1";
            u1.Password = "test12345";
            u1.Permission = 2;

            User u2 = new User();
            u2.Id = 141;
            u2.Login = "test2";
            u2.Password = "test12345";
            u2.Permission = 3;

            users.Add(u1);
            users.Add(u2);

            for (int i = 0; i < users.Count; i++)
            {
                string res = "Id - " + users[i].Id + "; Логин - " + users[i].Login;
                Console.WriteLine(res);
            }
        }

        public void CountryListSelect()
        {
            List<Country> countries = new List<Country>();

            Country c1 = new Country();
            c1.Id = 120;
            c1.Name = "Индия";
            c1.Capital = "Дели";
            c1.Continent = "Азия";

            Country c2 = new Country();
            c2.Id = 121;
            c2.Name = "Франция";
            c2.Capital = "Париж";
            c2.Continent = "Европа";
            countries.Add(c1);
            countries.Add(c2);
            for (int i = 0; i < countries.Count; i++)
            {
                string res = "Название - " + countries[i].Name;
                Console.WriteLine(res);
            }
        }

        public void CountryInfoSelect(string Name)
        {
            Country c1 = new Country();
            c1.Id = 120;
            c1.Name = Name;
            c1.Capital = "Гринванд";
            c1.Continent = "Европа";
            Console.WriteLine("Id - " + c1.Id + "; Название - "+ c1.Name + "; Столица - " + c1.Capital + "; Континент - " + c1.Continent);
        }

        public void ClimatInfoselect(int IdCountry)
        {
            Climat cl = new Climat();
            cl.IdCountry = IdCountry;
            cl.TurMonth = "Январь";
            cl.Temp = 29;
            cl.TempNight = 24;
            cl.TempWater = 25;
            Console.WriteLine("Месяц - " + cl.TurMonth + "; Средняя температура - " + cl.Temp + 
                "; Средняя температура ночью - " + cl.TempNight + "; Средняя температура воды - " + cl.TempWater);
        }
        public void SetUserInfo(User u)
        {
            string res = "Id - " + u.Id + "; Логин - " + u.Login + "; Права доступа - " + u.Permission;
            Console.WriteLine(res);
        }
        public void SetClimat(Climat cl)
        {
            string res = "Id страны - " + cl.IdCountry + "; Туристический месяц - " + cl.TurMonth + "; Средняя температура - " + cl.Temp
                + "; Средняя температура ночью - " + cl.TempNight + "; Средняя температура воды - " + cl.TempWater;
            Console.WriteLine(res);
        }

        public void HotelListSelect(int IdCountry)
        {
            List<Hotel> hotels = new List<Hotel>();

            Hotel h1 = new Hotel();
            h1.Id = 20;
            h1.IdCountry = IdCountry;
            h1.Name = "Best way";
            h1.Stars = 4;
            h1.Beach = true;
            h1.AllInc = true;

            Hotel h2 = new Hotel();
            h2.Id = 24;
            h2.IdCountry = IdCountry;
            h2.Name = "Sun Resort";
            h2.Stars = 5;
            h2.Beach = true;
            h2.AllInc = false;
            hotels.Add(h1);
            hotels.Add(h2);
            for (int i = 0; i < hotels.Count; i++)
            {
                Console.WriteLine("Название отеля - " + hotels[i].Name + hotels[i].Stars + "*");
            }
        }

        public void HotelInfoSelect(string Name)
        {
            Hotel h = new Hotel();
            h.Id = 5;
            h.Name = Name;
            h.IdCountry = 2;
            h.Stars = 4;
            h.Beach = true;
            h.AllInc = true;
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

        public void RoomListSelect(int IdCountry, int IdHotel)
        {
            List<Room> rooms = new List<Room>();

            Room r1 = new Room();
            r1.Id = 3;
            r1.IdHotel = IdHotel;
            r1.Name = "Standart";
            r1.Capacity = 2;
            r1.Floor = 3;
            r1.Price = 2300;

            Room r2 = new Room();
            r2.Id = 4;
            r2.IdHotel = IdHotel;
            r2.Name = "Standart Luxe";
            r2.Capacity = 2;
            r2.Floor = 4;
            r2.Price = 2500;

            rooms.Add(r1);
            rooms.Add(r2);
            for (int i = 0; i < rooms.Count; i++)
            {
                Console.WriteLine("Название номера - " + rooms[i].Name);
            }
        }

        public void RoomInfoSelect(string Name, int IdHotel)
        {
            Room r1 = new Room();
            r1.Id = 3;
            r1.IdHotel = IdHotel;
            r1.Name = Name;
            r1.Capacity = 2;
            r1.Floor = 3;
            r1.Price = 2300;
            Console.WriteLine("Id - " + r1.Id + "; Название - " + r1.Name + "; Вместимость - " + r1.Capacity + 
                "; Этаж - " + r1.Floor + "; Цена - " + r1.Price);
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

        public void AddHotel(Hotel h)
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

        public void SetRoom(Room r)
        {
            string res = "Id - " + r.Id + "; Id отеля - " + r.IdHotel + "; Название - " + r.Name + "; Вместимость - " + r.Capacity +
                "; Этаж - " + r.Floor + "; Цена - " + r.Price;
            Console.WriteLine(res);
        }

        public void AddRoom(Room r)
        {
            string res = "Id - " + r.Id + "; Id отеля - " + r.IdHotel + "; Название - " + r.Name + "; Вместимость - " + r.Capacity +
                "; Этаж - " + r.Floor + "; Цена - " + r.Price;
            Console.WriteLine(res);
        }

        public int CountPrice(Room r, int days)
        {
            int res = r.Price * days;
            return res;
        }
    }
}
