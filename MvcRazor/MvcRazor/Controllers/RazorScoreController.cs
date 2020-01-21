using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcRazor.Models;

namespace MvcRazor.Controllers
{
    public class RazorScoreController : Controller
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

        public ActionResult Scores()
        {
            return View(students);
        }

        public ActionResult ScoresRazor()
        {
            //找出總分最高者之Id
            int topId = 0;
            int topScore = 0;

            foreach (var student in students)
            {
                //計算總分
                student.Total = student.Chinese + student.English + student.Math;

                //判斷總分最高者
                if (student.Total > topScore)
                {
                    topScore = student.Total;
                    topId = student.Id;
                }
            }

            //將最高分學生Id儲存到ViewBag，傳遞給View
            ViewBag.TopId = topId;

            return View(students);
        }


        public ActionResult ScoresRazorPure()
        {
            return View(students);
        }


        public ActionResult ScoresRazorHelper()
        {
            //找出總分最高者之Id
            int topId = 0;
            int topScore = 0;

            foreach (var student in students)
            {
                //計算總分
                student.Total = student.Chinese + student.English + student.Math;

                //判斷總分最高者
                if (student.Total > topScore)
                {
                    topScore = student.Total;
                    topId = student.Id;
                }
            }

            //將最高分學生Id儲存到ViewBag，傳遞給View
            ViewBag.TopId = topId;

            return View(students);
        }

        public ActionResult GlobalHtmlHelper()
        {
            //找出總分最高者之Id
            int topId = 0;
            int topScore = 0;

            foreach (var student in students)
            {
                //計算總分
                student.Total = student.Chinese + student.English + student.Math;

                //判斷總分最高者
                if (student.Total > topScore)
                {
                    topScore = student.Total;
                    topId = student.Id;
                }
            }

            //將最高分學生Id儲存到ViewBag，傳遞給View
            ViewBag.TopId = topId;

            return View(students);
        }

        public ActionResult ScoresList()
        {

            return View(students);
        }
    }
}