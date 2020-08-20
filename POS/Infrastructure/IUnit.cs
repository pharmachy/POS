using Microsoft.AspNetCore.Mvc.Rendering;
using POS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Infrastructure
{
 public   interface IUnit
    {
        IEnumerable<Unit> GetAll();
        Unit GetById(int Id);
        void Insert(Unit unit);
        void Update(Unit unit);
        void Delete(Unit unit);
        void Save();
        IEnumerable<SelectListItem> GetAllUnit();


    }
}
