using System;
using Xunit;
using System.Linq;
using TurHelper;

using TurHelper.DataAccesss.PSQLRepository;
using TurHelper.DataAccesss.EntityStructures;
using TurHelper.DataAccesss;

namespace DAUnitTests
{
    public class UnitTestClimate
    {
        ClimateRepositoryPSQL clim_rep = new ClimateRepositoryPSQL();
        private void CheckEqual(Climate cl1, Climate cl2)
        {
            Assert.Equal(cl1.IdCountry, cl2.IdCountry);
            Assert.Equal(cl1.Temp, cl2.Temp);
            Assert.Equal(cl1.TempWater, cl2.TempWater);
            Assert.Equal(cl1.TempNight, cl2.TempNight);
            Assert.Equal(cl1.TurMonth, cl2.TurMonth);
        }

        [Theory]
        [InlineData(1)]
        public void TestGetClimateById(int Id)
        {
            Climate clim = clim_rep.GetClimateById(Id);

            using (PSQLContext db = new PSQLContext())
            {
                var cl = db.Climate.Find(clim.Id);
                CheckEqual(clim, cl);
            }
        }

        [Theory]
        [InlineData(1)]
        public void TestGetClimateByCountry(int IdCountry)
        {
            Climate clim = clim_rep.GetClimateByCountry(IdCountry);

            using (PSQLContext db = new PSQLContext())
            {
                var cl = db.Climate.Find(clim.Id);
                CheckEqual(clim, cl);
            }
        }

    }
}
