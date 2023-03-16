using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.CustomerAggregate
{
    public class Customer : Entity, IAggregateRoot
    {
        public string Name { get; set; }
    }
}
