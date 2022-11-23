using System;

namespace Wallet.Dtos
{
    public class UserWalletDto
    {
        public int Id { get; set; }
        public int? BankId { get; set; }
        public string UserId { get; set; }
        public double Balance { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; } 
        public string Currency { get; set; }
        public bool Status { get; set; }

    }
}
