﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BonaStoco.Inf.DataMapper.Impl;
using BonaStoco.Inf.Reporting;
using Global.Repository.models;

namespace Global.Repository
{
    public class AccountRepository : IAccountRepository
    {
        QueryObjectMapper qryObjectMapper;
        public AccountRepository(QueryObjectMapper qryObject)
        {
            this.qryObjectMapper = qryObject;
        }
        public Account FindAccountByUsername(string username)
        {
            return qryObjectMapper.Map<Account>("findByUsername", new string[1] { "username" }, new object[1] { username }).FirstOrDefault();
        }
    }
}
