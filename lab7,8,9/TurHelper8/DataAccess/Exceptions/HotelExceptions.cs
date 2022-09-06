using System;
using System.Collections.Generic;
using System.Text;

namespace TurHelper6.DataAccess.Exceptions
{
    public class HotelException : Exception
    {
        public HotelException() : base() { }
    }
    public class GetHotelException : HotelException { }
    public class UpdateHotelException : HotelException { }
    public class InsertHotelException : HotelException { }
    public class DeleteHotelException : HotelException { }
    public class GetHotelIdException : HotelException { }
}
