using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserServiceRegisteration.Messages;

namespace UserRegisteration.DomainHost
{
    public class UserRegisterationHandler : IHandleMessages<RegisterUser>
    {
        private ILog log = LogManager.GetLogger<ILog>();
        public Task Handle(RegisterUser message, IMessageHandlerContext context)
        {
            log.Info($"User {message.EmailId} has been registered");
            return Task.CompletedTask;
        }
    }
}
