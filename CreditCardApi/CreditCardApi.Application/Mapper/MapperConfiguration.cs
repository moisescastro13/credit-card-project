﻿using AutoMapper;
using CreditCardApi.Application.Dtos.CreditCard;
using CreditCardApi.Application.Dtos.Transaction;
using CreditCardApi.Domain.Entities;

namespace CreditCardApi.Application.Mapper;

public class MapperConfiguration: Profile
{
    public MapperConfiguration()
    {
        CreateMap<CreateCreditCardDto, CreditCard>();
        CreateMap<CreateCreditCardDetailsDto, CreditCardDetails>();
        CreateMap<CreditCardTransaction, ReadTransaction>();

        CreateMap<CreditCardDetails, ReadCreditCardDetails>()
            .ForMember(x => x.Id, x => x.MapFrom(z => z.Id.value));

        CreateMap<CreditCard, ReadCreditCardInformation>()
            .ForMember(x => x.Id, x => x.MapFrom(z => z.Id.value))
            .ForMember(x => x.Transactions, x => x.MapFrom(z => z.CreditCardTransactions));

    }
}
