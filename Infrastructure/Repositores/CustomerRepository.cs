using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.CustomerAggregate;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositores
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly FlightsContext _context;

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public CustomerRepository(FlightsContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public Customer Add(Customer customer)
        {
            return _context.Customers.Add(customer).Entity;
        }

        /// <summary>
        /// Update Customer
        /// </summary>
        /// <param name="customer"></param>
        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
        }

        /// <summary>
        /// Get by Customer Id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<Customer> GetByIdAsync(Guid customerId)
        {
            return await _context.Customers.FirstOrDefaultAsync(o => o.Id == customerId);
        }
    }
}
