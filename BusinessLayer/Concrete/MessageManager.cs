using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void TAdd(Message t)
        {
            _messageDal.Insert(t);
        }

        public void TDelete(Message t)
        {
            _messageDal.Delete(t);
        }

        public List<Message> TGetList()
        {
            return _messageDal.GetList();
        }

        public Message TGetByID(int id)
        {
            return _messageDal.GetByID(x => x.MessageID == id);
        }

        public void TUpdate(Message t)
        {
            throw new NotImplementedException();
        }

        public List<Message> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }
    }
}
