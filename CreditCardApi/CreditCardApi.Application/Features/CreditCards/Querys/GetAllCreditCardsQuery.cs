using AutoMapper;
using CreditCardApi.Application.Dtos.CreditCard;
using CreditCardApi.Infrastructure.Interfaces;
using MediatR;

namespace CreditCardApi.Application.Features.CreditCards.Querys
{
    public record GetAllCreditCardsQuery() : IRequest<IEnumerable<ReadCreditCard>>;


    public class GetCreditCardsQueryHandler : IRequestHandler<GetAllCreditCardsQuery, IEnumerable<ReadCreditCard>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public GetCreditCardsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<ReadCreditCard>> Handle(
            GetAllCreditCardsQuery request,
            CancellationToken cancellationToken)
        {
            var creditCards = await _unitOfWork.CreditCardRepository.GetAll();

            return _mapper.Map<List<ReadCreditCard>>(creditCards);
        }
    }
}