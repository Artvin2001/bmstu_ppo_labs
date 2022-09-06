using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using TurHelper.DataAccesss.EntityStructures;
using TurHelper6.DataAccess.Exceptions;
using TurHelper6;

namespace TurHelper.DataAccesss.MSSQLRepository
{
    public class CountryRepositoryMSSQL : CountriesRepositoryInterface
    {
        private MSSQLContext db;
        public CountryRepositoryMSSQL()
        {
            this.db = new MSSQLContext();
        }

        public CountryRepositoryMSSQL(string ConString)
        {
            this.db = new MSSQLContext(ConString);
        }
        public Countries GetCountryByName(string name)
        {
            try
            {
                var res = this.db.Countires.Where(c => c.Name == name);
                return res.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new GetCountryException();
            }
        }

        public List<Countries> GetAllCountires()
        {
            return this.db.Countires.ToList();
        }
    }
}
