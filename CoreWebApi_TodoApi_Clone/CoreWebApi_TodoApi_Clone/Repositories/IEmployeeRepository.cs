using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi_TodoApi_Clone.Repositories
{
    public interface IEmployeeRepository<T> where T : class
    {
        //這個介面只是抽象的定義，EmployeeRepositoryAsync這個類別就是把介面定義的東西實作出來
        //完全沒有相依任何Model模型， 可接受任何型別
        Task<ActionResult<T>> GetById(int id);
        Task<ActionResult<IEnumerable<T>>> GetAll();
        Task<int> Add(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(int id);


    }
}
