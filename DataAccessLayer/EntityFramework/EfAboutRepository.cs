﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfAboutRepository : GenericRepository<About>, IAboutDal
    {
        //public List<About> GetListAll(Expression<Func<About, bool>> expression)
        //{
        //    throw new NotImplementedException();
        //}
    }
}