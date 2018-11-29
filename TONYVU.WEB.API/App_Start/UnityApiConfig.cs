using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.WebApi;
using TONYVU.ENTITY.API.DAL;
using TONYVU.ENTITY.API.Repository;
using TONYVU.ENTITY.API.Service;


namespace TONYVU.WEB.API.App_Start
{
    public static class UnityApiConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            //container.Register<>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();

            container.RegisterType<IRepository<User>, Repository<User>>();
            container.RegisterType<IUserService, UserService>();

            container.RegisterType<IRepository<Product>, Repository<Product>>();
            container.RegisterType<IProductService, ProductService>();

            container.RegisterType<IRepository<Project>, Repository<Project>>();
            container.RegisterType<IProjectService, ProjectService>();

            container.RegisterType<IRepository<News>, Repository<News>>();
            container.RegisterType<INewsService, NewsService>();

            container.RegisterType<IRepository<TypeProduct>, Repository<TypeProduct>>();
            container.RegisterType<ITypeProductService, TypeProductService>();

            container.RegisterType<IRepository<FeedBack>, Repository<FeedBack>>();
            container.RegisterType<IFeedBackService, FeedBackService>();

            container.RegisterType<IRepository<Menu>, Repository<Menu>>();
            container.RegisterType<IMenuService, MenuService>();

            container.RegisterType<IRepository<GroupRole>, Repository<GroupRole>>();
            container.RegisterType<IGroupRoleService, GroupRoleService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }


    }


}