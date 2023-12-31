﻿using Core.Entities.Conceretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IUserService
    {
        void Add(User user);
        User GetByMail(string email);
        List<OperationClaim> GetClaims(User user);
    }
}
