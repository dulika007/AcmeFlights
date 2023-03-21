using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.CustomerAggregate;
using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityConfigurations
{
    public  class OrderRateEntityTypeConfiguration : BaseEntityTypeConfiguration<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);

            builder.Property<Guid>("CustomerId").IsRequired();

            builder.Property<Guid>("FlightId").IsRequired();
            builder.Property<Guid>("AirportId").IsRequired();

            builder.HasOne<Customer>(i => i.Customer).WithMany().HasForeignKey(i => i.CustomerId);
            builder.HasOne<Flight>(i => i.Flight).WithMany().HasForeignKey(i => i.FlightId);
        }
    }
}
