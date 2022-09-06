using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using TurHelper.DataAccesss.EntityStructures;
using TurHelper6.DataAccess.Exceptions;
using TurHelper6;
using TurHelper.DataAccesss.EntityStructures;

namespace TurHelper.DataAccesss.MSSQLRepository
{
    public class CityRepositoryMSSQL : CityRepositoryInterface
    {
        private MSSQLContext db;
        private Log log = new Log();

        public CityRepositoryMSSQL()
        {
            this.db = new MSSQLContext();
        }

        public CityRepositoryMSSQL(string ConString)
        {
            this.db = new MSSQLContext(ConString);
        }
        public List<Cities> GetAllCities(int IdCountry)
        {
            try
            {
                log.Loging("Get all cities MSSQL for country " + IdCountry.ToString());
                return this.db.Cities.Where(h => h.IdCountry == IdCountry).ToList();
            }
            catch (Exception ex)
            {
                throw new GetCityException();
            }

        }

        public Cities GetCityByName(string Name)
        {
            try
            {
                var res = this.db.Cities.Where(h => h.Name == Name);
                return res.FirstOrDefault();
            }
            catch (Exception ex)
            { throw new GetCityException(); }
        }
    }
}
