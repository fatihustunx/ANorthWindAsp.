﻿using Core.Entities.Conceretes;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IAuthService
    {

        IDataResult<AccessToken> RunToLogin(UserForLoginDto userForLoginDto);

        IDataResult<AccessToken> RunToRegister(UserForRegisterDto userForRegisterDto);
    }
}