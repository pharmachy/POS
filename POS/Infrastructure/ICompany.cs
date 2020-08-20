using Microsoft.AspNetCore.Mvc.Rendering;
using POS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Infrastructure
{
  public  interface ICompany
    {
        IEnumerable<Company>GetAll();
        Company GetById(int Id);
        void Insert(Company company);
        void Update(Company company);
        void Delete(Company company);
        void Save();
        IEnumerable<SelectListItem> GetAllCompany();
    }
}
