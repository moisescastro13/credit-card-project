
using AutoMapper;
using CreditCardApi.Application.Dtos.CreditCard;
using CreditCardApi.Domain.Entities;
using CreditCardApi.Domain.Exceptions;
using CreditCardApi.Infrastructure.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CreditCardApi.Application.Features.CreditCards.Commands;
public record UpdateCreditCardCommand(UpdateCreditCardDto UpdateCreditCardDto) : IRequest;


public class updateCreditCardInformationQueryHandler : IRequestHandler<UpdateCreditCardCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public updateCreditCardInformationQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task Handle(UpdateCreditCardCommand request, CancellationToken cancellationToken)
    {
        CreditCardDetails? creditCard = await _unitOfWork.CreditCardDetailsRepository.GetByCreditCardId(new CreditCardID(request.UpdateCreditCardDto.CreditCardId));

        if (creditCard is null)
        {
            throw new NotFoundExeption("credit card does not exist", StatusCodes.Status404NotFound);
        }


        _mapper.Map(request.UpdateCreditCardDto, creditCard);
        await _unitOfWork.CreditCardDetailsRepository.Update(creditCard);
        await _unitOfWork.SaveChangesAsync();
    }
}