using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Context.Support;
using Global.Repository;

namespace Global.Security
{
    public class AuthService : IAuthService
    {
        private IAccountRepository AccountRepository
        {
            get { return (IAccountRepository)ContextRegistry.GetContext().GetObject("AccountRepository"); }
        }
        public int Login(string username, string password)
        {
            Account acc = AccountRepository.FindAccountByUsername(username);
            if (acc == null || acc.Password != password)
                throw new ApplicationException("Username atau Password anda salah.");
            return acc.Id;
        }
    }
}
