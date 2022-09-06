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
    public class CityRepositoryPSQL : CityRepositoryInterface
    {
        private PSQLContext db;
        Log log = new Log();

        public CityRepositoryPSQL()
        {
            this.db = new PSQLContext();
        }

        public CityRepositoryPSQL(string ConString)
        {
            this.db = new PSQLContext(ConString);
        }

        public List<Cities> GetAllCities(int IdCountry)
        {
            try
            {
                log.Loging("Info: get cities - " + IdCountry.ToString());
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
