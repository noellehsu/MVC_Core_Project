using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApiServices
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 設定和服務

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "Myapi/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //加上這行可以消除掉XML namespace
            config.Formatters.XmlFormatter.UseXmlSerializer = true;
        }
    }
}
