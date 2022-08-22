using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IMessage2Dal : IGenericDal<Message2>
    {
        List<Message2> GetInBoxWithMessageByWriter(int id);//yazara göre InBox ı getir
        List<Message2> GetSendBoxWithMessageByWriter(int id);

        //List<Message2> GetlistWithMessageByWriter(int id);

    }
}
