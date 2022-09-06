using System;
using Xunit;
using System.Linq;
using TurHelper;

using TurHelper.DataAccesss.PSQLRepository;
using TurHelper.DataAccesss.EntityStructures;
using TurHelper.DataAccesss;
namespace DAUnitTests
{
    public class UnitTestRooms
    {
        RoomRepositoryPSQL room_rep = new RoomRepositoryPSQL();
        private void CheckEqual(Rooms r1, Rooms r2)
        {
            Assert.Equal(r1.Name, r2.Name);
            Assert.Equal(r1.Capacity, r2.Capacity);
            Assert.Equal(r1.Floor, r2.Floor);
            Assert.Equal(r1.Price, r2.Price);
        }

        [Fact]
        public void TestInsertRoom()
        {
            Rooms room = new Rooms();
            room.Id = room_rep.GetNewId();
            room.IdHotel = 0;
            room.Name = "Double room";
            room.Capacity = 2;
            room.Price = 3000;
            room.Floor = 2;

            room_rep.InsertRoom(room);
            using (PSQLContext db = new PSQLContext())
            {
                var r = db.Rooms.Find(room.Id);
                CheckEqual(room, r);
            }
        }

        [Fact]
        public void TestUpdateRoom()
        {
            Rooms room = new Rooms();
            room.Id = 0;
            room.IdHotel = 0;
            room.Name = "Standart Room";
            room.Capacity = 2;
            room.Price = 3500;
            room.Floor = 3;

            room_rep.UpdateRoom(room);
            using (PSQLContext db = new PSQLContext())
            {
                var r = db.Rooms.Find(room.Id);
                CheckEqual(room, r);
            }
        }

        [Fact]
        public void TestDeleteRoom()
        {
            using (PSQLContext db = new PSQLContext())
            {
                //как лучше? - 1
                int Id = room_rep.GetNewId() - 1;
                room_rep.DeleteRoom(Id);

                if (db.Hotels.Find(Id) != null)
                    throw new Exception("Delete_room problem");
            }
        }

    }
}
