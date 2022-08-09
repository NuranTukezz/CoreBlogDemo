using DataAccessLayer.Abstract;
using DataAccessLayer.Concrate;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class //ICategoryDal=> GENERİC OLMADAN ÖNCE BAĞIMLILIK ORTADAN KALDIRILDI
    {
        Context c = new Context();

        public void Delete(T t)
        {
            using var c = new Context();

            c.Remove(t);
            c.SaveChanges();
        }

        public T GetByID(int id)
        {
            using var c = new Context();

            return c.Set<T>().Find(id);
        }

        public List<T> GetListAll()
        {
            using var c = new Context();

            return c.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            using var c = new Context();

            c.Add(t);
            c.SaveChanges();
        }

        public List<T> GetListAll(Expression<Func<T, bool>> expression)
        {
            using var c = new Context();

            return c.Set<T>().Where(expression).ToList();

        }

        public void Update(T t)
        {
            using var c = new Context();

            c.Update(t);
            c.SaveChanges();
        }

        ////public List<T> GetListAll(Expression<Func<T, bool>> expression)
        ////{
        ////    throw new NotImplementedException();
        ////}


        //Context c =new Context();
        //public void AddCategory(Category category)
        //{
        //    c.Add(category);
        //    c.SaveChanges();
        //}

        //public void Delete(Category category)
        //{
        //    c.Remove(category);
        //    c.SaveChanges();
        //}

        //public Category GetById(int id)
        //{
        //    return c.Categories.Find(id);
        //}

        //public List<Category> ListAllCategory()
        //{
        //   return c.Categories.ToList();
        //}

        //public void Update(Category category)
        //{
        //    c.Update(category);
        //    c.SaveChanges();
        //}
    }
}
