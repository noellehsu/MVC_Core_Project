using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreWebApi_TodoApi.Models;
using CoreWebApi_TodoApi.Repositories;

namespace CoreWebApi_TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesRepoController : ControllerBase
    {
        private readonly IEmployeeRepository<Employee> _repo;

        //async
        public EmployeesRepoController(IEmployeeRepository<Employee> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
        {
            var result = await _repo.GetAll();

            return result;
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var emp = await _repo.GetById(id);

            return emp;
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee emp)
        {
            if (await _repo.Add(emp) == 0)
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

        // POST: api/Employees
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee emp)
        {
            
            await _repo.Add(emp);

            if (await _repo.Add(emp) == 0)
            {
                return new ObjectResult(new { message = "建立失敗" });
            }

            var msgObject = new
            {
                statuscode = StatusCodes.Status201Created,
                date = DateTime.Now.ToLongDateString(),
                time = DateTime.Now.ToLongTimeString()
            };

            return CreatedAtAction(nameof(GetEmployee), new { Id = emp.Id }, msgObject);

            //return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        // DELETE: api/Employees/5
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
