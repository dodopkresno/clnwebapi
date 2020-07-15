using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Web.Features.Events;
using Microsoft.Extensions.Logging;
using System.Threading;

namespace Web.Features.Subcribers
{
    public class PostedRaportHandler : INotificationHandler<PostedRaportEvent>
    {
        private readonly ILogger _logger;
        public PostedRaportHandler(ILogger<PostedRaportEvent> logger)
        {
            _logger = logger;
        }
        public async Task Handle(PostedRaportEvent notification, CancellationToken cancellationToken)
        {
            if (notification._status == true)
            {
                _logger.LogInformation($"{notification._message} get data raport from:{notification._startDate} to {notification._endDate}, start data no:{notification._startNo} to {notification._endNo}");
            }
            else 
            {
                _logger.LogWarning("Failed to post raport from API Source");
            }
        }
    }
}
