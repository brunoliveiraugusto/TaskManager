using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagerApp.Domain
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
