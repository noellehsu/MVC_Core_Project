using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreWebApi_TodoApi.Repositories;
using CoreWebApi_TodoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CoreWebApi_TodoApi.Repositories
{
    public class GenericRepositoryAsync<T> : IGenericRepositoryc<T> where T : BaseEnitiy
    {
        
        private readonly HRContext _context;
        public GenericRepositoryAsync(HRContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<T>> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<ActionResult<IEnumerable<T>>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<int> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(T entity)
        {
            var result = await _context.Set<T>().FindAsync(entity.Id);
            if (result == null)
            {
                return 0;
            }

            _context.Set<T>().Remove(result);
            return await _context.SaveChangesAsync();
        }
    }
}
