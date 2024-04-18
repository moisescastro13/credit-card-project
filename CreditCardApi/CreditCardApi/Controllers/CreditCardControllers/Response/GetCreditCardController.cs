using CreditCardApi.Application.Features.CreditCards.Querys;
using CreditCardApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CreditCardApi.Controllers.CreditCardControllers.Response
{
    [Route("api/CreditCard")]
    [ApiController]
    public class GetCreditCardController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetCreditCardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{cardID}")]
        public async Task<IActionResult> GetCreditCardInformation(string cardID)
        {
            var query = new GetCreditCardInformationQuery(new CreditCardID(Guid.Parse(cardID)));
            
            return Ok(await _mediator.Send(query));
        }
    }
}
