using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserServiceRegisteration.Messages
{
    public class RegisterUser : ICommand
    {
        public string EmailId { get; set; }

        public string Password { get; set; }
    }
}
