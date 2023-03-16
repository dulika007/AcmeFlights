using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.CustomerAggregate;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Infrastructure.Seeds
{
    public class CustomerSeeder : FlightsContextSeeder
    {
        public CustomerSeeder(FlightsContext flightsContext) : base(flightsContext)
        {
        }

        public override void Seed()
        {
            if (FlightsContext.Customers.Any())
            {
                Console.WriteLine("Skipping Customers seeder because table is not empty.");
                return;
            }

            var customers = new List<Customer>()
            {
                new Customer() { Name = "John Doe" },
                new Customer() { Name = "Sam Brew" },
            };

            FlightsContext.Customers.AddRange(customers);
            FlightsContext.SaveChanges();
        }
    }
}
