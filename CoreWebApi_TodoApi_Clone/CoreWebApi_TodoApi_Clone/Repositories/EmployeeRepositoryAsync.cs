using CoreWebApi_TodoApi_Clone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi_TodoApi_Clone.Repositories
{
    public class EmployeeRepositoryAsync : IEmployeeRepository<Employee> //這邊是IEmployeeRepository的實作
    {
        private readonly EmployeeContext _context;
        public EmployeeRepositoryAsync(EmployeeContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<Employee>> GetById(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<ActionResult<IEnumerable<Employee>>> GetAll()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<int> Add(Employee entity)
        {
            await _context.Employees.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(Employee entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var result = await _context.Employees.FindAsync(id);
            if (result == null)
            {
                return 0;
            }

            _context.Employees.Remove(result);
            return await _context.SaveChangesAsync();
        }

    }
}
