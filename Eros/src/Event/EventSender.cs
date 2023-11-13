using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Eros.src.Event
{
    public class EventSender
    {
        private readonly IConfiguration _configuration;

        public EventSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEventAsync(string topicName, string message, string eventType)
        {
            var connectionString = _configuration.GetSection("ServiceBusSettings:ConnectionString").Value;
            await using var client = new ServiceBusClient(connectionString);
            var sender = client.CreateSender(topicName);
            var serviceBusMessage = new ServiceBusMessage(message);
            serviceBusMessage.ApplicationProperties.Add("EventType", eventType);
            await sender.SendMessageAsync(serviceBusMessage);
        }
    }
}
