using System;
using System.Collections.Generic;
using System.Text;

namespace TurHelper6.DataAccess.Exceptions
{
    public class CityException : Exception
    {
        public CityException() : base() { }
    }
    public class GetCityException : CityException { }
}
