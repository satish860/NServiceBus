using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using NServiceBus;
using UserServiceRegisteration.Messages;

namespace UserRegisterationService
{
    public static class ServiceBus
    {
        public static IEndpointInstance Bus { get; private set; }
       
        public static void Init()
        {

            if (Bus != null)
                return;
            var endPointConfiguration = new EndpointConfiguration("WebHost");
            var transport = endPointConfiguration.UseTransport<MsmqTransport>();
            var routing = transport.Routing();
            routing.RouteToEndpoint(typeof(RegisterUser), "DomainHost");
            endPointConfiguration.UsePersistence<InMemoryPersistence>();
            endPointConfiguration.SendFailedMessagesTo("error");
            endPointConfiguration.EnableInstallers();
            Bus = Endpoint.Start(endPointConfiguration).GetAwaiter().GetResult();
        }

        public static void End()
        {
            Bus.Stop().RunSynchronously();
        }
    }
}