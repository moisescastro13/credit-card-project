using CreditCardApi.Application.Dtos.Transaction;
using CreditCardApi.Application.shared;
using CreditCardApi.Domain.Entities;
using CreditCardApi.Domain.Exceptions;
using CreditCardApi.Infrastructure.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Data;

namespace CreditCardApi.Application.Features.Transactions.Commands;

public record CreateTransactionCommand(CreateTransactionDto createTransactionDto) : IRequest;

public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateTransactionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {
        CreditCard? creditCard = await _unitOfWork.CreditCardRepository.GetById(new CreditCardID(request.createTransactionDto.CreditCardID));

        if (creditCard is null)
        {
            throw new NotFoundExeption("credit card does not exist", StatusCodes.Status404NotFound);
        }

        if(!ValidMoneyTransaction(creditCard, request.createTransactionDto))
        {
            throw new NotEnoughMoneyException("", StatusCodes.Status400BadRequest);
        }

        try
        {
            _unitOfWork.CreateTransaction();

            DataTable dt = new DataTable();
            dt = dt.PrepareDTtoInsertTransaction(request.createTransactionDto);

            await _unitOfWork.TransactionRepository.Add(dt);

            await _unitOfWork.SaveChangesAsync();

            await _unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
            _unitOfWork.Rollback();

            throw new Exception("An error occurred while processing the transaction.", ex);
        }
    }

    private bool ValidMoneyTransaction(CreditCard creditCard, CreateTransactionDto transaction)
    {
        if (transaction.TransactionType == TransactionType.Collection) return true;

        var cuurentBalance = transaction.Amount + Math.Abs(creditCard.CreditCardDetails.Currentbalance);

        if (cuurentBalance > creditCard.CreditCardDetails.balance){
            return false;
        }

        return true;
    }
}
