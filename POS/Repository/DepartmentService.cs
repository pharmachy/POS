using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POS.Data;
using POS.Models;

namespace POS.Repository
{
    public class DepartmentService : IDepartmentRepo
    {
        private POSDbContext _context;

        public DepartmentService(POSDbContext context)
        {
            _context = context;
        }
        public void Delete(Department department)
        {
            _context.Departments.Remove(department);
        }

        public List<Department> GetAll()
        {
            return _context.Departments.ToList();
        }

        public Department GetById(int Id)
        {
            return _context.Departments.Where(x => x.Id == Id).FirstOrDefault();
        }

        public void Insert(Department department)
        {
            _context.Departments.Add(department);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        public void Update(Department department)
        {
            _context.Departments.Update(department);
        }
    }
}

