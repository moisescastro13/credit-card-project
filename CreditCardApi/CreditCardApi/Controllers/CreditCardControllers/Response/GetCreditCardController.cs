using CreditCardApi.Application.Dtos.CreditCard;
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
        public async Task<ReadCreditCardInformation?> GetCreditCardInformation(string cardID)
        {
            var query = new GetCreditCardInformationQuery(new CreditCardID(Guid.Parse(cardID)));
            
            return await _mediator.Send(query);
        }
        [HttpGet]
        public async Task<IEnumerable<ReadCreditCard>?> GetCreditCards() => 
            await _mediator.Send(new GetAllCreditCardsQuery());
        
    }
}
