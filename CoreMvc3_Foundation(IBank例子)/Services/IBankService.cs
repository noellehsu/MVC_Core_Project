using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMvc3_Foundation.Services
{
    public interface IBankService
    {
        string BankId { get; }    //銀行代碼
        string BankName { get;}

        bool Withdraw(decimal dollars);     
        bool Deposit(decimal dollars);     
        decimal AccountBalance(int id);   // 帳戶餘額
 
    }
}
