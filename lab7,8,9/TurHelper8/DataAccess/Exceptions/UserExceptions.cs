using System;
using System.Collections.Generic;
using System.Text;

using TurHelper6;

namespace TurHelper6.DataAccess.Exceptions
{
    public class UserException : Exception
    {
        public UserException() : base() { }
        public UserException(string message) : base(message) { }

    }
    public class UpdateUserException : UserException
    {
 
    }
    public class DeleteUserException : UserException { }
    public class InsertUserException : UserException { }
    public class GetUserException : UserException { }
    public class UseridException : UserException { }

    public class UserconvertException : UserException { }
}
