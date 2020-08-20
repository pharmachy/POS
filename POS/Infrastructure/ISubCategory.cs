using POS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Infrastructure
{
    public interface ISubCategory
    {

        List<SubCategory> GetAll();
        List<SubCategory> GetAllInCluded();
        SubCategory GetById(int id);
        void Insert(SubCategory data);
        void Update(SubCategory data);
        void Delete(SubCategory data);
        void Save();
    }
}
