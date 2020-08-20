using POS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Repository
{
  public  interface IDepartmentRepo
    {
        List<Department> GetAll();
        Department GetById(int Id);
        void Insert(Department department);
        void Update(Department department);
        void Delete(Department department);
        void Save();
        
    }
}
