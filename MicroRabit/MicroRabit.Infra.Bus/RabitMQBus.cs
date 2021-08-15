using MediatR;
using MicroRabit.Domain.Core.Bus;
using MicroRabit.Domain.Core.Commands;
using MicroRabit.Domain.Core.Events;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabit.Infra.Bus
{
    public sealed class RabitMQBus : IEventBus
    {
        private readonly IMediator _mediator;
        private readonly Dictionary<string, List<Type>> _handler;
        private readonly List<Type> _eventTypes;

        public RabitMQBus(IMediator mediator)
        {
            _mediator = mediator;
            _handler = new Dictionary<string, List<Type>>();
            _eventTypes = new List<Type>();
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }

        public void Puslish<T>(T @event) where T : Event
        {
            var factory = new ConnectionFactory() { HostName = "LocalHost" };
            using(var connection = factory.CreateConnection())
            using(var channel = connection.CreateModel())
            {
                var eventName = @event.GetType().Name;
                channel.QueueDeclare(eventName, false, false, false, null);
                var message = JsonConvert.SerializeObject(@event);
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish("", eventName, false, null, body);
            }
        }

        

        public void Subscribe<T, TH>()
            where T : Event
            where TH : IEventHandler<T>
        {
            string eventName = typeof(T).Name;
            var handlerType = typeof(TH);

            if(!_eventTypes.Contains(typeof(T)))
            {
                _eventTypes.Add(typeof(T));
            }

            if(!_handler.ContainsKey(eventName))
            {
                _handler.Add(eventName, new List<Type>());
            }

            if(_handler[eventName].Any(s=>s.GetType() == handlerType))
            {
                throw new ArgumentException($"This Handler {handlerType.Name} is already exit for '{eventName}'");
            }

            _handler[eventName].Add(handlerType);

            StartBasicConsume<T>();
        }

        private void StartBasicConsume<T>() where T: Event
        {
            var factory = new ConnectionFactory()
            {
                HostName = "LocalHost",
                DispatchConsumersAsync = true
            };

            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            string eventName = typeof(T).Name;
            channel.QueueDeclare(eventName, false, false, false, null);
            var consumer = new AsyncEventingBasicConsumer(channel);

            consumer.Received += Consumer_Received;
            channel.BasicConsume(eventName, true, consumer);


        }

        private async Task Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            string eventName = e.RoutingKey;
            string message = Encoding.UTF8.GetString(e.Body.ToArray());

            try
            {
                await ProcessEvent(eventName, message).ConfigureAwait(false);
            }

            catch(Exception ex)
            {
               
            }

        }

        private async Task ProcessEvent(string eventName, string message)
        {
            if(_handler.ContainsKey(eventName))
            {
                var subscriptions = _handler[eventName];
                foreach(var subscription in subscriptions)
                {
                    var  handler = Activator.CreateInstance(subscription);
                    if (handler == null) continue;
                    var sunscriptionType = _eventTypes.SingleOrDefault(s => s.Name == eventName);
                    var @event = JsonConvert.DeserializeObject(message, sunscriptionType);
                    var concreteType = typeof(IEventHandler<>).MakeGenericType(sunscriptionType);
                    await (Task) concreteType.GetMethod("Handle").Invoke(handler, new object[] { @event });
                }
            }
        }
    }
}
