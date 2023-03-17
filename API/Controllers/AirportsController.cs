using System.Threading.Tasks;
using API.Application.Commands;
using API.Application.ViewModels;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AirportsController : ControllerBase
    {
        private readonly ILogger<AirportsController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AirportsController(
            ILogger<AirportsController> logger,
            IMediator mediator,
            IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }
        
        /// <summary>
        /// Create airport
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Store([FromBody]CreateAirportCommand command)
        {
            var airport = await _mediator.Send(command);

            return Ok(_mapper.Map<AirportViewModel>(airport));
            return StatusCode(StatusCodes.Status201Created, _mapper.Map<AirportViewModel>(airport));
        }
    }
}