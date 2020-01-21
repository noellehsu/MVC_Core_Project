using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreWebApi_TodoApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebApi_TodoApi.Repositories
{
    public interface IEmployeeRepository<T> where T:class
    {
        Task<ActionResult<T>> GetById(int id);
        Task<ActionResult<IEnumerable<T>>> GetAll();
        Task<int> Add(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(int id);
    }
}
