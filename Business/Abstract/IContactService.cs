using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> GetContacts();
        void Insert(Contact contact);
        void Update(Contact contact);
        void Delete(Contact contact);
        Contact GetById(int id);
        
    }
}
