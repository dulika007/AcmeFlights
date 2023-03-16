using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositores
{
    public  class OrderRepository : IOrderRepository
    {
        private readonly FlightsContext _context;

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public OrderRepository(FlightsContext context)
        {
            _context = context;
        }

        public Order Add(Order order)
        {
            return _context.Orders.Add(order).Entity;
        }

        public async void Update(Order order)
        {
            _context.Orders.Update(order);
        }

        public async Task<Order> GetByIdAsync(Guid orderId)
        {
            return await _context.Orders.Include(i => i.Airport).Include(i => i.Flight).Include(i => i.Customer).Include(i => i.FlightRate).FirstOrDefaultAsync(o => o.Id == orderId);
        }
    }
}
