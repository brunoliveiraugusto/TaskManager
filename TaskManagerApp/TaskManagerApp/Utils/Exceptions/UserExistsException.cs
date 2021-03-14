using System;

namespace TaskManagerApp.Utils.Exceptions
{
    public class UserExistsException : Exception
    {
        public UserExistsException() : base("O usuário informado já está cadastrado")
        {

        }
    }
}
