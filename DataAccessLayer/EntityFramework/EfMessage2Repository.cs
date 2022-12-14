using DataAccessLayer.Abstract;
using DataAccessLayer.Concrate;
using DataAccessLayer.Repositories;
using EntityLayer.Concrate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfMessage2Repository : GenericRepository<Message2>, IMessage2Dal
    {
        public List<Message2> GetInBoxWithMessageByWriter(int id)//gönderilen mesaj gelecek
        {
            using (var c = new Context())
            {
                return c.Message2s.Include(x => x.SenderUser).Where(x => x.ReceiverID == id).ToList();
                //return c.Message2s.Include(x => x.SenderUser).Where(x => x.ReceiverID == id).ToList(); // => alıcı mesajı
              

            }
        }

        public List<Message2> GetSendBoxWithMessageByWriter(int id)//mesaj gönderilecek
        {
            using (var c = new Context())
            {
                return c.Message2s.Include(x=>x.ReceiverUser).Where(x => x.SenderID == id).ToList();
                // return c.Message2s.Include(x => x.ReceiverUser).Where(x => x.SenderID == id).ToList(); // =>  gönderdiğim mesajlar gelsin

            }
        }
    }
}
