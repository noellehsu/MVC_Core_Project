using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreWebApi_TodoApi.Models;
using CoreWebApi_TodoApi.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebApi_TodoApi.Repositories
{

    //這邊是IEmployeeRepository的實作
    public class EmployeeRepositoryAsync : IEmployeeRepository<Employee>
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

        public async Task<int> Add(Employee emp)
        {
            await _context.Employees.AddAsync(emp);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(Employee emp)
        {
            _context.Entry(emp).State = EntityState.Modified;
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
