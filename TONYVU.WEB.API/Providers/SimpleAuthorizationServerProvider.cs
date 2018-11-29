using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.Owin.Security.OAuth;
using TONYVU.ENTITY.API.DAL;
using TONYVU.ENTITY.API.Repository;
using TONYVU.ENTITY.API.Service;

namespace TONYVU.WEB.API.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private IUserService _userService;

        public SimpleAuthorizationServerProvider()
        {
            _userService = new UserService(new UnitOfWork(new WebContext()));
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext validateContext)
        {
            validateContext.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                var formData = await context.Request.ReadFormAsync();
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
                var info = _userService.Repository.DbSet.FirstOrDefault(
                        o => o.UserName == context.UserName && o.Password_User == context.Password);
                if (info == null)
                {
                    context.SetError("invalid-grant", "The username or password is not correct.");
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("sub", context.UserName));
                //identity.AddClaim(new Claim("role", "user"));
                context.Validated(identity);
                
                
            }
            catch (Exception exception)
            {
                throw;
            }
          
        }


    }

}
