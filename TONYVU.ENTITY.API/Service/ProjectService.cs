using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TONYVU.ENTITY.API.DAL;
using TONYVU.ENTITY.API.Configuration;
using TONYVU.ENTITY.API.Helper;
using TONYVU.ENTITY.API.Repository;

namespace TONYVU.ENTITY.API.Service
{
    public interface IProjectService : IEntityServiceBase<Project>
    {
        void Insert(ProjectViewModel.ProjectDto Project);
        void Update(ProjectViewModel.ProjectDto Project, string id);
        ProjectViewModel.ProjectDto Detail(string id);
        void Delete(string id);
    }
    public class ProjectService : EntityServiceBase<Project>, IProjectService
    {
        private string ProjectCode = "Emp";

        public ProjectService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public void Insert(ProjectViewModel.ProjectDto Project)
        {
            try
            {
                var data = new Project();
                if (Project != null)
                {
                    data = Mapper.Map<ProjectViewModel.ProjectDto, Project>(Project);
                    data.CreateDate = DateTime.Now;
                    InsertService(data); ;
                }

            }
            catch (Exception exception)
            {
                throw new Exception("Sorry, Something went wrong!");
            }
        }

        public void Update(ProjectViewModel.ProjectDto Project, string id)
        {
            try
            {
                if (Project != null)
                {
                    var data = Mapper.Map<ProjectViewModel.ProjectDto, Project>(Project);
                    UpdateService(data);
                    UnitOfWork.Save();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Sorry, Something went wrong!");
            }
        }

        public ProjectViewModel.ProjectDto Detail(string id)
        {
            var data = new ProjectViewModel.ProjectDto();
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    var exist = Repository.GetById(id);
                    data = Mapper.Map<Project, ProjectViewModel.ProjectDto>(exist);
                    return data;
                }
            }
            catch (Exception exception)
            {
                return null;
            }
            return data;
        }

        public void Delete(string id)
        {
            var _id = Convert.ToInt32(id);
            try
            {
                Repository.Delete(_id);
                UnitOfWork.Save();
            }
            catch (Exception exception)
            {
                throw new Exception("Sorry, Something went wrong!");
            }
        }
    }
}
