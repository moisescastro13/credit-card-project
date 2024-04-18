using CreditCardApi.Application.Dtos.Transaction;
using CreditCardApi.Application.shared;
using CreditCardApi.Domain.Entities;
using CreditCardApi.Infrastructure.Interfaces;
using MediatR;
using System.Data;

namespace CreditCardApi.Application.Features.Transactions.Commands;

public record CreateTransactionCommand(CreateTransactionDto createTransactionDto) : IRequest<Unit>;

public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateTransactionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            _unitOfWork.CreateTransaction();

            CreditCard? exist = await _unitOfWork.CreditCardRepository.GetById(new CreditCardID(request.createTransactionDto.CreditCardID));

            if (exist is null)
            {
                return Unit.Value;
            }

            DataTable dt = new DataTable();
            dt = dt.PrepareDTtoInsertTransaction(request.createTransactionDto);

            await _unitOfWork.TransactionRepository.Add(dt);

            await _unitOfWork.SaveChangesAsync();

            await _unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
            _unitOfWork.Rollback();
        }

        return Unit.Value;
    }
}
