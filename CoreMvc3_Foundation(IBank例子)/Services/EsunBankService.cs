using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMvc3_Foundation.Services
{
    public class EsunBankService : IBankService
    {
        public string BankId { get; private set; }

        public string BankName { get; private set; }

        public EsunBankService()
        {
            BankId = "808";
            BankName = "玉山銀行";
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
            return 2000000;
        }
    }
}
