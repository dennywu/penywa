using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Global.Repository.models;

namespace Global.Repository
{
    public interface IAccountRepository
    {
        Account FindAccountByUsername(string username);
    }
}
