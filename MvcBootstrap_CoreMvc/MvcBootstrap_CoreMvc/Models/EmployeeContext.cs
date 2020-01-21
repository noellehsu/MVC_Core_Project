using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcBootstrap_CoreMvc.Models
{
    public class EmployeeContext:DbContext
    {
        //相依性注入
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        //加入種子資料(DbContext移至定義+OnModelCreating整條複製，原本是internal virtual改成override)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
            new Employee { Id = 1, Name = "Kevin", Mobile = "0912-422231", Email = "no@gmail.com", Department = "RD", Title = "專員" },
            new Employee { Id = 2, Name = "Lissa", Mobile = "0912-422231", Email = "no@gmail.com", Department = "RD", Title = "助理" },
            new Employee { Id = 3, Name = "Sheldon", Mobile = "0912-422231", Email = "no@gmail.com", Department = "RD", Title = "老闆" },
            new Employee { Id = 4, Name = "Amy", Mobile = "0912-422231", Email = "no@gmail.com", Department = "RD", Title = "客服" },
            new Employee { Id = 5, Name = "Penny", Mobile = "0912-422231", Email = "no@gmail.com", Department = "RD", Title = "寫手" }
        
           );
        }
    }
}



