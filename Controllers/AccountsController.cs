
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using MSDemo.Model;

namespace MSDemo.Controllers
{                      

  [ApiController]
  [Route("[controller]")]

    public class AccountsController: ControllerBase
    {   
        private readonly List<Account> _accounts = new List<Account>
        {           
            new Account {AccountId = Guid.Parse("3e2fec30-0fa7-4442-9517-93c4406f4532"), Name="Master account"},
            new Account {AccountId = Guid.NewGuid(), Name="Gift account"},
            new Account {AccountId = Guid.NewGuid(), Name="Meta-Gift"},
            new Account {AccountId = Guid.Parse("5c04fa68-a7de-4f3f-95a0-17e837a27fd5"), Name="Meta-GPR"},

        };

       
        [HttpGet]
        public IEnumerable<Account> GetAccounts()
        {
            return _accounts;
        }

        [HttpGet("{accountId}")]
        public ActionResult<Account> GetAccount(Guid accountId)
        {
            return _accounts.Where(x=> x.AccountId == accountId).FirstOrDefault();
         
        }

    }  
}