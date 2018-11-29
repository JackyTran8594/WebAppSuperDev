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
    public interface INewsService : IEntityServiceBase<News>
    {
        void Insert(NewsViewModel.NewsDto News);
        void Update(NewsViewModel.NewsDto News, string id);
        NewsViewModel.NewsDto Detail(string id);
        void Delete(string id);
    }
    public class NewsService : EntityServiceBase<News>, INewsService
    {
        private string NewsCode = "Emp";

        public NewsService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public void Insert(NewsViewModel.NewsDto News)
        {
            try
            {
                var data = new News();
                if (News != null)
                {
                    data = Mapper.Map<NewsViewModel.NewsDto, News>(News);
                    data.Status = 10;
                    data.CreateDate = DateTime.Now;
                    InsertService(data); ;
                }

            }
            catch (Exception exception)
            {
                throw new Exception("Sorry, Something went wrong!");
            }
        }

        public void Update(NewsViewModel.NewsDto News, string id)
        {
            try
            {
                if (News != null)
                {
                    var data = Mapper.Map<NewsViewModel.NewsDto, News>(News);
                    UpdateService(data);
                    UnitOfWork.Save();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Sorry, Something went wrong!");
            }
        }

        public NewsViewModel.NewsDto Detail(string id)
        {
            var data = new NewsViewModel.NewsDto();
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    var exist = Repository.GetById(id);
                    data = Mapper.Map<News, NewsViewModel.NewsDto>(exist);
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
