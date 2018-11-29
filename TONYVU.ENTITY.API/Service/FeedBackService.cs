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
    public interface IFeedBackService : IEntityServiceBase<FeedBack>
    {
        void Insert(FeedBackViewModel.FeedBackDto FeedBack);
        void Update(FeedBackViewModel.FeedBackDto FeedBack, string id);
        FeedBackViewModel.FeedBackDto Detail(string id);
        void Delete(string id);
    }
    public class FeedBackService : EntityServiceBase<FeedBack>, IFeedBackService
    {
        private string FeedBackCode = "Emp";

        public FeedBackService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public void Insert(FeedBackViewModel.FeedBackDto FeedBack)
        {
            try
            {
                var data = new FeedBack();
                if (FeedBack != null)
                {
                    data = Mapper.Map<FeedBackViewModel.FeedBackDto, FeedBack>(FeedBack);
                    data.CreateDate = DateTime.Now;
                    InsertService(data); ;
                }

            }
            catch (Exception exception)
            {
                throw new Exception("Sorry, Something went wrong!");
            }
        }

        public void Update(FeedBackViewModel.FeedBackDto FeedBack, string id)
        {
            try
            {
                if (FeedBack != null)
                {
                    var data = Mapper.Map<FeedBackViewModel.FeedBackDto, FeedBack>(FeedBack);
                    UpdateService(data);
                    UnitOfWork.Save();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Sorry, Something went wrong!");
            }
        }

        public FeedBackViewModel.FeedBackDto Detail(string id)
        {
            var data = new FeedBackViewModel.FeedBackDto();
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    var exist = Repository.GetById(id);
                    data = Mapper.Map<FeedBack, FeedBackViewModel.FeedBackDto>(exist);
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
