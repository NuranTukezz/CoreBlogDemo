using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICategoryDal : IGenericDal<Category>
    {
        //GENERİC OLMADAN ÖNCE METODLAR HER DALA YAZILIYORDU KOD TEKRARINI ÖNLENDİ
        //List<Category> ListAllCategory();
        //void AddCategory(Category category);
        //void Delete(Category category);
        //void Update(Category category);
        //Category GetById(int id);

    }
}
