using POS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Infrastructure
{
          public interface IBrand
    {
      

            List<Brand> GetAll();
            List<Brand> GetAllInCluded();
            Brand GetById(int id);
            void Insert(Brand data);
            void Update(Brand data);
            void Delete(Brand data);
            void Save();
        
    }
}
