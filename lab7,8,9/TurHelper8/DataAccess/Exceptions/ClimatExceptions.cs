using System;
using System.Collections.Generic;
using System.Text;

namespace TurHelper6.DataAccess.Exceptions
{
    public class ClimatException : Exception
    {
        public ClimatException() : base() { }
    }
    public class UpdateClimatException : ClimatException { }
    public class GetClimatException : ClimatException { }
}
