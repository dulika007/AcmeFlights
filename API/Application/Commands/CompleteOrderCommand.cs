using MediatR;
using System;

namespace API.Application.Commands
{
    public class CompleteOrderCommand : IRequest
    {
        public Guid OrderId { get; set; }
    }
}
