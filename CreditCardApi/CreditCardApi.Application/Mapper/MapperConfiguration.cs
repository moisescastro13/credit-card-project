using AutoMapper;
using CreditCardApi.Application.Dtos.CreditCard;
using CreditCardApi.Domain.Entities;

namespace CreditCardApi.Application.Mapper;

public class MapperConfiguration: Profile
{
    public MapperConfiguration()
    {
        CreateMap<CreateCreditCardDto, CreditCard>();
        //.ForMember(dest => dest.Id, opt => opt.MapFrom(x => new CreditCardID(0)));

        CreateMap<CreateCreditCardDetailsDto, CreditCardDetails>();
            //.ForMember(dest => dest.Id, opt => opt.MapFrom(x => new CreditCardDetailsID(0)));

        //CreateMap<User, ReadUserDto>().ForMember(x => x.Id, x => x.MapFrom(y => y.Id.value));
    }
}
