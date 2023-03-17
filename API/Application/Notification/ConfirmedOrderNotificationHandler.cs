using Domain.Events;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Notification
{
    public class ConfirmedOrderNotificationHandler : INotificationHandler<OrderConfirmEvent>
    {
        /// <summary>
        /// Order confirmation notification handler
        /// </summary>
        /// <param name="notification"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task Handle(OrderConfirmEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("Dear" + notification.Order.Customer.Name + " your " + notification.Order.Id + " order has been confirmed");
            return Task.CompletedTask;
        }
    }
}
