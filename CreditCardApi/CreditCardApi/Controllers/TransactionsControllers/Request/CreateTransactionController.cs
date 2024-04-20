using CreditCardApi.Application.Dtos.Transaction;
using CreditCardApi.Application.Features.Transactions.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CreditCardApi.Controllers.TransactionsControllers.Request
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateTransactionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreateTransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task Run([FromBody] CreateTransactionDto createTransactionDto)
        {
            var command = new CreateTransactionCommand(createTransactionDto);
            await _mediator.Send(command);

        }
    }
}
