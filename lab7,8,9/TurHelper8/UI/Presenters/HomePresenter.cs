using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TurHelper.buisness_logic.bl_structures;
using TurHelper6;
using TurHelper8.UI.IvIew;

namespace TurHelper8.UI.Presenters
{
    public class HomePresenter
    {
        private Model model;
        private HomeViewI view;
        private int IdCountry;
        public HomePresenter(HomeViewI view, Model model)
        {
            this.view = view;
            this.model = model;
            this.IdCountry = 0;

            //this.view.FormLoaded += LoadCountries;
            //this.view.FormLoaded += LoadHotels(IdCountry);

            //this.view.RefreshForm += LoadCountries;
        }
        public void LoadCountries()
        {
            try
            {
                var Countires = this.model.GetAllCountries();
                this.view.SetCountriesList(Countires);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void LoadUsers()
        {
            try {
                var Users = this.model.GetAllUsers();
                this.view.SetUserList(Users);
            } catch (Exception ex) { throw ex; }
        }

        public void LoadHotels(int Id)
        {try
            {
                var hotels = this.model.GetAllHotels(Id);
                this.view.SetHotelList(hotels);
            }
            catch (Exception ex) { throw ex; }
        }

        public void LoadCities(int Id)
        {try
            {
                var cities = this.model.GetAllCities(Id);
                this.view.SetCitiesList(cities);
            }
            catch (Exception ex) { throw ex; }
        }

        public void LoadRooms(int Id)
        {try
            {
                var rooms = this.model.GetAllRooms(Id);
                this.view.SetRoomsList(rooms);
            }
            catch (Exception ex) { throw ex; }
        }

        public void LoadClimat(int IdCountry)
        {try
            {
                var cl = this.model.GetClimat(IdCountry);
                this.view.SetClimat(cl);
            }
            catch (Exception ex) { throw ex; }
        }

        public void LoadHotel(string Name)
        {try
            {
                var h = this.model.GetHotel(Name);
                this.view.SetHotel(h);
            }
            catch (Exception ex) { throw ex; }
        }

        public void LoadCity(string Name)
        {try
            {
                var c = this.model.GetCity(Name);
                this.view.SetCity(c);
            }
            catch (Exception ex) { throw ex; }
        }

        public void LoadUser(string Login)
        {try
            {
                var u = this.model.GetUserInfo(Login);
                this.view.SetUser(u);
            }
            catch (Exception ex) { throw ex; }
        }

        public void LoadCountry(string Name)
        {try
            {
                var c = this.model.GetCountry(Name);
                this.view.SetCountry(c);
            }
            catch (Exception ex) { throw ex; }
        }

        public void LoadRoom(string Name, int Id)
        {try
            {
                var r = this.model.GetRoom(Name, Id);
                this.view.SetRoom(r);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
