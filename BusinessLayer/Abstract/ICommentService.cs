using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService
    {
        void CommentAdd(Comment comment);
        List<Comment> GetList(int id);//Bloga göre değer gelecek
        List<Comment> GetCommentWithBlog();//yorumları blogla getir
    }
}
