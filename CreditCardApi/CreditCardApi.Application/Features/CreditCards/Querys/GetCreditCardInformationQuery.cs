using AutoMapper;
using CreditCardApi.Application.Dtos.CreditCard;
using CreditCardApi.Domain.Entities;
using CreditCardApi.Infrastructure.Interfaces;
using MediatR;

namespace CreditCardApi.Application.Features.CreditCards.Querys;

public record GetCreditCardInformationQuery : IRequest<ReadCreditCardInformation>
{
    public CreditCardID creditCardID;

    public GetCreditCardInformationQuery(CreditCardID creditCardID)
    {
        this.creditCardID = creditCardID;
    }
}

public class GetCreditCardInformationQueryHandler : IRequestHandler<GetCreditCardInformationQuery, ReadCreditCardInformation>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public GetCreditCardInformationQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ReadCreditCardInformation> Handle(GetCreditCardInformationQuery request, CancellationToken cancellationToken)
    {
        CreditCard? creditCard = await _unitOfWork.CreditCardRepository.GetOneWithInformation(request.creditCardID);

        if (creditCard is null)
        {
            return null;
        }

        return _mapper.Map<ReadCreditCardInformation>(creditCard);
    }
}
