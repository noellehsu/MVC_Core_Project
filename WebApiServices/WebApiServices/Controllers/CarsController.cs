using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiServices.Models;
using WebApiServices.Helpers;

namespace WebApiServices.Controllers
{
    //但凡Web API 專案的Controller 控制器皆繼承ApiController 類別，和MVC 專案控制器繼承Controller 類別不同。
    public class CarsController : ApiController
    {
        List<CarSales> CarSalesNumber;
        public CarsController()
        {
            //以亂數產生1-12月銷售數據
            Utility util = new Utility();
            var random1 = util.getNumbers(12);
            var random2 = util.getNumbers(12);

            CarSalesNumber = new List<CarSales>
            {
                new CarSales { Id = 1, Car = "BMW", Salesdata = random1 },
                new CarSales { Id = 2, Car = "BENZ", Salesdata = random2 }
            };
        }

        //URL api/cars
        //無條件回傳所有汽車的銷售資料
        [AcceptVerbs("GET", "POST")] //接受HTTP GET 和POST方法之請求
        public IEnumerable<CarSales> getCarSalesNumber()
        {
            return CarSalesNumber;
        }

        //URL api/cars/2
        //抓Id找出銷售資料
        [AcceptVerbs("GET", "POST")]
        public IHttpActionResult getSingleCarSalesNumber(int id)
        {
            var car = CarSalesNumber.FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            var result = Ok(car);
            return result;
        }
    }
}
