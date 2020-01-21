using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMvc3_Foundation.Services
{
    public class FubonBankService : IBankService
    {
        public string BankId { get; private set; } //只給內部用的屬性: private set

        public string BankName { get; private set; }

        public FubonBankService()
        {
            BankId = "012";
            BankName = "富邦銀行";
        }
       
        public bool Deposit(decimal dollars)
        {
            return false;
        }

        public bool Withdraw(decimal dollars)
        {
            return true;
        }

        public decimal AccountBalance(int id)
        {
            return 1000000;
        }

    }
}
