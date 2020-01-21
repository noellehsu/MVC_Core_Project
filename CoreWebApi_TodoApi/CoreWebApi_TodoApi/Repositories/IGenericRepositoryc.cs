using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreWebApi_TodoApi.Models;

namespace CoreWebApi_TodoApi.Repositories
{
    public interface IGenericRepositoryc<T> where T : BaseEnitiy
    {
        Task<ActionResult<T>> GetById(int id);
        Task<ActionResult<IEnumerable<T>>> GetAll();
        Task<int> Add(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(T entity);
    }
}
