using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using Order.Email.Communication;

namespace Order.Email.Consumers
{
    public class OrderConsumer : IConsumer<Domain.Models.Order>
    {
        private readonly ILogger<OrderConsumer> _logger;
        private readonly IEmailSender _emailSender;

        public OrderConsumer(ILogger<OrderConsumer> logger, IEmailSender emailSender)
        {
            _logger = logger;
            _emailSender = emailSender;
        }
        public async Task Consume(ConsumeContext<Domain.Models.Order> context)
        {
            var data = context.Message;
            _logger.LogDebug(data.ProductName);

            await _emailSender.SendOrderConfirmationEmailAsync(data);

        }
    }
}
