using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreMvc3_Foundation.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoreMvc3_Foundation.Controllers
{
    public class BankServiceController : Controller
    {
        public readonly IBankService _bankService;
        
        //預設建構式
        public BankServiceController(IBankService bankService)  
        {
            _bankService = bankService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BankService()
        {
            string Id = _bankService.BankId;
            string Name = _bankService.BankName;
            decimal Balance = _bankService.AccountBalance(12386);

            return View();
        }

    }
}