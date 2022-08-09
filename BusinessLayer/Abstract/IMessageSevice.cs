using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageSevice : IGenericService<Message>
    {
        //şartlı mesaj listeleme
        List<Message> GetInboxListByWriter(string p);
    }
}
