using Microsoft.AspNetCore.Mvc.Rendering;
using POS.Data;
using POS.Infrastructure;
using POS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Repository
{
    public class CompanyService : ICompany
    {
        private POSDbContext _context;
        public CompanyService(POSDbContext context)
        {
            _context = context;
        }
        public void Delete(Company company)
        {
            _context.Companies.Remove(company);
        }

        public IEnumerable<Company> GetAll()
        {
            return _context.Companies.ToList();
        }

        public IEnumerable<SelectListItem> GetAllCompany()
        {
            return GetAll().Select(com => new SelectListItem()
            {
                Text = com.Company_Name,
                Value = com.Id.ToString()
            });
        }

        public Company GetById(int Id)
        {
            return _context.Companies.Where(x => x.Id == Id).FirstOrDefault();
        }

        public void Insert(Company company)
        {
            _context.Companies.Add(company);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Company company)
        {
            _context.Companies.Update(company);
        }
    }
}
