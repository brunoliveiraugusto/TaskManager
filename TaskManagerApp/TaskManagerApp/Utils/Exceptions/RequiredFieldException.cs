using System;

namespace TaskManagerApp.Utils.Exceptions
{
    public class RequiredFieldException : Exception
    {
        public RequiredFieldException(string message) : base(message)
        {

        }
    }
}
