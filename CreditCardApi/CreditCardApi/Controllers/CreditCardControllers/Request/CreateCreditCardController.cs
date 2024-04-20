using CreditCardApi.Application.Dtos.CreditCard;
using CreditCardApi.Application.Features.CreditCards.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CreditCardApi.Controllers.CreditCardControllers.Request
{
    [Route("api/CreditCard")]
    [ApiController]
    public class CreateCreditCardController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreateCreditCardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task Run([FromBody] CreateCreditCardDto CreditCardDto)
        {
            var command = new CreateCreditCardCommand(CreditCardDto);
            await _mediator.Send(command);
        }
    }
}
