using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogService : IGenericService<Blog>
    {
        List<Blog> GetBlogListWithCategory();//hem category hem yazarla işlem yapılıyor
        List<Blog> GetBlogListByWriter(int id);
    }
}
