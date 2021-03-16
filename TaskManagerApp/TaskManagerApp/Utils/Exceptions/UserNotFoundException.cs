using System;

namespace TaskManagerApp.Utils.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base("Usuário ou senha inválido.")
        {

        }
    }
}
