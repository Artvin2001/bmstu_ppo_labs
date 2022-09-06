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
    public class RoomRepositoryMSSQL : RoomsRepositoryInterface
    {
        private MSSQLContext db;

        public RoomRepositoryMSSQL()
        {
            this.db = new MSSQLContext();
        }

        public RoomRepositoryMSSQL(string ConString)
        {
            this.db = new MSSQLContext(ConString);
        }
        public List<Rooms> GetAllRooms(int IdHotel)
        {
            return this.db.Rooms.Where(r => r.IdHotel == IdHotel).ToList();
        }

        public Rooms GetRoomByName(string name, int IdHotel)
        {
            try
            {
                var res = this.db.Rooms.Where(r => r.Name == name && r.IdHotel == IdHotel);
                return res.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new GetRoomException();
            }
        }

        public void InsertRoom(Rooms r)
        {
            try
            {
                this.db.Rooms.Add(r);
                this.db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new InsertHotelException();
            }
        }

        public void DeleteRoom(int Id)
        {
            try
            {
                var r = this.db.Rooms.Find(Id);
                this.db.Remove(r);
                this.db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new DeleteRoomException();
            }
        }

        public void UpdateRoom(Rooms r)
        {
            try
            {
                var room = this.db.Rooms.Find(r.Id);
                room.Name = r.Name;
                room.Price = r.Price;
                room.Floor = r.Floor;
                room.Capacity = r.Capacity;
                this.db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new UpdateRoomException();
            }
        }

        public int GetNewId()
        {
            try
            {
                return this.db.Rooms.Max(a => a.Id) + 1;
            }
            catch (Exception ex)
            {
                throw new GetRoomIdException();
            }
        }
    }
}
