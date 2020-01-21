using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcRazor.Models;

namespace MvcRazor.Controllers
{
    public class LabsController : Controller
    {
        //學生考試成績model資料
        protected List<Student> students = new List<Student>
        {
            new Student { Id =1, Name="Joe", Chinese=88, English=95, Math=71 },
            new Student { Id =12, Name="Mary", Chinese=92, English=82, Math=60 },
            new Student { Id =23, Name="Cathy", Chinese=98, English=91, Math=94 },
            new Student { Id =34, Name="John", Chinese=63, English=85, Math=55 },
            new Student { Id =45, Name="David", Chinese=59, English=77, Math=82 }
        };

        public ActionResult ScoresRazor()
        {
            //方式1:比較笨的老派方法
            //計算每位學生總分
            foreach (var student in students)
            {
                student.Total = student.Chinese + student.English + student.Math;
            }

            var result = students.OrderByDescending(x=>x.Total).Select(s=>s.Id).FirstOrDefault();

            var query = students.Where(s => s.Total == students.Max(x => x.Total)).Select(s => s.Id).FirstOrDefault();

            //找出總分最高者
            var top = from s in students
                      where s.Total == (students.Max(x => x.Total))
                      select s.Id;

            //方式2:LINQ -- 查詢語法
            var topId = (from s in students
                         orderby (s.Chinese + s.English + s.Math) descending
                         select s.Id).First();

            //方式3:LINQ -- 方法語法
            var id = students.OrderByDescending(s => s.Chinese + s.English + s.Math)
                             .Select(s => s.Id)
                             .FirstOrDefault();

            var topStudentId = students.OrderByDescending(s => s.Chinese + s.English + s.Math)
                                       .Select(s => s.Id)
                                       .Take(1)
                                       .FirstOrDefault();


            //將最高分學生Id儲存到ViewBag，傳遞給View
            ViewBag.TopId = Convert.ToInt32(topId);

            return View(students);
        }

        public ActionResult ScoresRazorPure()
        {
            return View(students);
        }
    }
}