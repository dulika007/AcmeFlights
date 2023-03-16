using API.Application.Commands;
using API.Application.ViewModels;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrdersController(
            ILogger<OrdersController> logger,
            IMediator mediator,
            IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            var order = await _mediator.Send(command);

            return Ok(order);
        }

        [HttpPut("{id:guid}/completed")]
        public async Task<IActionResult> UpdateOrder([FromRoute]Guid id)
        {
            try
            {
                var order = await _mediator.Send(new CompleteOrderCommand() { OrderId = id });

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }            
        }
    }
}
