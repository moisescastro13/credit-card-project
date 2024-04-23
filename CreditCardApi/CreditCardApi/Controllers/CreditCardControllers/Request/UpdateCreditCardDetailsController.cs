using CreditCardApi.Application.Dtos.CreditCard;
using CreditCardApi.Application.Features.CreditCards.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CreditCardApi.Controllers.CreditCardControllers.Request
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateCreditCardDetailsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public UpdateCreditCardDetailsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPatch]
        public async Task Run([FromBody] UpdateCreditCardDto dto)
        {
            var command = new UpdateCreditCardCommand(dto);
            await _mediator.Send(command);
        }
    }
}
