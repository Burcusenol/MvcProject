using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMessageService
    {
        void Insert(Message message);
        List<Message> GetMessagesInbox();
        void Delete(Message message);
        void Update(Message message);
        Message GetById(int Id);
        List<Message> GetMessageSendBox();
        List<Message> IsDraft();
    }
}
