using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        ILoginDal _loginDal;

        public AuthManager(ILoginDal loginDal)
        {
            _loginDal = loginDal;
        }

        public void Add(Admin admin)
        {
            _loginDal.Insert(admin);
        }

        public void Delete(Admin admin)
        {
            _loginDal.Delete(admin);
        }

        public List<Admin> GetAdmins()
        {
            return _loginDal.GetAll();
        }

        public Admin GetById(int id)
        {
            return _loginDal.Get(a => a.AdminId == id);
        }

        public void Update(Admin admin)
        {
            _loginDal.Update(admin);
        }
    }
}
