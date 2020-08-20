using Microsoft.AspNetCore.Mvc.Rendering;
using POS.Models;
using POS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Infrastructure
{
   public interface IBrandModel
    {
        BrandModel GetById(int Id);
        List<BrandModel> GetAllInCluded();
        IEnumerable<BrandModel> GetAll();
        void Insert(BrandModel data);
        void Update(BrandModel data);
        void Delete(BrandModel data);
        IQueryable<BrandModelVM> GetVm();
        void Save();
    }
}
