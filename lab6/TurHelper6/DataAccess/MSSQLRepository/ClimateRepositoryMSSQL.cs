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
    public class ClimateRepositoryMSSQL : ClimateRepositoryInterface
    {
        private MSSQLContext db;

        public ClimateRepositoryMSSQL()
        {
            this.db = new MSSQLContext();
        }

        public ClimateRepositoryMSSQL(string ConString)
        {
            this.db = new MSSQLContext(ConString);
        }
        public void UpdateClimate(Climate cl)
        {
            try
            {
                var Clim = this.db.Climate.Find(cl.Id);
                Clim.TurMonth = cl.TurMonth;
                Clim.Temp = cl.Temp;
                Clim.TempNight = cl.TempNight;
                Clim.TempWater = cl.TempWater;
                this.db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new UpdateClimatException();
            }
        }

        public Climate GetClimateById(int Id)
        {
            try
            {
                var res = this.db.Climate.Where(cl => cl.Id == Id);
                return res.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new GetClimatException();
            }
        }

        public Climate GetClimateByCountry(int IdCountry)
        {
            try
            {
                var res = this.db.Climate.Where(cl => cl.IdCountry == IdCountry);
                return res.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new GetClimatException();
            }
        }
    }
}
