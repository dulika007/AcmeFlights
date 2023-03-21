using API.Application.Commands;
using API.Application.ViewModels;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
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

        /// <summary>
        /// Create order for book a flight
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Returns Status code and OrderViewModel</returns>
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            try
            {
                var order = await _mediator.Send(command);

                return StatusCode(StatusCodes.Status201Created, order);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }            
        }

        /// <summary>
        /// Update order of the customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns Status</returns>
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
