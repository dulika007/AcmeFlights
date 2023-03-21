using API.Application.Commands;
using FluentValidation;

namespace API.Application.Validators
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(c => c.CustomerId).NotEmpty();
            RuleFor(c => c.FlightId).NotEmpty();
            RuleFor(c => c.FlightRateId).NotEmpty();
            RuleFor(c => c.Quantity).GreaterThan(0);
        }
    }
}
