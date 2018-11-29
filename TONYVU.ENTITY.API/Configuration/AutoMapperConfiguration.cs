using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TONYVU.ENTITY.API.DAL;
using TONYVU.ENTITY.API.Service;

namespace TONYVU.ENTITY.API.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static void Configuration()
        {
            ConfigureMapping();
        }

        public static void ConfigureMapping()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<UserViewModel.UserDto, User>();
                cfg.CreateMap<User, UserViewModel.UserDto>();
                //cfg.CreateMap<User, UserViewModel.UserDto>().ForSourceMember(o => o.Password_User, opt => opt.Ignore());

                cfg.CreateMap<ProductViewModel.ProductDto, Product>();
                cfg.CreateMap<Product, ProductViewModel.ProductDto>();

                cfg.CreateMap<ProjectViewModel.ProjectDto, Project>();
                cfg.CreateMap<Project, ProjectViewModel.ProjectDto>();

                cfg.CreateMap<FeedBackViewModel.FeedBackDto, FeedBack>();
                cfg.CreateMap<FeedBack, FeedBackViewModel.FeedBackDto>();

                cfg.CreateMap<TypeProductViewModel.TypeProductDto, TypeProduct>();
                cfg.CreateMap<TypeProduct, TypeProductViewModel.TypeProductDto>();

                cfg.CreateMap<NewsViewModel.NewsDto, News>();
                cfg.CreateMap<News, NewsViewModel.NewsDto>();

                cfg.CreateMap<GroupRoleViewModel.GroupRoleDto, GroupRole>();
                cfg.CreateMap<GroupRole, GroupRoleViewModel.GroupRoleDto>();

                cfg.CreateMap<RoleViewModel.RoleDto, Role>();
                cfg.CreateMap<Role, RoleViewModel.RoleDto>();

                cfg.CreateMap<MenuViewModel, Menu>();
                cfg.CreateMap<Menu, MenuViewModel>();
            });
        }
    }
}
