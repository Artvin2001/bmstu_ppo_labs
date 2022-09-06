using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using TurHelper.DataAccesss.EntityStructures;
using TurHelper6.DataAccess.Exceptions;
using TurHelper6;

namespace TurHelper.DataAccesss.PSQLRepository
{
    public class HotelRepositoryPSQL : HotelsRepositoryInterface
    {
        private PSQLContext db;

        public HotelRepositoryPSQL()
        {
            this.db = new PSQLContext();
        }

        public HotelRepositoryPSQL(string ConString)
        {
            this.db = new PSQLContext(ConString);
        }

        public List<Hotels> GetAllHotels(int IdCountry)
        {
            return this.db.Hotels.Where(h => h.IdCountry == IdCountry).ToList();
        }

        public Hotels GetHotelByName(string name)
        {
            try
            {
                var res = this.db.Hotels.Where(h => h.Name == name);
                return res.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new GetHotelException();
            }
        }

        public void InsertHotel(Hotels h)
        {
            try
            {
                this.db.Hotels.Add(h);
                this.db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new InsertHotelException();
            }
        }

        public void DeleteHotel(int Id)
        {
            try
            {
                var h = this.db.Hotels.Find(Id);
                this.db.Remove(h);
                this.db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new DeleteHotelException();
            }
        }
        public void UpdateHotel(Hotels h)
        {
            try
            {
                var hotel = this.db.Hotels.Find(h.Id);
                hotel.Name = h.Name;
                hotel.Stars = h.Stars;
                hotel.AllInc = h.AllInc;
                hotel.Beach = h.Beach;
                this.db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new UpdateHotelException();
            }
        }

        public int GetNewId()
        {
            try
            {
                return this.db.Hotels.Max(a => a.Id) + 1;
            }
            catch (Exception ex)
            {
                throw new GetHotelIdException();
            }
        }
    }
}
