using CoreWebApi_TodoApi_Clone.Models;
using CoreWebApi_TodoApi_Clone.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi_TodoApi_Clone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesRepoController:ControllerBase  
    {
        private readonly IEmployeeRepository<Employee> _repo;
        public EmployeesRepoController(IEmployeeRepository<Employee> repo)
        {
            _repo = repo;
        }

        //我把方法寫在Repository(EmployeeRepositoryAsync)裡
        //這樣只要呼叫GetAll方法就能調用資料庫的東西了
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {
            var result = await _repo.GetAll();  //這個方案總共有3個GetAll()，請理解他們的關西
            return result;
        }

        //Get:api/EmployeesRepo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetById(int id)
        {

            return await _repo.GetById(id);
        }

        // PUT: api/EmployeesRepo/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee emp)
        {
            if (await _repo.Update(emp) == 0)
            {
                return new ObjectResult(new { message = "更新失敗" });
            }


            var msgObject = new
            {
                statuscode = (int)System.Net.HttpStatusCode.OK,
                date = DateTime.Now.ToLongDateString(),
                time = DateTime.Now.ToLongTimeString()
            };

            return CreatedAtAction(nameof(GetEmployee), new { Id = emp.Id }, msgObject);
        }

        // POST: api/EmployeesRepo
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee emp)
        {
            //await _repo.Add(emp);
            //if (await _repo.Add(emp) == 0)
            //{
            //    return new ObjectResult(new { message = "建立失敗" });
            //}

            int count = await _repo.Update(emp);


            var msgObject = new
            {
                statuscode = StatusCodes.Status201Created,
                date = DateTime.Now.ToLongDateString(),
                time = DateTime.Now.ToLongTimeString(),
                developer = "By Noelle"
            };

            //CreatedAtAction:創建成功會回傳201Created
            return CreatedAtAction(nameof(GetEmployee), new { Id = emp.Id }, msgObject);

            //return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        // DELETE: api/EmployeesRepo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            if (await _repo.Delete(id) == 0)
            {
                return new ObjectResult(new { message = "刪除失敗" });
            }

            return Ok(StatusCodes.Status200OK);
        }
    

}
}
