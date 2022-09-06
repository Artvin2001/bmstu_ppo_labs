using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using TurHelper.DataAccesss.EntityStructures;

namespace TurHelper.DataAccesss.PSQLRepository
{
    public class RoomRepositoryPSQL : RoomsRepositoryInterface
    {
        private PSQLContext db;

        public RoomRepositoryPSQL()
        {
            this.db = new PSQLContext();
        }

        public RoomRepositoryPSQL(string ConString)
        {
            this.db = new PSQLContext(ConString);
        }

        public List<Rooms> GetAllRooms(int IdHotel)
        {
            return this.db.Rooms.Where(r => r.IdHotel == IdHotel).ToList();
        }

        public Rooms GetRoomByName(string name, int IdHotel)
        {
            var res = this.db.Rooms.Where(r => r.Name == name && r.IdHotel == IdHotel);
            return res.FirstOrDefault();
        }

        public void InsertRoom(Rooms r)
        {
            this.db.Rooms.Add(r);
            this.db.SaveChanges();
        }

        public void DeleteRoom(int Id)
        {
            var r = this.db.Rooms.Find(Id);
            this.db.Remove(r);
            this.db.SaveChanges();
        }

        public void UpdateRoom(Rooms r)
        {
            var room = this.db.Rooms.Find(r.Id);
            room.Name = r.Name;
            room.Price = r.Price;
            room.Floor = r.Floor;
            room.Capacity = r.Capacity;
            this.db.SaveChanges();
        }

        public int GetNewId()
        {
            try
            {
                return this.db.Rooms.Max(a => a.Id) + 1;
            }
            catch (Exception ex)
            {
                return 1;
            }
        }
    }
}
