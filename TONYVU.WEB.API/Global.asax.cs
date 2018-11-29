using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using AutoMapper;
using Microsoft.Owin;
using TONYVU.ENTITY.API.Configuration;
using TONYVU.WEB.API.App_Start;

namespace TONYVU.WEB.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapperConfiguration.ConfigureMapping();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            UnityApiConfig.RegisterComponents();

        }
         

        //protected void ApplicationMvc_Start(object sender, EventArgs e)
        //{
        //    RouteConfig.RegisterRoutes(MvcConfig.RegisterMvc(Rot));
        //}


    }
}
