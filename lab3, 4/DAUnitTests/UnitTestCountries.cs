using System;
using Xunit;
using System.Linq;
using TurHelper;

using TurHelper.DataAccesss.PSQLRepository;
using TurHelper.DataAccesss.EntityStructures;
using TurHelper.DataAccesss;

namespace DAUnitTests
{
    public class UnitTestCountries
    {
        CountryRepositoryPSQL country_rep = new CountryRepositoryPSQL();
        private void CheckEqual(Countries c1, Countries c2)
        {
            Assert.Equal(c1.Name, c2.Name);
            Assert.Equal(c1.Continent, c2.Continent);
            Assert.Equal(c1.Capital, c2.Capital);
        }

        [Theory]
        [InlineData("Греция")]
        public void TestGetCountryByName(string name)
        {
            Countries cntr = country_rep.GetCountryByName(name);

            using (PSQLContext db = new PSQLContext())
            {
                var c = db.Countires.Find(cntr.Id);
                CheckEqual(cntr, c);
            }
        }
    }
}
