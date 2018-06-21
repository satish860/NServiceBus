using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UserRegisteration.DomainHost
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "User Registeration";
            var endPointConfiguration = new EndpointConfiguration("DomainHost");
            var transport = endPointConfiguration.UseTransport<MsmqTransport>();
            endPointConfiguration.UsePersistence<InMemoryPersistence>();
            endPointConfiguration.SendFailedMessagesTo("error");
            endPointConfiguration.EnableInstallers();
            var endpoint = await Endpoint.Start(endPointConfiguration).ConfigureAwait(false);
            Console.WriteLine("Enter a Key to Exit");
            Console.ReadKey();
            await endpoint.Stop().ConfigureAwait(false);
        }
    }
}
