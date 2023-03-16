using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.CustomerAggregate;
using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate.Enums;
using Domain.Common;
using Domain.Events;
using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        public virtual Customer Customer { get; set; }
        public Guid CustomerId { get; set; }
        public virtual Flight Flight { get; set; }
        public Guid FlightId { get; set; }
        public virtual Airport Airport { get; set; }
        public Guid AirportId { get; set; }
        public virtual FlightRate FlightRate { get; set; }
        public Guid FlightRateId { get; set; }
        public Status Status { get; set; }

        public void ConfirmOrder()
        {
            AddDomainEvent(new OrderConfirmEvent(this));
        }
    }
}
