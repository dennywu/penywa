using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BonaStoco.Inf.Data.ViewModel;

namespace Global.Repository
{
    [NamedSqlQuery("findByUsername", @"SELECT * FROM tbluser where username = @username")]
    public class Account : IViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
