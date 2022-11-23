using AutoMapper;
using Wallet.Dtos;
using Wallet.Model;

namespace Wallet.API.Mappings.Configurations
{
    public class WalletBalanceResolver : IValueResolver<UserWallet, UserWalletDto, double>
    {
        public double Resolve(UserWallet source, UserWalletDto destination, double destMember, ResolutionContext context)
        {
            return source.Balance / 100;
        }
    }
}
