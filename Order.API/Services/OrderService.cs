using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Order.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IBusControl _bus;
        private readonly ILogger<OrderService> _logger;

        public OrderService(IBusControl bus, ILogger<OrderService> logger)
        {
            _bus = bus;
            _logger = logger;
        }

        /// <summary>
        /// Async Method that sends order object message to the bus
        /// </summary>
        /// <param name="order">Order object</param>
        public async Task SendMessageAsync(Domain.Models.Order order)
        {
            var uri = new Uri("rabbitmq://localhost/order_queue");

            var endpoint = await _bus.GetSendEndpoint(uri);
            await endpoint.Send(order);

            _logger.LogDebug("Message sent");
        }
    }
}
