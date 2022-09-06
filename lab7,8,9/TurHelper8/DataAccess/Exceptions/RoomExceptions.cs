using System;
using System.Collections.Generic;
using System.Text;

namespace TurHelper6.DataAccess.Exceptions
{
    public class RoomException : Exception
    {
        public RoomException() : base() { }
    }
    public class GetRoomException : RoomException { }
    public class UpdateRoomException : RoomException { }
    public class InsertRoomException : RoomException { }
    public class DeleteRoomException : RoomException { }
    public class GetRoomIdException : RoomException { }
}
