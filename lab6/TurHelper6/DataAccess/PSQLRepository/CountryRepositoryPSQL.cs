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
    public class CountryRepositoryPSQL : CountriesRepositoryInterface
    {
        private PSQLContext db;

        public CountryRepositoryPSQL()
        {
            this.db = new PSQLContext();
        }

        public CountryRepositoryPSQL(string ConString)
        {
            this.db = new PSQLContext(ConString);
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
