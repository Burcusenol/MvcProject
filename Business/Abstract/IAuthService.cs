﻿using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        void Register(string adminMail, string password);
        bool Login(LoginDto loginDto);

    }
}
