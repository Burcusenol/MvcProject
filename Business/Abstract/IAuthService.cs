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
        void Add(Admin admin);
        void Update(Admin admin);
        void Delete(Admin admin);
        List<Admin> GetAdmins();
        Admin GetById(int id);
     

    }
}