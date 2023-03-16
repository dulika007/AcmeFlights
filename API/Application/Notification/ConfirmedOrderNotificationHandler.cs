using Domain.Events;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Notification
{
    public class ConfirmedOrderNotificationHandler : INotificationHandler<OrderConfirmEvent>
    {
        public Task Handle(OrderConfirmEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("Dear" + notification.Order.Customer.Name + " your " + notification.Order.Id + " order has been confirmed");
            return Task.CompletedTask;
        }
    }
}
