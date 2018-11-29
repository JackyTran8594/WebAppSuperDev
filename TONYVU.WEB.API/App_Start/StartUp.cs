using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.OAuth;
using TONYVU.ENTITY.API.Configuration;
using TONYVU.WEB.API.Providers;

[assembly: OwinStartup(typeof(TONYVU.WEB.API.App_Start.StartUp))]

namespace TONYVU.WEB.API.App_Start
{
    public class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            RouteCollection routeCollection = new RouteCollection();
            WebApiConfig.Register(config);
            RouteConfig.RegisterRoutes(routeCollection);
            UnityApiConfig.RegisterComponents();
            AutoMapperConfiguration.Configuration();
            ConfigurationOAuth(app);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
        }

        public void ConfigurationOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions oAuthServerOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(2),
                Provider = new SimpleAuthorizationServerProvider()
            };

            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

    }
}