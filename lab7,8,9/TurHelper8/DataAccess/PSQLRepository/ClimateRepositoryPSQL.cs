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
            try
            {
                using (PSQLContext dbcon = new PSQLContext())
                {
                    var Clim = dbcon.Climate.Find(cl.Id);
                    Clim.TurMonth = cl.TurMonth;
                    Clim.Temp = cl.Temp;
                    Clim.TempNight = cl.TempNight;
                    Clim.TempWater = cl.TempWater;
                    dbcon.Entry(Clim).State = EntityState.Modified;
                    dbcon.SaveChanges();
                }
                /*var Clim = this.db.Climate.Find(cl.Id);
                Clim.TurMonth = cl.TurMonth;
                Clim.Temp = cl.Temp;
                Clim.TempNight = cl.TempNight;
                Clim.TempWater = cl.TempWater;
                db.Entry(Clim).State = EntityState.Modified;
                this.db.SaveChanges();*/
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
                using (PSQLContext dbcon = new PSQLContext())
                {
                    var res = dbcon.Climate.Where(cl => cl.Id == Id);
                    return res.FirstOrDefault();
                }
                
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
                using (PSQLContext dbcon = new PSQLContext())
                {
                    var res = dbcon.Climate.Where(cl => cl.IdCountry == IdCountry);
                    return res.FirstOrDefault();
                }
                
            }
            catch (Exception ex)
            {
                throw new GetClimatException();
            }
        }
    }
}
