using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using TurHelper.DataAccesss.EntityStructures;

namespace TurHelper.DataAccesss.PSQLRepository
{
    public class ClimateRepositoryPSQL : ClimateRepositoryInterface
    {
        private PSQLContext db;

        public ClimateRepositoryPSQL()
        {
            this.db = new PSQLContext();
        }

        public ClimateRepositoryPSQL(string ConString)
        {
            this.db = new PSQLContext(ConString);
        }

        public void UpdateClimate(Climate cl)
        {
            var Clim = this.db.Climate.Find(cl.Id);
            Clim.TurMonth = cl.TurMonth;
            Clim.Temp = cl.Temp;
            Clim.TempNight = cl.TempNight;
            Clim.TempWater = cl.TempWater;
            this.db.SaveChanges();
        }

        public Climate GetClimateById(int Id)
        {
            var res = this.db.Climate.Where(cl => cl.Id == Id);
            return res.FirstOrDefault();
        }

        public Climate GetClimateByCountry(int IdCountry)
        {
            var res = this.db.Climate.Where(cl => cl.IdCountry == IdCountry);
            return res.FirstOrDefault();
        }
    }
}
