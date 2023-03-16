using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public class OrderConfirmEvent : INotification
    {
        public Order Order { get; private set; }

        public OrderConfirmEvent(Order order)
        {
            Order = order;
        }
    }
}
