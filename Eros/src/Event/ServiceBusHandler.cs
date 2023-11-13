using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Options;

namespace Eros.src.Event
{
    public class ServiceBusHandler
    {
        private readonly ServiceBusProcessor _processor;
        private bool _isProcessingStarted = false;

        public ServiceBusHandler(IConfiguration configuration, string subscription)
        {
            var connectionString = configuration.GetSection("ServiceBusSettings:ConnectionString").Value;
            var topic = "eros";
            var client = new ServiceBusClient(connectionString);
            _processor = client.CreateProcessor(topic, subscription, new ServiceBusProcessorOptions());

            _processor.ProcessMessageAsync += MessageHandler;
            _processor.ProcessErrorAsync += ErrorHandler;

            Console.WriteLine($"Started processing messages for subscription: {subscription}");
        }

        public async Task StartProcessingAsync()
        {
            if (!_isProcessingStarted)
            {
                await _processor.StartProcessingAsync();
                _isProcessingStarted = true;
            }
        }

        public async Task StopProcessingAsync()
        {
            await _processor.StopProcessingAsync();
            _isProcessingStarted = false;
        }

        private async Task MessageHandler(ProcessMessageEventArgs args)
        {
            string body = args.Message.Body.ToString();
            Console.WriteLine($"Received: {body} from subscription.");
            await args.CompleteMessageAsync(args.Message);
        }

        private Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());
            return Task.CompletedTask;
        }

        public async Task DisposeAsync()
        {
            if (_isProcessingStarted)
            {
                await _processor.StopProcessingAsync();
            }
            await _processor.DisposeAsync();
        }
    }
}