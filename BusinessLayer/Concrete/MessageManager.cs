using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void Delete(Message message)
        {
            _messageDal.Delete(message);
        }

        public Message GetById(int Id)
        {
            return _messageDal.Get(m => m.MessageID == Id);
        }

        public List<Message> GetMessageSendBox()
        {
            return _messageDal.List(m => m.SenderMail == "admin@gmail.com");
        }

        public List<Message> GetMessagesInbox()
        {
            return _messageDal.List(m => m.ReceiverMail == "admin@gmail.com");
        }

        public void MessageAdd(Message message)
        {
            throw new NotImplementedException();
        }

        public void Update(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
