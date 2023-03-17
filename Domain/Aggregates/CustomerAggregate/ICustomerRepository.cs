using Domain.Aggregates.AirportAggregate;
using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.CustomerAggregate
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer Add(Customer customer);

        void Update(Customer customer);

        Task<Customer> GetByIdAsync(Guid customerId);
    }
}
