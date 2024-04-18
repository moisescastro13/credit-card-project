using AutoMapper;
using CreditCardApi.Application.Dtos.CreditCard;
using CreditCardApi.Domain.Entities;
using CreditCardApi.Infrastructure.Interfaces;
using MediatR;

namespace CreditCardApi.Application.Features.CreditCards.Commands;

public record CreateCreditCardCommand(CreateCreditCardDto CreditCardDto) : IRequest<Unit>;

public class CreateCreditCardCommandHandler : IRequestHandler<CreateCreditCardCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;


    public CreateCreditCardCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CreateCreditCardCommand request, CancellationToken cancellationToken)
    {
        CreditCard creditCard = _mapper.Map<CreateCreditCardDto, CreditCard>(request.CreditCardDto);

        try
        {
            _unitOfWork.CreateTransaction();
            await _unitOfWork.CreditCardRepository.Add(creditCard);

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