using System;
using System.Collections.Generic;
using System.Text;

namespace TurHelper6.DataAccess.Exceptions
{
    public class CountryException : Exception
    {
        public CountryException() : base() { }
    }
    public class GetCountryException : CountryException { }
}
