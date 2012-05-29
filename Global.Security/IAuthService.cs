using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Global.Security
{
    public interface IAuthService
    {
        int Login(string username, string password);
    }
}
