using AutoMapper;
using System;
using Wallet.API.Mappings.Configurations;
using Wallet.Dtos;
using Wallet.Model;

namespace Wallet.API.Mappings
{

    public class MappingConfiguration : Profile
    {

        public MappingConfiguration()
        {
            CreateMap<UserWallet, UserWalletDto>().
                ForMember(dest => dest.Balance, opt => opt.MapFrom<WalletBalanceResolver>())
                .ReverseMap();

            CreateMap<UserWallet, UserWalletUpdateDto>().ReverseMap();

            CreateMap<UserBank, UserBankDto>().ReverseMap();
            CreateMap<UserTransaction, UserTransactionDto>();
            CreateMap<Bank, BankModelDto>().ReverseMap();

        }
    }
}
