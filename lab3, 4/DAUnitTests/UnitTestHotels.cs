using System;
using Xunit;
using System.Linq;
using TurHelper;

using TurHelper.DataAccesss.PSQLRepository;
using TurHelper.DataAccesss.EntityStructures;
using TurHelper.DataAccesss;

namespace DAUnitTests
{
    public class UnitTestHotels
    {
        HotelRepositoryPSQL hotel_rep = new HotelRepositoryPSQL();
        private void CheckEqual(Hotels h1, Hotels h2)
        {
            Assert.Equal(h1.Name, h2.Name);
            Assert.Equal(h1.Beach, h2.Beach);
            Assert.Equal(h1.AllInc, h2.AllInc);
            Assert.Equal(h1.Stars, h2.Stars);
        }

        [Fact]
        public void TestInsertHotel()
        {
            Hotels hotel = new Hotels();
            hotel.Id = hotel_rep.GetNewId();
            hotel.IdCountry = 0;
            hotel.Name = "Lame";
            hotel.Stars = 4;
            hotel.Beach = true;
            hotel.AllInc = true;

            hotel_rep.InsertHotel(hotel);
            using (PSQLContext db = new PSQLContext())
            {
                var h = db.Hotels.Find(hotel.Id);
                CheckEqual(hotel, h);
            }
        }

        [Theory]
        [InlineData("Sol Costa Daurada")]
        public void TestGetHotelByName(string name)
        {
            Hotels hotel = hotel_rep.GetHotelByName(name);
            using (PSQLContext db = new PSQLContext())
            {
                var h = db.Hotels.Find(hotel.Id);
                CheckEqual(hotel, h);
            }
        }

        [Fact]
        public void TestUpdateHotel()
        {
            Hotels hotel = new Hotels();
            hotel.Id = 0;
            hotel.IdCountry = 1;
            hotel.Name = "Rixos Bab Al";
            hotel.Stars = 5;
            hotel.Beach = true;
            hotel.AllInc = true;

            hotel_rep.UpdateHotel(hotel);
            using (PSQLContext db = new PSQLContext())
            {
                var h = db.Hotels.Find(hotel.Id);
                CheckEqual(hotel, h);
            }
        }

        [Fact]
        public void TestDeleteHotel()
        {
            using (PSQLContext db = new PSQLContext())
            {
                //как лучше? - 1
                int Id = hotel_rep.GetNewId() - 1;
                hotel_rep.DeleteHotel(Id);

                if (db.Hotels.Find(Id) != null)
                    throw new Exception("Delete_hotel problem");
            }
        }
    }
}
